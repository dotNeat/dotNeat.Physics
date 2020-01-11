//
// SystemMetadata.cs
// 12/24/2019 
//
// Author:
//       Andrey Kornich (Wide Spectrum Computing LLC) <akornich@gmail.com>
//
// Copyright (c) 2019 dotNeat
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
namespace dotNeat.Physics.Measurements.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public abstract class SystemMetadata<TMetadata, TMetadataID>
        where TMetadata : SystemMetadata<TMetadata, TMetadataID>
        where TMetadataID : Enum
    {

        private static readonly
            Dictionary<Type, Dictionary<Enum, SystemMetadata<TMetadata, TMetadataID>>> metadataByIdTypeByID;

        private readonly TMetadataID _id;

        public TMetadataID ID { get { return this._id; } }

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
            this._id = id;
        }

        protected static void EnsureMetadataPresent(TMetadata[] metadataSet)
        {
            Type metadataType = typeof(TMetadata);

            if (!metadataByIdTypeByID.ContainsKey(metadataType))
            {
                Dictionary<Enum, SystemMetadata<TMetadata, TMetadataID>> metadataByID =
                    new Dictionary<Enum, SystemMetadata<TMetadata, TMetadataID>>(metadataSet.Length);

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
