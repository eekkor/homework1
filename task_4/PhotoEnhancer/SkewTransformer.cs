using System;
using System.Drawing;
using PhotoEnhancer;

namespace PhotoEnhancer.Filters.Transformations
{
    public class SkewTransformer : ITransformer<SkewParameters>
    {
        private double tanAlpha;

        public void Initialize(SkewParameters parameters)
        {
            tanAlpha = Math.Tan(parameters.Angle * Math.PI / 180);
        }

        public Size GetTransformedSize(Size oldSize)
        {
            int newWidth = oldSize.Width + (int)(oldSize.Height * tanAlpha);
            return new Size(newWidth, oldSize.Height);
        }

        public Point? MapPoint(Point newPoint, Size oldSize)
        {
            int oldX = (int)(newPoint.X - newPoint.Y * tanAlpha);
            int oldY = newPoint.Y;

            if (oldX < 0 || oldX >= oldSize.Width)
                return null;

            return new Point(oldX, oldY);
        }
    }
}
