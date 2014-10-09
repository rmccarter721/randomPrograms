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

        [Test]
        public void calculateSimpleDecimalTotal()
        {
            Assert.AreEqual("124.123", MathFunctions.calculateTotal("123.123+1"));
        }

        [Test]
        public void calculateDecimalTotal()
        {
            Assert.AreEqual("225.123", MathFunctions.calculateTotal("123.123+10/5+10*10"));
        }

        [Test]
        public void calculateIrrelevantBracket()
        {
            Assert.AreEqual("2", MathFunctions.calculateTotal("1+(1)"));
        }

        [Test]
        public void calculateBracketTotal()
        {
            Assert.AreEqual("2218.14", MathFunctions.calculateTotal("123.23*(1+2+3+4+5+6/2)"));
        }

        [Test]
        public void calculateBracketTotalWithRounding()
        {
            Assert.AreEqual("2683.6756", MathFunctions.calculateTotal("123.23*(1+2+3+4+5+6+7/9)"));
        }

        [Test]
        public void calculateInitialDecimalPoint()
        {
            Assert.AreEqual("1.123", MathFunctions.calculateTotal(".123+1"));
        }

        [Test]
        public void calculateMinusMinus()
        {
            Assert.AreEqual("2", MathFunctions.calculateTotal("1--1"));
        }

        [Test]
        public void calculateAddingMinusNumber()
        {
            Assert.AreEqual("0", MathFunctions.calculateTotal("1+-1"));
        }

        [Test]
        public void checkValidCharsAllValid()
        {
            Assert.AreEqual("123+-", MathFunctions.checkValidChars("123+-"));
        }

        [Test]
        public void checkValidCharsOneInvalid()
        {
            Assert.AreEqual("123+-", MathFunctions.checkValidChars("12d3+-"));
        }

        [Test]
        public void checkValidCharsMultipleInvalid()
        {
            Assert.AreEqual("123+-", MathFunctions.checkValidChars("1s2d3+-"));
        }

        [Test]
        public void checkHugeNumber()
        {
            String value;
            bool result = MathFunctions.checkLength(Int32.MaxValue.ToString(), out value);
            Assert.IsFalse(result);
            Assert.AreEqual("0", value);
        }

        [Test]
        public void checkHugeCalcNumber()
        {
            String value;
            bool result = MathFunctions.checkLength((9999999*9).ToString(), out value);
            Assert.IsFalse(result);
            Assert.AreEqual("0", value);
        }

        [Test]
        public void checkOkNumber()
        {
            String value;
            bool result = MathFunctions.checkLength("9999999", out value);
            Assert.IsTrue(result);
            Assert.AreEqual("9999999", value);
        }

        [Test]
        public void checkOkNegativeNumber()
        {
            String value;
            bool result = MathFunctions.checkLength("-9999999", out value);
            Assert.IsTrue(result);
            Assert.AreEqual("-9999999", value);
        }

        [Test]
        public void checkJustInvalidNumber()
        {
            String value;
            bool result = MathFunctions.checkLength("-9999999.1", out value);
            Assert.IsFalse(result);
            Assert.AreEqual("0", value);
        }
    }
}
