using PhotoEnhancer;

namespace PhotoEnhancer.Filters.Transformations
{
    public class SkewParameters : IParameters
    {
        public double Angle { get; set; }

        public ParameterInfo[] GetDescription()
        {
            return new[]
            {
                new ParameterInfo
                {
                    Name = "Угол (α)",
                    MinValue = 0,
                    MaxValue = 85,
                    Increment = 5,
                    DefaultValue = 0
                }
            };
        }

        public void SetValues(double[] values)
        {
            Angle = values[0];
        }
    }
}
