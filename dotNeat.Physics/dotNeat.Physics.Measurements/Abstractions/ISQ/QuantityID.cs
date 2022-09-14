namespace dotNeat.Physics.Measurements.Abstractions.ISQ
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public enum QuantityID
    {
        // Base quantities:
        Length,
        Mass,
        Time,
        ElectricCurrent,
        Temperature,
        AmountOfSubstance,
        LuminousIntensity,

        // Supplementary quantities:
        PlaneAngle,
        SolidAngle,

        // Derived quantities:
        Absement,
        AbsorbedDoseRate,
        Acceleration,
        AngularAcceleration,
        AngularMomentum,
        AngularVelocity,
        Area,
        AreaMassDensity,
        Capacitance,
        CatalyticActivityConcentration,
        CentrifugalForce,
        ChemicalPotential,
        Crackle,
        CurrentDensity,
        DoseEquivalent,
        DynamicViscosity,
        ElectricCharge,
        ElectricChrageDensity,
        ElectricDipoleMoment,
        ElectricDisplacementField,
        //TODO continue from https://en.wikipedia.org/wiki/List_of_physical_quantities ...
    }
}
