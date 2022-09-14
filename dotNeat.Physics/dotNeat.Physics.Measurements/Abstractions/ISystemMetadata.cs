namespace dotNeat.Physics.Measurements.Abstractions
{
    using System;

    internal interface ISystemMetadata<TMetadataID>
        where TMetadataID : Enum
    {
        public TMetadataID ID { get; }
    }
}
