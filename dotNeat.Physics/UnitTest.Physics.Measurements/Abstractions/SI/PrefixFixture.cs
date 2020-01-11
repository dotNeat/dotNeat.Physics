//
// PrefixFixture.cs
// 12/12/2019 
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
namespace UnitTest.Physics.Measurements.Abstractions.SI
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using dotNeat.Physics.Measurements.Abstractions.SI;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    [TestCategory(nameof(PrefixFixture))]
    public class PrefixFixture
    {
        [TestInitialize]
        public void SetupFixture()
        {
        }

        [TestCleanup]
        public void TearDownFixture()
        {
        }

        [TestMethod]
        public void QuickVisualTest()
        {
            foreach (var prefix in Prefix.Set)
            {
                string trace = $"{prefix.ID}, {prefix.Symbol}, {prefix.Name}, {prefix.Value}";
                Trace.WriteLine(trace);
                Console.WriteLine(trace);
            }
        }

        [TestMethod]
        public void BasicSanityTest()
        {
            int i = 1;
            while (i < Prefix.Set.Count - 1)
            {
                double ratio = ( Prefix.Set.ToArray()[i - 1].Value / Prefix.Set.ToArray()[i].Value );
                Trace.WriteLine($"{Prefix.Set.ToArray()[i - 1].Symbol} / { Prefix.Set.ToArray()[i].Symbol} = {ratio}.");
                Console.WriteLine($"{Prefix.Set.ToArray()[i - 1].Symbol} / { Prefix.Set.ToArray()[i].Symbol} = {ratio}.");
                const double EPSILON = 0.000001d;
                Assert.IsTrue(Math.Abs(ratio - 10d) < EPSILON || Math.Abs(ratio - 1000d) < EPSILON);
                i++;
            }

            Assert.AreEqual(new HashSet<Prefix>(Prefix.Set).Count, Prefix.Set.Count);
        }
    }
}
