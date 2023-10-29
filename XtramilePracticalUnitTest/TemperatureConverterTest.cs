using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace XtramilePracticalUnitTest
{
    [TestClass]
    public class TemperatureConverterTest
    {
        private readonly ITemperatureConverter _temperatureConverter;

        public TemperatureConverterTest(ITemperatureConverter temperatureConverter)
        {
                _temperatureConverter = temperatureConverter;
        }

        [TestMethod]
        public void FahrenheitToCelsiusConversionTest()
        {
            double result = _temperatureConverter.ConvertTemperatureToCelsius(32);

            Assert.AreEqual(0, result, 0.001);
        }
    }
}
