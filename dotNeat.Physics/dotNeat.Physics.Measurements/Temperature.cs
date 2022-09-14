namespace dotNeat.Physics.Measurements
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public class Temperature
        : MeasurementBase<double, TemperatureUnitID, Temperature>
    {
        public const TemperatureUnitID TemperatureBaseUnit = TemperatureUnitID.Kelvin;

        public Temperature(double value)
            : this(value, Temperature.TemperatureBaseUnit)
        {
        }

        public Temperature(double value, TemperatureUnitID unit)
            : base(value, unit)
        {
        }

        public override TemperatureUnitID BaseUnit => Temperature.TemperatureBaseUnit;

        protected override Temperature ToBaseUnit()
        {
            Debug.Assert(this.BaseUnit == TemperatureUnitID.Kelvin);

            switch (this.Unit)
            {
                case TemperatureUnitID.Celsius:
                    return new Temperature(
                        this.Value + 273.15
                        , this.BaseUnit
                        );
                case TemperatureUnitID.Fahrenheit:
                    return new Temperature(
                        ((this.Value + 459.67) * 5) / 9
                        , this.BaseUnit
                        );
                case TemperatureUnitID.Kelvin:
                    return this;
                default:
                    const string msg = "Unexpected enum value!";
                    Debug.Assert(false, msg);
                    throw new NotImplementedException(msg);
            }
        }

        protected override Temperature FromBaseUnitAs(TemperatureUnitID unit)
        {
            Debug.Assert(this.Unit == this.BaseUnit);
            Debug.Assert(this.BaseUnit == TemperatureUnitID.Kelvin);

            switch (unit)
            {
                case TemperatureUnitID.Celsius:
                    return new Temperature(
                        this.Value - 273.15
                        , unit
                        );
                case TemperatureUnitID.Fahrenheit:
                    return new Temperature(
                        ((this.Value * 5) / 9) - 459.67
                        , unit
                        );
                case TemperatureUnitID.Kelvin:
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


        public static Temperature Create(double value, TemperatureUnitID unit = TemperatureBaseUnit)
        {
            return new Temperature(value, unit);
        }

        public static Temperature InKelvin(double value)
        {
            return Temperature.Create(value, TemperatureUnitID.Kelvin);
        }

        public static Temperature InCelsius(double value)
        {
            return Temperature.Create(value, TemperatureUnitID.Celsius);
        }

        public static Temperature InFahrenheit(double value)
        {
            return Temperature.Create(value, TemperatureUnitID.Fahrenheit);
        }

    }
}
