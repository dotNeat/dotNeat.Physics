namespace dotNeat.Physics.Measurements.Abstractions.ISQ
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public enum QuantityID
        : byte
    {
        // Base quantities:
        Length,
        Mass,
        Time,
        ElectricCurrent,
        Temperature,
        AmountOfSubstance,
        LuminousIntensity,

        // Derived quantities:
        Absement,
        AbsorbedDoseRate,
        //TODO continue from https://en.wikipedia.org/wiki/List_of_physical_quantities ...
    }
}
