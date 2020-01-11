//
// MeasurementBase.cs
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
namespace dotNeat.Physics.Measurements
{
    using System;
    using dotNeat.Common.DesignPatterns.Prototype;

    public abstract class MeasurementBase<TValue, TUnit, TConcreteMeasurement>
        : IMeasurement
        , IEquatable<TConcreteMeasurement>
        , IComparable<TConcreteMeasurement>
        , IPrototype<TConcreteMeasurement>
        , IPrototype
        where TConcreteMeasurement : MeasurementBase<TValue, TUnit, TConcreteMeasurement>, IPrototype
        where TValue : IEquatable<TValue>, IComparable<TValue>, IComparable
        where TUnit : struct, IComparable
    {
        private MeasurementBase()
        {
        }

        protected MeasurementBase(TValue value, TUnit unit)
        {
            this.Value = value;
            this.Unit = unit;
        }

        public TValue Value { get; set; }
        public TUnit Unit { get; set; }

        public abstract TUnit BaseUnit { get; }
        public abstract string Render();
        protected abstract TConcreteMeasurement ToBaseUnit();
        protected abstract TConcreteMeasurement FromBaseUnitAs(TUnit unit);

        public TConcreteMeasurement As(TUnit unit)
        {
            if (this.Unit.Equals(unit))
            {
                return (TConcreteMeasurement)this;
            }

            var inBaseUnits = this.ToBaseUnit();
            var inTargetUnits = inBaseUnits.FromBaseUnitAs(unit);
            return inTargetUnits;
        }

        public override string ToString()
        {
            return this.Render();
        }

        public bool Equals(TConcreteMeasurement other)
        {
            if (other == null)
            {
                return false;
            }

            return (this.CompareTo(other) == 0);
        }

        public int CompareTo(TConcreteMeasurement other)
        {
            if (this.Unit.CompareTo(other.Unit) == 0)
            {
                return this.Value.CompareTo(other.Value);
            }
            else
            {
                return this.ToBaseUnit().CompareTo(other.ToBaseUnit());
            }
        }

        public bool Equals(IMeasurement other)
        {
            return this.Equals((TConcreteMeasurement)other);
        }

        public int CompareTo(IMeasurement other)
        {
            return this.CompareTo((TConcreteMeasurement)other);
        }

        public int CompareTo(object obj)
        {
            return this.CompareTo((TConcreteMeasurement)obj);
        }

        object IMeasurement.Value
        {
            get { return this.Value; }
            set { this.Value = (TValue)value; }
        }

        object IMeasurement.Unit
        {
            get { return this.Unit; }
            set { this.Unit = (TUnit)value; }
        }

        object IMeasurement.BaseUnit
        {
            get { return this.BaseUnit; }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            return this.Equals((TConcreteMeasurement)obj);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public TConcreteMeasurement Clone()
        {
            throw new NotImplementedException();
        }

        IPrototype IPrototype.Clone()
        {
            return this.Clone();
        }

        public static bool operator == (
            MeasurementBase<TValue, TUnit, TConcreteMeasurement> left,
            MeasurementBase<TValue, TUnit, TConcreteMeasurement> right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator != (
            MeasurementBase<TValue, TUnit, TConcreteMeasurement> left,
            MeasurementBase<TValue, TUnit, TConcreteMeasurement> right)
        {
            return !(left == right);
        }

        public static bool operator < (
            MeasurementBase<TValue, TUnit, TConcreteMeasurement> left,
            MeasurementBase<TValue, TUnit, TConcreteMeasurement> right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        public static bool operator <= (
            MeasurementBase<TValue, TUnit, TConcreteMeasurement> left,
            MeasurementBase<TValue, TUnit, TConcreteMeasurement> right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        public static bool operator > (
            MeasurementBase<TValue, TUnit, TConcreteMeasurement> left,
            MeasurementBase<TValue, TUnit, TConcreteMeasurement> right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        public static bool operator >= (
            MeasurementBase<TValue, TUnit, TConcreteMeasurement> left,
            MeasurementBase<TValue, TUnit, TConcreteMeasurement> right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }

    }
}
