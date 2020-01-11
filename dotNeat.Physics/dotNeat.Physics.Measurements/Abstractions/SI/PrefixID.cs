//
// PrefixID.cs
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

    public enum PrefixID : SByte 
    {
        // a member value represent power of base10 of the member,
        // i.e. Y = 10^Yotta, k = 10^Kilo, 1 = 10^None, m = 10^Milli y = 10^Yocto, etc.

        Yotta =  24,
        Zetta =  21,
        Exa   =  18,
        Peta  =  15,
        Tera  =  12,
        Giga  =   9,
        Mega  =   6,
        Kilo  =   3,
        Hecto =   2,
        Deca  =   1,
        None  =   0,
        Deci  =  -1,
        Centi =  -2,
        Milli =  -3,
        Micro =  -6,
        Nano  =  -9,
        Pico  = -12,
        Femto = -15,
        Atto  = -18,
        Zepto = -21,
        Yocto = -24,
    }
}
