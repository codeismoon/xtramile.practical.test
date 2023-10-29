namespace XtramilePractical.Utilities
{
    public class TemperatureConverter : ITemperatureConverter
    {
        public double FahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * (5 / 9);
        }
    }
}
