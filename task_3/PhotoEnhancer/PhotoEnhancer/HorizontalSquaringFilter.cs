using System;
using PhotoEnhancer;

namespace PhotoEnhancer.Filters.Transformations
{
    public class HorizontalSquaringFilter : TransformFilter<EmptyParameters>
    {
        public HorizontalSquaringFilter() : base("Квадратура по горизонтали",
            (point, size) =>
            {
                int newX = (int)(point.X * ((double)Math.Max(size.Width, size.Height) / size.Width));
                int newY = (int)(point.Y * ((double)Math.Max(size.Width, size.Height) / size.Height));
                return new Point(newX, newY);
            })
        { }
    }
}
