namespace dotNeat.Physics.Measurements.Abstractions.ISQ
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using SI;
    #nullable enable

    public class Quantity
        : SystemMetadata<Quantity, QuantityID>
        , IQuantity
    {
        private readonly string _name;
        private readonly string? _symbol;
        private readonly string _description;
        private readonly string _dimension;
        private readonly string? _comment;
        private readonly IUnit _siUnit;
        private readonly bool _isBaseQuantity;

        static Quantity()
        {
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
        }

        #region Implementation of IQuantity

        public string Name
        {
            get { return this._name; }
        }
        public string? Symbol
        {
            get { return this._symbol; }
        }
        public string Description
        {
            get { return this._description; }
        }
        public string Dimension
        {
            get { return this._dimension; }
        }
        public string? Comment
        {
            get { return this._comment; }
        }
        public IUnit SIUnit
        {
            get { return this._siUnit; }
        }

        public bool IsBaseQuantity
        {
            get { return this._isBaseQuantity; }
        }

        #endregion Implementation of IQuantity
    }
}
