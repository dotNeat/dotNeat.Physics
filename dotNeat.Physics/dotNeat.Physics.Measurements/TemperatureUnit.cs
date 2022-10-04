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
        :MeasurementUnitBase<TemperatureUnit, TemperatureUnitID, double>
    {
        static TemperatureUnit()
        {
            TemperatureUnit.EnsureMetadataPresent(new TemperatureUnit[] {
                new TemperatureUnit(
                    id:             TemperatureUnitID.Kelvin,
                    toBaseUnit:     (v) => v, 
                    fromBaseUnit:   (v) => v
                    ),
                new TemperatureUnit(
                    id:             TemperatureUnitID.Celsius, 
                    toBaseUnit:     (v) => (v + 273.15), 
                    fromBaseUnit:   (v) => (v - 273.15)
                    ),
                new TemperatureUnit(
                    id:             TemperatureUnitID.Fahrenheit, 
                    toBaseUnit:     (v) => (((v + 459.67) * 5) / 9), 
                    fromBaseUnit:   (v) => (((v * 5) / 9) - 459.67)
                    ),
            });
        }
        private TemperatureUnit(
            TemperatureUnitID id,
            Func<double, double> toBaseUnit,
            Func<double, double> fromBaseUnit
            ) 
            : base(id, null, QuantityID.Temperature, null, TemperatureUnitID.Kelvin,  $"°{id.ToString().First()}", toBaseUnit, fromBaseUnit)
        {
        }
    }
}
