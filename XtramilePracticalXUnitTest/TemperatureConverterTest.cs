using System;
using XtramilePractical.Utilities;
using Xunit;

namespace XtramilePracticalXUnitTest
{
    public class TemperatureConverterTest
    {
        private readonly ITemperatureConverter _temperatureConverter;

        public TemperatureConverterTest(ITemperatureConverter temperatureConverter)
        {
            _temperatureConverter = temperatureConverter;
        }

        [Fact]
        public void TestConvertFahrenheit()
        {
            double result = _temperatureConverter.FahrenheitToCelsius(32);

            Assert.Equal(0, result, 3);
        }
    }
}
