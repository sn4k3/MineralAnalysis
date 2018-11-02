using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace MineralAnalysis
{
    public static class OpenCVUtilities
    {
        public static List<VectorOfPoint> FindContours(Image<Gray, byte> image, RetrType retrType = RetrType.List, ChainApproxMethod chainApproxMethod = ChainApproxMethod.ChainApproxSimple)
        {
            // Contours
            VectorOfVectorOfPoint contoursDetected = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(image, contoursDetected, null, retrType, chainApproxMethod);
            var contoursArray = new List<VectorOfPoint>();
            int count = contoursDetected.Size;
            for (int i = 0; i < count; i++)
            {
                using (VectorOfPoint currContour = contoursDetected[i])
                {
                    contoursArray.Add(currContour);
                }
            }
            
            return contoursArray;
        }


        public static VectorOfPoint FindLargestContour(IInputOutputArray cannyEdges, IInputOutputArray result = null)
        {
            int largest_contour_index = 0;
            double largest_area = 0;
            VectorOfPoint largestContour;

            using (Mat hierachy = new Mat())
            using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
            {
                CvInvoke.FindContours(cannyEdges, contours, hierachy, RetrType.Tree, ChainApproxMethod.ChainApproxNone);

                if (contours.Size == 0)
                    return null;

                for (int i = 0; i < contours.Size; i++)
                {
                    MCvScalar color = new MCvScalar(0, 0, 255);

                    double a = CvInvoke.ContourArea(contours[i], false);  //  Find the area of contour
                    if (a > largest_area)
                    {
                        largest_area = a;
                        largest_contour_index = i;                //Store the index of largest contour
                    }

                    if(!ReferenceEquals(result, null))
                        CvInvoke.DrawContours(result, contours, largest_contour_index, new MCvScalar(255, 0, 0));
                }

                if (!ReferenceEquals(result, null))
                    CvInvoke.DrawContours(result, contours, largest_contour_index, new MCvScalar(0, 0, 255), 3, LineType.EightConnected, hierachy);

                largestContour = new VectorOfPoint(contours[largest_contour_index].ToArray());
            }

            return largestContour;
        }
    }


}
