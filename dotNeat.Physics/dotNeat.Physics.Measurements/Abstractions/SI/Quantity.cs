//
// Quantity.cs
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
namespace dotNeat.Physics.Measurements.Abstractions.SI
{
    using System;

    public class Quantity
        : SystemMetadata<Quantity, Enum>
    {
        //NOTE: The base units/quantities have unique "Dimension Symbol" and "Definition" defined
        //      while the derived units/quantities do not have these properties defined
        //      However, the base units/quantities have extra properties defined: "In SI base units" (all) and "In other SI units" (almost all)
        private readonly Enum _id;
        private readonly string _dimensionSymbol;
        private readonly string _unitSymbol;
        private readonly object _unitID;

        static Quantity()
        {
            Quantity.EnsureMetadataPresent(new Quantity[] {
                new Quantity(BaseQuantityID.Time, "T", "s", null), 
                new Quantity(BaseQuantityID.Length, "L", "m", null), 
                new Quantity(BaseQuantityID.Mass, "M", "kg", null), 
                new Quantity(BaseQuantityID.ElectricCurrent, "I", "A", null), 
                new Quantity(BaseQuantityID.ThermodynamicTemperature, "Ɵ", "K", null), 
                new Quantity(BaseQuantityID.AmountOfSubstance, "N", "mol", null), 
                new Quantity(BaseQuantityID.LuminousIntensity, "J", "cd", null), 
            });
        }

        private Quantity(Enum id, string dimensionSymbol, string unitSymbol, object unitID)
            : base(id)
        {
            this._dimensionSymbol = dimensionSymbol;
            this._unitSymbol = unitSymbol;
            this._unitID = unitID;
        }

        public string DimensionSymbol => this._dimensionSymbol;
        public string UnitSymbol => this._unitSymbol;
    }
}
