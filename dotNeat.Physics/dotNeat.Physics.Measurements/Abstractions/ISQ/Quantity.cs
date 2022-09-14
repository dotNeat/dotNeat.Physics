namespace dotNeat.Physics.Measurements.Abstractions.ISQ
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Diagnostics;
    using SI;
    #nullable enable

    public class Quantity
        : SystemMetadata<Quantity, QuantityID>
        , IQuantity
    {
        #region Static members

        public static readonly QuantityID[] BaseQuantityIDs;
        public static readonly QuantityID[] SupplementaryQuantityIDs;
        public static readonly QuantityID[] DerivedQuantityIDs;

        static Quantity()
        {
            Quantity.BaseQuantityIDs = new QuantityID[]
            {
                QuantityID.Length,
                QuantityID.Mass,
                QuantityID.Time,
                QuantityID.ElectricCurrent,
                QuantityID.Temperature,
                QuantityID.AmountOfSubstance,
                QuantityID.LuminousIntensity,
            };

            Quantity.SupplementaryQuantityIDs = new QuantityID[]
            {
                QuantityID.PlaneAngle,
                QuantityID.SolidAngle,
            };

            Quantity.DerivedQuantityIDs = new QuantityID[]
            {
               QuantityID.Absement,
               QuantityID.AbsorbedDoseRate,
               QuantityID.Acceleration,
               QuantityID.AngularAcceleration,
               QuantityID.AngularMomentum,
               QuantityID.AngularVelocity,
               QuantityID.Area,
               QuantityID.AreaMassDensity,
               QuantityID.Capacitance,
               QuantityID.CatalyticActivityConcentration,
               QuantityID.CentrifugalForce,
               QuantityID.ChemicalPotential,
               QuantityID.Crackle,
               QuantityID.CurrentDensity,
               QuantityID.DoseEquivalent,
               QuantityID.DynamicViscosity,
               QuantityID.ElectricCharge,
               QuantityID.ElectricChrageDensity,
               QuantityID.ElectricDipoleMoment,
               QuantityID.ElectricDisplacementField,
               //TODO: complete the list...
            };

            Debug.Assert(Enum.GetValues(typeof(QuantityID)).Length ==
                Quantity.BaseQuantityIDs.Length
                + Quantity.SupplementaryQuantityIDs.Length
                + Quantity.DerivedQuantityIDs.Length,
                $"Total number of {nameof(QuantityID)} values must match!"
                );

            Quantity.EnsureMetadataPresent( new Quantity[]
                {
                    // Base quantities:
                    new Quantity(
                        QuantityID.Length, 
                        "Length", 
                        "l", 
                        "The one-dimensional extent of an object", 
                        "L", 
                        null,
                        null, //metre IUnit
                        true
                        ), 
                    new Quantity(
                        QuantityID.Mass, 
                        "Mass", 
                        "m", 
                        "A measure of resistance to acceleration", 
                        "M", 
                        "extensive, scalar",
                        null, //kilogram IUnit
                        true
                        ), 
                    new Quantity(
                        QuantityID.Time, 
                        "Time", 
                        "t", 
                        "A duration of an event", 
                        "T", 
                        "scalar",
                        null, //second IUnit
                        true
                    ), 
                    new Quantity(
                        QuantityID.ElectricCurrent, 
                        "Electric Current", 
                        "I", 
                        "Rate of flow of electrical charge per unit of time", 
                        "I", 
                        null,
                        null, //ampere IUnit
                        true
                    ), 
                    new Quantity(
                        QuantityID.Temperature, 
                        "Temperature", 
                        "T", 
                        "Average potential energy per degree of freedom of a system", 
                        "Ɵ", 
                        "intensive, vector",
                        null, //kelvin IUnit
                        true
                    ), 
                    new Quantity(
                        QuantityID.AmountOfSubstance, 
                        "Amount of Substance", 
                        "n", 
                        "Number of particles compared to the number of atoms in 0.12 kg of C", 
                        "N", 
                        "extensive, scalar",
                        null, //mole IUnit
                        true
                    ), 
                    new Quantity(
                        QuantityID.LuminousIntensity, 
                        "Luminous Intensity", 
                        "L", 
                        "Wavelenght-weighted power of emitted light per unit of solid angle", 
                        "J", 
                        "scalar",
                        null, //candela IUnit
                        true
                    ),

                    // Supplementary quantities:
                    new Quantity(
                        QuantityID.PlaneAngle,
                        "Plane Angle",
                        "ϴ",
                        "Ratio of circular arc length to radius",
                        "1",
                        String.Empty,
                        null, //radian (rad) IUnit
                        true
                    ),
                    new Quantity(
                        QuantityID.SolidAngle,
                        "Solid Angle",
                        "Ω",
                        "Ratio of area on a sphere to its radius squared",
                        "1",
                        String.Empty,
                        null, //steradian (sr) IUnit
                        true
                    ),

                    // Derived quantities:
                    new Quantity(
                        QuantityID.Absement, 
                        "Absement", 
                        "A", 
                        "Measure of sustained displacement: the first integral of displacement", 
                        "LT", 
                        "vector",
                        null //m*s IUnit
                    ), 


                    //TODO: complete the list based on https://en.wikipedia.org/wiki/List_of_physical_quantities
                });
        }

        #endregion Static members

        #region Instance members

        public string Name { get; private set; }
        public string? Symbol { get; private set; }
        public string Description { get; private set; }
        public string Dimension { get; private set; }
        public string? Comment { get; private set; }
        public IUnit SIUnit { get; private set; }
        public bool IsBaseQuantity { get; private set; }

        private Quantity(
            QuantityID id, 
            string name, 
            string? symbol, 
            string description, 
            string dimension, 
            string? comment, 
            IUnit siUnit,
            bool isBaseQuantity = false) 
            : base(id)
        {
            this.Name = name;
            this.Symbol = symbol;
            this.Description = description;
            this.Dimension = dimension;
            this.Comment = comment;
            this.SIUnit = siUnit;
            this.IsBaseQuantity = isBaseQuantity;
        }

        public override string ToString()
        {
            string suffix = this.IsBaseQuantity ? "(base quantity)" : string.Empty;
            return $"{this.Name} ({this.Symbol}): {this.Description}, [{this.Dimension}] {suffix}";
        }

        #endregion Instance members
    }
}
