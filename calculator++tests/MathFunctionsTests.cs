using System;
using NUnit.Framework;
using calculatorplusplus;

namespace calculator__tests
{

    [TestFixture]
    public class MathFunctionsTests
    {
        [Test]
        public void calculateSimpleTotal()
        {
            Assert.AreEqual("123", MathFunctions.calculateTotal("123"));
        }

        [Test]
        public void calculateKindaComplexTotal()
        {
            Assert.AreEqual("123.5", MathFunctions.calculateTotal("123+5/10"));
        }

        [Test]
        public void calculateRediculousTotal()
        {
            Assert.AreEqual("225", MathFunctions.calculateTotal("123+10/5+10*10"));
        }
    }
}
