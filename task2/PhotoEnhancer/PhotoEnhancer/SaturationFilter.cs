using System;
using PhotoEnhancer;

namespace PhotoEnhancer.Filters.Transformations
{
    public class SaturationFilter : IFilter
    {
        public string Name => "Насыщенность";

        public ParameterInfo[] GetParametersInfo()
        {
            return new[]
            {
                new ParameterInfo
                {
                    Name = "Коэффициент (k)",
                    MinValue = 0,
                    MaxValue = 10,
                    Increment = 0.05,
                    DefaultValue = 1
                }
            };
        }

        public Photo Process(Photo original, double[] parameters)
        {
            double k = parameters[0];
            var result = new Photo(original.Width, original.Height);

            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    var pixel = original[x, y];
                    var hsl = Convertors.RGBToHSL(pixel);
                    hsl.S = hsl.S * k;
                    if (hsl.S > 1) hsl.S = 1;
                    if (hsl.S < 0) hsl.S = 0;
                    var newPixel = Convertors.HSLToRGB(hsl);

                    // Clamping RGB values between 0 and 1
                    newPixel = new Pixel(
                        Clamp(newPixel.R),
                        Clamp(newPixel.G),
                        Clamp(newPixel.B)
                    );

                    result[x, y] = newPixel;
                }
            }

            return result;
        }

        private double Clamp(double value)
        {
            if (value < 0) return 0;
            if (value > 1) return 1;
            return value;
        }
    }
}
