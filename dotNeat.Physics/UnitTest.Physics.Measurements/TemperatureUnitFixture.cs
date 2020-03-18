namespace UnitTest.Physics.Measurements
{
    using System;
    using System.Diagnostics;
    using dotNeat.Physics.Measurements;
    using isq = dotNeat.Physics.Measurements.Abstractions.ISQ;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TemperatureUnitFixture
    {
        [TestMethod]
        public void QuickVisualTest()
        {
            foreach(var unit in TemperatureUnit.Set)
            {
                Trace.WriteLine(string.Empty);
                Console.WriteLine();

                Trace.WriteLine(unit);
                Console.WriteLine(unit);

                var quantity = isq.Quantity.Get(unit.QuantityId);
                Trace.WriteLine(quantity);
                Console.WriteLine(quantity);

            }
        }

    }
}
