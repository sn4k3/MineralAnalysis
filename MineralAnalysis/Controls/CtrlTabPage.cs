using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;

namespace MineralAnalysis.Controls
{
    public partial class CtrlTabPage : UserControl, IDisposable
    {
        #region Properties
        /// <summary>
        /// Gets the image full path with filename
        /// </summary>
        public string FilePath { get; }

        /// <summary>
        /// Get file path only, without filename
        /// </summary>
        public string FilePathOnly => Path.GetDirectoryName(FilePath);

        /// <summary>
        /// Gets the full filename with extension
        /// </summary>
        public string FileName => Path.GetFileName(FilePath);

        /// <summary>
        /// /// <summary>
        /// Gets the filename without extension
        /// </summary>
        /// </summary>
        public string FileNameWithoutExtension => Path.GetFileNameWithoutExtension(FilePath);

        /// <summary>
        /// Get file extension only
        /// </summary>
        public string FileExtension => Path.GetExtension(FilePath);

        public bool IsLoaded { get; private set; }

        public Image<Bgr, Byte> ImgOriginal { get; private set; }

        public Image<Gray, Byte> ImgGray { get; private set; }


        /// <summary>
        /// Gets the rendered images 
        /// </summary>
        public List<CtrlImageBox> ImageBoxs { get; } = new List<CtrlImageBox>();

        public HistogramBox HistogramPanel { get; } = new HistogramBox();
        
        /// <summary>
        /// Gets the real image size in pixels
        /// </summary>
        public Size ImageSize
        {
            get
            {
                if (!IsLoaded) return Size.Empty;
                return ImageBoxs[0].ImageBox.GetImageViewPort().Size;
            }
        }

        /// <summary>
        /// Gets the scroll position
        /// </summary>
        public Point ImageScrollPosition
        {
            get
            {
                if (!IsLoaded) return Point.Empty;
                return ImageBoxs[0].ImageBox.AutoScrollPosition;
            }
        }

        /// <summary>
        /// Gets the zoom
        /// </summary>
        public int ImageZoom
        {
            get
            {
                if (!IsLoaded) return 0;
                return ImageBoxs[0].ImageBox.Zoom;
            }
        }

        /// <summary>
        /// Gets the zoom factor
        /// </summary>
        public double ImageZoomFactor
        {
            get
            {
                if (!IsLoaded) return 0;
                return ImageBoxs[0].ImageBox.ZoomFactor;
            }
        }


        /// <summary>
        /// Gets the mouse location relative to the image
        /// </summary>
        public Point ImageCursorLocation { get; set; } = Point.Empty;

        /// <summary>
        /// Gets or sets when events should or not be fired
        /// </summary>
        public bool SuspendEvents { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="filePath">Image filepath to open</param>
        public CtrlTabPage(string filePath)
        {
            InitializeComponent();

            if(string.IsNullOrEmpty(filePath))
                throw  new ArgumentNullException(nameof(filePath));

            FilePath = filePath;

            HistogramPanel.Dock = DockStyle.Fill;
            HistogramPanel.ZedGraphControl.IsShowPointValues = true;
            scDataHistogram.Panel2.Controls.Add(HistogramPanel);
            HistogramPanel.Refresh();
        }
        #endregion

        #region Overrides

        public new void Dispose()
        {
            IsLoaded = false;
            HistogramPanel.Dispose();
            foreach (var ctrlImageBox in ImageBoxs)
            {
                ctrlImageBox.ImageBox.Dispose();
                ctrlImageBox.Dispose();
            }
            base.Dispose();
        }

        #endregion

        #region Methods
        private CtrlImageBox AddImageBox(CtrlImageBox.FilterAlgorithm filter)
        {
            CtrlImageBox imagebox = new CtrlImageBox(filter, this) { Dock = DockStyle.Fill};
            ImageBoxs.Add(imagebox);
            tlImages.Controls.Add(imagebox);
            return imagebox;
        }

        /// <summary>
        /// Start processing the image
        /// </summary>
        public void ProcessImage()
        {
            //Load the image from file and resize it for display
            ImgOriginal =
                new Image<Bgr, byte>(FilePath);
            //.Resize(400, 400, Emgu.CV.CvEnum.Inter.Linear, true);

            HistogramPanel.ClearHistogram();
            HistogramPanel.GenerateHistograms(ImgOriginal, 256);
            HistogramPanel.Refresh();         

            //Convert the image to grayscale and filter out the noise
            ImgGray = ImgOriginal.Convert<Gray, Byte>().SmoothGaussian(5, 5, 0 ,0)/*.PyrDown().PyrUp()*/;

            PopulateImageProperties(ImgOriginal);

            foreach (CtrlImageBox.FilterAlgorithm name in Enum.GetValues(typeof(CtrlImageBox.FilterAlgorithm)))
            {
                AddImageBox(name);
            }

            IsLoaded = true;
        }

        private void PopulateImageProperties(IImage img)
        {

            FileInfo fi = new FileInfo(FilePath);
            CreateListViewDataItem("FileName", lvData.Groups[0], FileName);
            CreateListViewDataItem("File Size", lvData.Groups[0], Utilities.BytesToString(fi.Length));
            CreateListViewDataItem("Image Size", lvData.Groups[0], $"{img.Size.Width} x {img.Size.Height}");
            CreateListViewDataItem("Width", lvData.Groups[0], img.Size.Width.ToString());
            CreateListViewDataItem("Height", lvData.Groups[0], img.Size.Height.ToString());
            CreateListViewDataItem("Horizontal Resolution", lvData.Groups[0], $"{img.Bitmap.HorizontalResolution} ppp");
            CreateListViewDataItem("Vertical Resolution", lvData.Groups[0], $"{img.Bitmap.VerticalResolution} ppp");
            CreateListViewDataItem("Pixel Format", lvData.Groups[0], img.Bitmap.PixelFormat.ToString());
            double mpx = Math.Round(img.Size.Width * img.Size.Height / 1000000.0, 2);
            CreateListViewDataItem("Megapixels", lvData.Groups[0], $"{mpx} MP");
            double aspectratio = Math.Round(((double)img.Size.Width / (double)img.Size.Height), 2);
            CreateListViewDataItem("Aspect Ratio", lvData.Groups[0], aspectratio.ToString(CultureInfo.InvariantCulture));

            CreateListViewDataItem("Creation Date", lvData.Groups[0], fi.CreationTime.ToString(CultureInfo.CurrentUICulture));
            CreateListViewDataItem("Last Modify Date", lvData.Groups[0], fi.LastWriteTime.ToString(CultureInfo.CurrentUICulture));

            CreateListViewDataItem("Contours", lvData.Groups[0], "0");
        }

        private ListViewItem CreateListViewDataItem(string name, ListViewGroup group, string value, bool addListView = true)
        {
            ListViewItem item = new ListViewItem
            {
                Text = name,
                Name = name.Replace(' ', '_'),
                Group = @group
            };
            item.SubItems.Add(value);

            if (addListView)
                lvData.Items.Add(item);
            return item;
        }
        #endregion

    }
}
