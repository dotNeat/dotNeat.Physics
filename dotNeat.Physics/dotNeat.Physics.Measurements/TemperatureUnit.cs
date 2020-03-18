namespace dotNeat.Physics.Measurements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using dotNeat.Physics.Measurements.Abstractions;
    using dotNeat.Physics.Measurements.Abstractions.ISQ;
    using dotNeat.Physics.Measurements.Abstractions.SI;

    public class TemperatureUnit
        :MeasurementUnitBase<TemperatureUnit, TemperatureUnitID>
    {
        static TemperatureUnit()
        {
            TemperatureUnit.EnsureMetadataPresent(new TemperatureUnit[] {
                new TemperatureUnit(TemperatureUnitID.Kelvin),
                new TemperatureUnit(TemperatureUnitID.Celsius),
                new TemperatureUnit(TemperatureUnitID.Fahrenheit),
            });
        }
        private TemperatureUnit(TemperatureUnitID id) 
            : base(id, null, QuantityID.Temperature, null, TemperatureUnitID.Kelvin,  $"°{id.ToString().First()}")
        {
        }
    }
}
