namespace dotNeat.Physics.Measurements.Abstractions.SI
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ISQ;

    public interface IUnit
    {
        Enum UnitID { get; }
        string Name { get; }
        PrefixID PrefixId { get; }
        QuantityID QuantityId { get; }

        // Related alternative base unit properties:
        PrefixID? BasePrefixId { get; }
        Enum BaseUnitId { get; }
    }
}
