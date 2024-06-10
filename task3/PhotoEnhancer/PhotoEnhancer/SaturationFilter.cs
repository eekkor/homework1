using System;
using PhotoEnhancer;

namespace PhotoEnhancer.Filters.Transformations
{
    public class SaturationParameters
    {
        public double Coefficient { get; set; }
    }

    public class SaturationFilter : PixelFilter<SaturationParameters>
    {
        public SaturationFilter() : base("Насыщенность",
            (pixel, parameters) =>
            {
                var hsl = Convertors.RGBToHSL(pixel);
                hsl.S = hsl.S * parameters.Coefficient;
                hsl.S = Math.Clamp(hsl.S, 0, 1);
                var newPixel = Convertors.HSLToRGB(hsl);
                return new Pixel(
                    Math.Clamp(newPixel.R, 0, 1),
                    Math.Clamp(newPixel.G, 0, 1),
                    Math.Clamp(newPixel.B, 0, 1));
            })
        { }
    }
}
