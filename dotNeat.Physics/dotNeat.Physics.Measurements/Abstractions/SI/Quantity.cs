namespace dotNeat.Physics.Measurements.Abstractions.SI
{
    using System;

    //public class Quantity
    //    : SystemMetadata<Quantity, Enum>
    //{
    //    //NOTE: The base units/quantities have unique "Dimension Symbol" and "Definition" defined
    //    //      while the derived units/quantities do not have these properties defined
    //    //      However, the base units/quantities have extra properties defined: "In SI base units" (all) and "In other SI units" (almost all)
    //    private readonly string _dimensionSymbol;
    //    private readonly string _unitSymbol;
    //    private readonly object _unitID;

    //    static Quantity()
    //    {
    //        Quantity.EnsureMetadataPresent(new Quantity[] {
    //            new Quantity(BaseQuantityID.Time, "T", "s", null), 
    //            new Quantity(BaseQuantityID.Length, "L", "m", null), 
    //            new Quantity(BaseQuantityID.Mass, "M", "kg", null), 
    //            new Quantity(BaseQuantityID.ElectricCurrent, "I", "A", null), 
    //            new Quantity(BaseQuantityID.ThermodynamicTemperature, "Ɵ", "K", null), 
    //            new Quantity(BaseQuantityID.AmountOfSubstance, "N", "mol", null), 
    //            new Quantity(BaseQuantityID.LuminousIntensity, "J", "cd", null), 
    //        });
    //    }

    //    private Quantity(Enum id, string dimensionSymbol, string unitSymbol, object unitID)
    //        : base(id)
    //    {
    //        this._dimensionSymbol = dimensionSymbol;
    //        this._unitSymbol = unitSymbol;
    //        this._unitID = unitID;
    //    }

    //    public string DimensionSymbol => this._dimensionSymbol;
    //    public string UnitSymbol => this._unitSymbol;
    //}
}
