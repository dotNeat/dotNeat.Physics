namespace dotNeat.Physics.Measurements.Abstractions.SI
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ISQ;

    public interface IUnit
    {
        Enum ID { get; }
        string Name { get; }
        string Symbol {get; }
        PrefixID? PrefixId { get; }
        QuantityID QuantityId { get; }

        // Related alternative base unit properties:
        PrefixID? BasePrefixId { get; }
        Enum BaseUnitId { get; }
    }
}
