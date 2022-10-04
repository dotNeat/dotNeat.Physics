//
// IMeasurement.cs
// 12/11/2019 
//
namespace dotNeat.Physics.Measurements
{
    using System;

    public interface IMeasurement
    {
        object Value { get; set; }
        object Unit { get; set; }
        object BaseUnit { get; }
        string Render();
    }
}
