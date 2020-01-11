//
// Temperature.cs
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
    using System.Diagnostics;
    using System.Linq;

    public class Temperature
        : MeasurementBase<double, TemperatureUnit, Temperature>
    {
        public const TemperatureUnit TemperatureBaseUnit = TemperatureUnit.Kelvin;

        public Temperature(double value)
            : this(value, Temperature.TemperatureBaseUnit)
        {
        }

        public Temperature(double value, TemperatureUnit unit)
            : base(value, unit)
        {
        }

        public override TemperatureUnit BaseUnit => Temperature.TemperatureBaseUnit;

        protected override Temperature ToBaseUnit()
        {
            Debug.Assert(this.BaseUnit == TemperatureUnit.Kelvin);

            switch (this.Unit)
            {
                case TemperatureUnit.Celsius:
                    return new Temperature(
                        this.Value + 273.15
                        , this.BaseUnit
                        );
                case TemperatureUnit.Fahrenheit:
                    return new Temperature(
                        ((this.Value + 459.67) * 5) / 9
                        , this.BaseUnit
                        );
                case TemperatureUnit.Kelvin:
                    return this;
                default:
                    const string msg = "Unexpected enum value!";
                    Debug.Assert(false, msg);
                    throw new NotImplementedException(msg);
            }
        }

        protected override Temperature FromBaseUnitAs(TemperatureUnit unit)
        {
            Debug.Assert(this.Unit == this.BaseUnit);
            Debug.Assert(this.BaseUnit == TemperatureUnit.Kelvin);

            switch (unit)
            {
                case TemperatureUnit.Celsius:
                    return new Temperature(
                        this.Value - 273.15
                        , unit
                        );
                case TemperatureUnit.Fahrenheit:
                    return new Temperature(
                        ((this.Value * 5) / 9) - 459.67
                        , unit
                        );
                case TemperatureUnit.Kelvin:
                    return this;
                default:
                    const string msg = "Unexpected enum value!";
                    Debug.Assert(false, msg);
                    throw new NotImplementedException(msg);
            }
        }

        public override string Render()
        {
            return $"{this.Value}°{this.Unit.ToString().First()}";
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static bool operator == (Temperature left, Temperature right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator != (Temperature left, Temperature right)
        {
            return !(left == right);
        }

        public static bool operator < (Temperature left, Temperature right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        public static bool operator <= (Temperature left, Temperature right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        public static bool operator > (Temperature left, Temperature right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        public static bool operator >= (Temperature left, Temperature right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }


        public static Temperature Create(double value, TemperatureUnit unit = TemperatureBaseUnit)
        {
            return new Temperature(value, unit);
        }

        public static Temperature InKelvin(double value)
        {
            return Temperature.Create(value, TemperatureUnit.Kelvin);
        }

        public static Temperature InCelsius(double value)
        {
            return Temperature.Create(value, TemperatureUnit.Celsius);
        }

        public static Temperature InFahrenheit(double value)
        {
            return Temperature.Create(value, TemperatureUnit.Fahrenheit);
        }

    }
}
