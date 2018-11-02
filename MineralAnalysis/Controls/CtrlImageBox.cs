using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Cyotek.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.Features2D;
using Emgu.Util;

namespace MineralAnalysis.Controls
{
    public partial class CtrlImageBox : UserControl, IDisposable
    {
        #region Enum
        public enum FilterAlgorithm : byte
        {
            Original,
            Gray_Filtered,
            Canny,
            Sobel,
            Laplace,
            Sobel_Heavy
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the parent tab page where all images are loaded
        /// </summary>
        private CtrlTabPage ParentTab { get; }

        /// <summary>
        /// Gets or sets a representive name of this image
        /// </summary>
        public string DescritiveName => Algorithm.ToString().Replace('_', ' ');

        /// <summary>
        /// Gets the ImageBox control associated to this control
        /// </summary>
        public ImageBox ImageBox { get; } = new ImageBox();

        public IImage ImageSource { get; private set; }
        public FilterAlgorithm Algorithm { get; private set; }
        #endregion

        #region Overrides

        public new void Dispose()
        {
            if(!ReferenceEquals(ImageSource, null))
                ImageSource.Dispose();

            ImageBox.Dispose();
            base.Dispose();
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="image"></param>
        /// <param name="parentTab"></param>
        public CtrlImageBox(FilterAlgorithm algorithm, CtrlTabPage parentTab)
        { 
            if (ReferenceEquals(parentTab, null))
                throw new ArgumentNullException(nameof(parentTab));

            Algorithm = algorithm;

            InitializeComponent();

            tsBarLabelName.Text = DescritiveName;
            ImageBox.Dock = DockStyle.Fill;

            ImageBox.AllowClickZoom = true;
            ImageBox.AutoPan = true;
            ImageBox.AllowZoom = true;
            ImageBox.AutoCenter = true;
            ImageBox.AutoScroll = true;
            //ImageBox.ImageBorderStyle = ImageBoxBorderStyle.FixedSingle;
            //ImageBox.ImageBorderColor = Color.Black;
            Controls.Add(ImageBox);

            //ImageBox.ZoomChanged += (sender, args) => SyncImages();
            //ImageBox.Scroll += (sender, args) => SyncImages();
            ImageBox.Invalidated += (sender, args) =>
            {
                if (!ImageBox.Disposing)
                    SyncImages();
            };
            //ImageBox. += (sender, args) => SyncImages();
            ImageBox.MouseMove += (sender, args) =>
            {
                ParentTab.ImageCursorLocation = ImageBox.IsPointInImage(args.Location) ? ImageBox.PointToImage(args.Location) : Point.Empty;
                Program.FrmMain.UpdateStatusBar();
            };

            ParentTab = parentTab;

            switch (algorithm)
            {
                case FilterAlgorithm.Original:
                    ClearExtraActions();
                    tsActionsLabelMS.Visible = false;
                    break;
                case FilterAlgorithm.Gray_Filtered:
                    ClearExtraActions();
                    tsActionsLabelMS.Visible = false;
                    break;
                case FilterAlgorithm.Canny:
                    tsActionLabel1.Text = "Threshold";
                    tsActionLabel1.ToolTipText =
                        tsActionsTextbox1.ToolTipText = "The threshhold to find initial segments of strong edges";
                    tsActionsTextbox1.Text = "200";

                    tsActionLabel2.Text = "Threshold Link";
                    tsActionLabel2.ToolTipText =
                        tsActionsTextbox2.ToolTipText = "The threshold used for edge Linking";
                    tsActionsTextbox2.Text = "100";

                    tsActionLabel3.Text = "Aperture Size";
                    tsActionLabel3.ToolTipText =
                        tsActionsTextbox3.ToolTipText = "The aperture size for the Sobel operator";
                    tsActionsTextbox3.Text = "3";

                    tsActionsLabel4.Text = "L2gradient";
                    tsActionsLabel4.ToolTipText =
                        tsActionsCombobox1.ToolTipText = "Use a more accurate norm to calculate the image gradient magnitude";
                    tsActionsCombobox1.Items.Add("No");
                    tsActionsCombobox1.Items.Add("Yes");
                    tsActionsCombobox1.SelectedIndex = 0;
                    break;
                case FilterAlgorithm.Sobel:
                    tsActionLabel1.Text = "X Order";
                    tsActionLabel1.ToolTipText =
                        tsActionsTextbox1.ToolTipText = "Order of the derivative x";
                    tsActionsTextbox1.Text = "1";

                    tsActionLabel2.Text = "Y Order";
                    tsActionLabel2.ToolTipText =
                        tsActionsTextbox2.ToolTipText = "Order of the derivative y";
                    tsActionsTextbox2.Text = "0";

                    tsActionLabel3.Dispose();
                    tsActionsTextbox3.Dispose();

                    tsActionsLabel4.Text = "Aperture Size";
                    tsActionsLabel4.ToolTipText =
                        tsActionsCombobox1.ToolTipText = "Size of the extended Sobel kernel, must be 1, 3, 5 or 7. In all cases except 1, aperture_size xaperture_size separable kernel will be used to calculate the derivative.";


                    for (int i = 1; i <= 31; i += 2)
                    {
                        tsActionsCombobox1.Items.Add(i.ToString());
                    }

                    tsActionsCombobox1.SelectedIndex = 2;
                    break;
                case FilterAlgorithm.Laplace:
                    tsActionLabel1.Dispose();
                    tsActionLabel2.Dispose();
                    tsActionLabel3.Dispose();


                    tsActionsTextbox1.Dispose();
                    tsActionsTextbox2.Dispose();
                    tsActionsTextbox3.Dispose();

                    tsActionsLabel4.Text = "Aperture Size";
                    tsActionsLabel4.ToolTipText =
                        tsActionsCombobox1.ToolTipText = "Size of the extended Sobel kernel, must be 1, 3, 5 or 7. In all cases except 1, aperture_size xaperture_size separable kernel will be used to calculate the derivative.";
                    
                    for (int i = 1; i <= 31; i += 2)
                    {
                        tsActionsCombobox1.Items.Add(i.ToString());
                    }

                    tsActionsCombobox1.SelectedIndex = 2;

                    break;
                case FilterAlgorithm.Sobel_Heavy:
                    ClearExtraActions();
                    break;
            }

            LoadImage();
        }
        #endregion

        #region Methods

        /// <summary>
        /// Clear all extra parameters at action bar
        /// </summary>
        private void ClearExtraActions()
        {
            tsActionLabel1.Dispose();
            tsActionLabel2.Dispose();
            tsActionLabel3.Dispose();
            tsActionsLabel4.Dispose();
            tsActionsTextbox1.Dispose();
            tsActionsTextbox2.Dispose();
            tsActionsTextbox3.Dispose();
            tsActionsCombobox1.Dispose();
            tsActionsBtnFilterApply.Dispose();
        }

        /// <summary>
        /// Load image into ImageBox acording to the applyed filter
        /// </summary>
        private void LoadImage()
        {
            try
            {
                ImageSource?.Dispose();
                Stopwatch watch = Stopwatch.StartNew();
                switch (Algorithm)
                {
                    case FilterAlgorithm.Original:
                        ImageSource = ParentTab.ImgOriginal;
                        break;
                    case FilterAlgorithm.Gray_Filtered:
                        ImageSource = ParentTab.ImgGray;
                        break;
                    case FilterAlgorithm.Canny:
                        var image = ParentTab.ImgGray.Canny(Convert.ToDouble(tsActionsTextbox1.Text), Convert.ToDouble(tsActionsTextbox2.Text), Convert.ToInt32(tsActionsTextbox3.Text), tsActionsCombobox1.SelectedItem.ToString().Equals("Yes"));
                        /*LineSegment2D[][] lines = image.HoughLinesBinary(
                            10, //Distance resolution in pixel-related units
                            Math.PI / 45.0, //Angle resolution measured in radians.
                            50, //threshold
                            10, //min Line width
                            5); //gap between lines
                        Image<Bgr, Byte> lineImage = ParentTab.ImgOriginal.CopyBlank();
                        foreach (LineSegment2D line in lines[0])
                            lineImage.Draw(line, new Bgr(Color.Green), 2);

                        ImageSource = lineImage;*/

                        // Contours
                        List<VectorOfPoint> contoursArray = OpenCVUtilities.FindContours(image);
                        VectorOfPoint largest = OpenCVUtilities.FindLargestContour(image.Mat);
                        //ParentTab.ImgGray.Draw(largest.ToArray(), new Gray(5), 5);
                        //MessageBox.Show(largest.Size.ToString());
                        ParentTab.lvData.Items["Contours"].SubItems[1].Text = contoursArray.Count.ToString();




                        ImageSource = image;
                        break;
                    case FilterAlgorithm.Sobel:
                        ImageSource = ParentTab.ImgGray.Sobel(Convert.ToInt32(tsActionsTextbox1.Text),
                            Convert.ToInt32(tsActionsTextbox2.Text), Convert.ToInt32(tsActionsCombobox1.SelectedItem));
                        break;
                    case FilterAlgorithm.Laplace:
                        ImageSource = ParentTab.ImgGray.Laplace(Convert.ToInt32(tsActionsCombobox1.SelectedItem));
                        break;
                    case FilterAlgorithm.Sobel_Heavy:
                        ImageSource = ParentTab.ImgGray.Sobel(0, 1, 3).Add(ParentTab.ImgGray.Sobel(1, 0, 3)).AbsDiff(new Gray(0.0));
                        break;
                }

                ImageBox.Image = ImageSource.Bitmap;
                watch.Stop();
                tsActionsLabelMS.Text = $"{watch.ElapsedMilliseconds}ms";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
        /// <summary>
        /// Sync all images to be at same zoom and position
        /// </summary>
        private void SyncImages()
        {
            if (ReferenceEquals(ParentTab, null) || ParentTab.SuspendEvents) return;
            ParentTab.SuspendEvents = true;
            foreach (var ctrlImageBox in ParentTab.ImageBoxs)
            {
                if (ReferenceEquals(ctrlImageBox, this))
                    continue;

                ctrlImageBox.ImageBox.Zoom = ImageBox.Zoom;
                ctrlImageBox.ImageBox.AutoScrollPosition = new Point(Math.Abs(ImageBox.AutoScrollPosition.X), Math.Abs(ImageBox.AutoScrollPosition.Y));
            }

            Program.FrmMain.UpdateStatusBar();
            ParentTab.SuspendEvents = false;
        }
        #endregion

        #region Events
        private void EventClick(object sender, EventArgs e)
        {
            if (ReferenceEquals(sender, tsBarBtnSave))
            {
                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    dialog.OverwritePrompt = true;
                    dialog.FileName = $"{ParentTab.FileNameWithoutExtension}_{DescritiveName}";
                    dialog.DefaultExt = ParentTab.FileExtension;
                    dialog.AddExtension = true;
                    dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        ImageBox.Image.Save(dialog.FileName);
                    }
                }
                return;
            }
            if (ReferenceEquals(sender, tsActionsBtnFilterApply))
            {
                LoadImage();
                return;
            }
        }

        private void EventKeyPress(object sender, KeyPressEventArgs e)
        {
            if (ReferenceEquals(sender, tsActionsTextbox1) || ReferenceEquals(sender, tsActionsTextbox2) ||
                ReferenceEquals(sender, tsActionsTextbox3))
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    e.KeyChar != '.')
                {
                    e.Handled = true;
                }

                // only allow one decimal point
                if (e.KeyChar == '.' && (sender as ToolStripTextBox).Text.IndexOf('.') > -1)
                {
                    e.Handled = true;
                }
                return;
            }
        }

        private void EventKeyUp(object sender, KeyEventArgs e)
        {
            if (ReferenceEquals(sender, tsActionsTextbox1) || ReferenceEquals(sender, tsActionsTextbox2) ||
                ReferenceEquals(sender, tsActionsTextbox3) || ReferenceEquals(sender, tsActionsCombobox1))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    tsActionsBtnFilterApply.PerformClick();
                    e.Handled = true;
                }
                return;
            }
        }

        #endregion


    }
}
