namespace dotNeat.Physics.Measurements.Abstractions
{
    using System;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public abstract class SystemMetadata<TMetadata, TMetadataID>
        : ISystemMetadata<TMetadataID>
        where TMetadata : SystemMetadata<TMetadata, TMetadataID>
        where TMetadataID : Enum
    {

        private static readonly
            Dictionary<Type, Dictionary<Enum, SystemMetadata<TMetadata, TMetadataID>>> metadataByIdTypeByID;

        public TMetadataID ID { get; private set; }

        static SystemMetadata()
        {
            metadataByIdTypeByID = new Dictionary<Type, Dictionary<Enum, SystemMetadata<TMetadata, TMetadataID>>>();
        }

        private static Type EnsureSpecificSystemMetadataTypeInitialized()
        {
            Type metadataType = typeof(TMetadata);
            RuntimeHelpers.RunClassConstructor(metadataType.TypeHandle);
            return metadataType;
        }

        private SystemMetadata()
        {
        }

        protected SystemMetadata(TMetadataID id)
        {
            this.ID = id;
        }

        protected static void EnsureMetadataPresent(TMetadata[] metadataSet)
        {
            Debug.Assert(metadataSet != null);
            Debug.Assert(metadataSet.Length > 0);

            Type metadataType = typeof(TMetadata);

            if (!metadataByIdTypeByID.ContainsKey(metadataType))
            {
                Dictionary<Enum, SystemMetadata<TMetadata, TMetadataID>> metadataByID = new(capacity: metadataSet.Length);

                foreach (var metadata in metadataSet)
                {
                    metadataByID[metadata.ID] = metadata;
                }
                metadataByIdTypeByID[metadataType] = metadataByID;
            }
        }

        public static IReadOnlyCollection<TMetadata> Set
        {
            get
            {
                Type metadataType = EnsureSpecificSystemMetadataTypeInitialized();
                return metadataByIdTypeByID[metadataType].Values.Cast<TMetadata>().ToArray();
            }
        }

        public static TMetadata Get(TMetadataID id)
        {
            Type metadataType = EnsureSpecificSystemMetadataTypeInitialized();
            return (TMetadata) metadataByIdTypeByID[metadataType][id];
        }

    }
}
