using Launcher.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Launcher.Data
{
    public class ChamferClipConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double actualHeight;
            double actualWidth;
            CornerSize cornerSize;
            try
            {
                actualHeight = (double)values[0];
                actualWidth = (double)values[1];
                cornerSize = ((CornerSize)values[2]);
            }
            catch (Exception)
            {
                actualHeight = 0.0;
                actualWidth = 0.0;
                cornerSize = (CornerSize)ChamferPanel.CornerSizeProperty.DefaultMetadata.DefaultValue;
            }

            Size csBottomRight = cornerSize.BottomRight;
            Point pRightBottom = new Point(actualWidth, actualHeight - csBottomRight.Height);
            Point pBottomRight = new Point(actualWidth - csBottomRight.Width, actualHeight);

            Size csBottomLeft = cornerSize.BottomLeft;
            Point pBottomLeft = new Point(csBottomLeft.Width, actualHeight);
            Point pLeftBottom = new Point(0, actualHeight - csBottomLeft.Height);

            Size csTopLeft = cornerSize.TopLeft;
            Point pLeftTop = new Point(0, csTopLeft.Height);
            Point pTopLeft = new Point(csTopLeft.Width, 0);
            
            Size csTopRight = cornerSize.TopRight;
            Point pTopRight = new Point(actualWidth - csTopRight.Width, 0);
            Point pRightTop = new Point(actualWidth, csTopRight.Height);

            PathGeometry geometry = new PathGeometry()
            {
                Figures = new PathFigureCollection()
                {
                    new PathFigure()
                    {
                        StartPoint = pRightBottom,
                        IsClosed = true,
                        IsFilled = true,
                        Segments = new PathSegmentCollection()
                        {
                            new LineSegment(pRightTop, true),
                            new LineSegment(pTopRight, true),
                            new LineSegment(pTopLeft, true),
                            new LineSegment(pLeftTop, true),
                            new LineSegment(pLeftBottom, true),
                            new LineSegment(pBottomLeft, true),
                            new LineSegment(pBottomRight, true),
                            new LineSegment(pRightBottom, true)
                        }
                    }
                }
            };
            return geometry;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
