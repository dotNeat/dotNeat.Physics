namespace UnitTest.Physics.Measurements
{
    using System;
    using System.Diagnostics;
    using dotNeat.Physics.Measurements;
    using dotNeat.Physics.Measurements.Abstractions.SI;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TemperatureFixture
    {
        [TestMethod]
        public void BasicTest()
        {
            TemperatureUnitID defaultUnit = TemperatureUnitID.Kelvin;
            Temperature measurement = new Temperature(0);
            Console.WriteLine($"Temperature: {measurement}");
            Trace.WriteLine($"Temperature: {measurement}");
            Assert.AreEqual(defaultUnit, measurement.BaseUnit);

            Temperature tF = new Temperature(32, TemperatureUnitID.Fahrenheit);
            Temperature tC = new Temperature(0, TemperatureUnitID.Celsius);
            Trace.WriteLine(tF);
            Trace.WriteLine(tC);
            Assert.AreEqual(tF, tC);

            Assert.AreNotEqual(new Temperature(32, TemperatureUnitID.Fahrenheit), new Temperature(-1, TemperatureUnitID.Celsius));
            Assert.AreEqual(new Temperature(32, TemperatureUnitID.Fahrenheit), new Temperature(0, TemperatureUnitID.Celsius));
            Assert.AreNotEqual(new Temperature(32, TemperatureUnitID.Fahrenheit), new Temperature(1, TemperatureUnitID.Celsius));
        }
    }
}
