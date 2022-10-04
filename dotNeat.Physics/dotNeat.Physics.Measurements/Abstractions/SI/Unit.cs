namespace dotNeat.Physics.Measurements.Abstractions.SI
{
    using System;
    using ISQ;

    public class Unit//<TValue>
        //: IUnit<TValue>
        //where TValue : IEquatable<TValue>, IComparable<TValue>, IComparable
    {
        private readonly Prefix _prefix;
        private readonly Quantity _quantity;

        public Prefix Prefix {  get { return this._prefix; } }
        public Quantity Quantity { get { return this._quantity; } }

        public Unit(Prefix prefix, Quantity quantity)
        {
            this._prefix = prefix;
            this._quantity = quantity;
        }

        //public Enum ID { get; }
        //public string Name { get; }
        //public string Symbol { get; }
        //public PrefixID? PrefixId { get; }
        //public QuantityID QuantityId { get; }
        //public PrefixID? BasePrefixId { get; }
        //public Enum BaseUnitId { get; }
        //public Func<TValue, TValue> ToBaseUnitValue { get; }
        //public Func<TValue, TValue> FromBaseUnitValue { get; }
    }
}
