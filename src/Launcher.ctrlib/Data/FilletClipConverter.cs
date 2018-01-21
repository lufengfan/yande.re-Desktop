using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Launcher.Controls.Data
{
    public class FilletClipConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double actualHeight;
            double actualWidth;
            CornerRadius cornerRadius;
            try
            {
                actualHeight = (double)values[0];
                actualWidth = (double)values[1];
                cornerRadius = ((CornerRadius)values[2]);
            }
            catch (Exception)
            {
                actualHeight = 160;
                actualWidth = 240;
                cornerRadius = (CornerRadius)FilletPanel.CornerRadiusProperty.DefaultMetadata.DefaultValue;
            }

            double crBottomRight = cornerRadius.BottomRight;
            Point pRightBottom = new Point(actualWidth, actualHeight - crBottomRight);
            Point pBottomRight = new Point(actualWidth - crBottomRight, actualHeight);
            Size arcSizeBottomRight = new Size(crBottomRight, crBottomRight);

            double crBottomLeft = cornerRadius.BottomLeft;
            Point pBottomLeft = new Point(crBottomLeft, actualHeight);
            Point pLeftBottom = new Point(0, actualHeight - crBottomLeft);
            Size arcSizeBottomLeft = new Size(crBottomLeft, crBottomLeft);

            double crTopLeft = cornerRadius.TopLeft;
            Point pLeftTop = new Point(0, crTopLeft);
            Point pTopLeft = new Point(crTopLeft, 0);
            Size arcSizeTopLeft = new Size(crTopLeft, crTopLeft);

            double crTopRight = cornerRadius.TopRight;
            Point pTopRight = new Point(actualWidth - crTopRight, 0);
            Point pRightTop = new Point(actualWidth, crTopRight);
            Size arcSizeTopRight = new Size(crTopRight, crTopRight);

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
                            new ArcSegment(pTopRight, arcSizeTopRight, 90.0, false, SweepDirection.Counterclockwise, true),
                            new LineSegment(pTopLeft, true),
                            new ArcSegment(pLeftTop, arcSizeTopLeft, 90.0, false, SweepDirection.Counterclockwise, true),
                            new LineSegment(pLeftBottom, true),
                            new ArcSegment(pBottomLeft, arcSizeBottomLeft, 90.0, false, SweepDirection.Counterclockwise, true),
                            new LineSegment(pBottomRight, true),
                            new ArcSegment(pRightBottom, arcSizeBottomRight, 90.0, false, SweepDirection.Counterclockwise, true)
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
