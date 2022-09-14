namespace dotNeat.Physics.Measurements.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using dotNeat.Physics.Measurements.Abstractions.ISQ;
    using dotNeat.Physics.Measurements.Abstractions.SI;

        public abstract class MeasurementUnitBase<TMeasurementUnit, TMeasurementUnitID>
        :SystemMetadata<TMeasurementUnit, TMeasurementUnitID>
        , IUnit
        where TMeasurementUnit : MeasurementUnitBase<TMeasurementUnit, TMeasurementUnitID>
        where TMeasurementUnitID : Enum
    {
        protected MeasurementUnitBase(
            TMeasurementUnitID id, 
            PrefixID? prefixId, 
            QuantityID quantityId, 
            PrefixID? basePrefixId, 
            Enum baseUnitId,
            string symbol) 
            : this(id, id.ToString(), prefixId, quantityId, basePrefixId, baseUnitId, symbol)
        {

        }

        protected MeasurementUnitBase(
            TMeasurementUnitID id, 
            string name, 
            PrefixID? prefixId, 
            QuantityID quantityId, 
            PrefixID? basePrefixId, 
            Enum baseUnitId,
            string symbol) 
            : base(id)
        {
            this.Name = name;
            this.PrefixId = prefixId;
            this.QuantityId = quantityId;
            this.BasePrefixId = basePrefixId;
            this.BaseUnitId = baseUnitId;
            this.Symbol = symbol;
        }

        public override string ToString()
        {
            return $"{this.PrefixId}{this.Name}(base:{this.BasePrefixId}{this.BaseUnitId}) as {this.QuantityId} quantity, [{this.Symbol}]";
        }

        #region IUnit

        public new Enum ID => base.ID;

        public string Name { get; private set; }

        public string Symbol { get; private set; }

        public PrefixID? PrefixId { get; private set; }

        public QuantityID QuantityId { get; private set; }

        public PrefixID? BasePrefixId { get; private set; }

        public Enum BaseUnitId { get; private set; }

        #endregion IUnit
    }

    //public abstract class MeasurementUnitBase<TMeasurementUnitID>
    //    :SystemMetadata<MeasurementUnitBase<TMeasurementUnitID>, TMeasurementUnitID>
    //    , IUnit
    //    where TMeasurementUnitID : Enum
    //{
    //    protected MeasurementUnitBase(
    //        TMeasurementUnitID id, 
    //        PrefixID? prefixId, 
    //        QuantityID quantityId, 
    //        PrefixID? basePrefixId, 
    //        Enum baseUnitId) 
    //        : this(id, id.ToString(), prefixId, quantityId, basePrefixId, baseUnitId)
    //    {

    //    }

    //    protected MeasurementUnitBase(
    //        TMeasurementUnitID id, 
    //        string name, 
    //        PrefixID? prefixId, 
    //        QuantityID quantityId, 
    //        PrefixID? basePrefixId, 
    //        Enum baseUnitId) 
    //        : base(id)
    //    {
    //        this._name = name;
    //        this._prefixId = prefixId;
    //        this._quantityId = quantityId;
    //        this._basePrefixId = basePrefixId;
    //        this._baseUnitId = baseUnitId;
    //    }

    //    #region IUnit

    //    private readonly string _name;
    //    private readonly PrefixID? _prefixId;
    //    private readonly QuantityID _quantityId;
    //    private readonly PrefixID? _basePrefixId;
    //    private readonly Enum _baseUnitId;

    //    public new Enum ID => base.ID;

    //    public string Name => this._name;

    //    public PrefixID? PrefixId => this._prefixId;

    //    public QuantityID QuantityId => this._quantityId;

    //    public PrefixID? BasePrefixId => this._basePrefixId;

    //    public Enum BaseUnitId => this._baseUnitId;

    //    #endregion IUnit
    //}
}
