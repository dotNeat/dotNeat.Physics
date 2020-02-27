//
// Prefix.cs
// 12/11/2019 
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

    public class Prefix
        : SystemMetadata<Prefix, PrefixID>
    {
        //private static readonly List<Prefix> siSet;

        // data seed fields:
        private readonly PrefixID _id;
        private readonly string _symbol;

        // calculated once data fields:
        private readonly string _name;
        private readonly Double _value;

        static Prefix()
        {
            Prefix.EnsureMetadataPresent(new Prefix[] {
                    new Prefix(PrefixID.Yotta, "Y"),
                    new Prefix(PrefixID.Zetta, "Z"),
                    new Prefix(PrefixID.Exa,   "E"),
                    new Prefix(PrefixID.Peta,  "P"),
                    new Prefix(PrefixID.Tera,  "T"),
                    new Prefix(PrefixID.Giga,  "G"),
                    new Prefix(PrefixID.Mega,  "M"),
                    new Prefix(PrefixID.Kilo,  "k"),
                    new Prefix(PrefixID.Hecto, "h"),
                    new Prefix(PrefixID.Deca,  "da"),
                    new Prefix(PrefixID.None,  string.Empty),
                    new Prefix(PrefixID.Deci,  "d"),
                    new Prefix(PrefixID.Centi, "c"),
                    new Prefix(PrefixID.Milli, "m"),
                    new Prefix(PrefixID.Micro, "µ"),
                    new Prefix(PrefixID.Nano,  "n"),
                    new Prefix(PrefixID.Pico,  "p"),
                    new Prefix(PrefixID.Femto, "f"),
                    new Prefix(PrefixID.Atto,  "a"),
                    new Prefix(PrefixID.Zepto, "z"),
                    new Prefix(PrefixID.Yocto, "y"),
                });
        }

        private Prefix()
            : this(PrefixID.None, string.Empty)
        {
        }

        private Prefix(PrefixID id, string symbol)
            : base(id)
        {
            this._symbol = symbol;

            this._name = $"{id.ToString().ToLower()}";
            this._value = Math.Pow(10d, Convert.ToDouble(id));
        }

        public string Symbol
        {
            get { return this._symbol; }
        }

        public string Name
        {
            get { return this._name; }
        }

        public Double Value
        {
            get { return this._value; }
        }

    }

}
