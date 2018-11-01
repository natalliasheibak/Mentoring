using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exception.Task2;
using Exception.Task2.ConverterExceptions;

namespace Test.Task2
{
    [TestClass]
    public class TestsTask2
    {
        [TestMethod]
        public void Verify_Valid_Positive_Number()
        {
            var expectedNumber = 15987564;
            var actualNumber = ConvertHelper.ConvertToInt(expectedNumber.ToString());

            Assert.AreEqual(expectedNumber, actualNumber, "The numbers are not equal.");
        }

        [TestMethod]
        public void Verify_Valid_Negative_Number()
        {
            var expectedNumber = -15987564;
            var actualNumber = ConvertHelper.ConvertToInt(expectedNumber.ToString());

            Assert.AreEqual(expectedNumber, actualNumber, "The numbers are not equal.");
        }

        [TestMethod]
        public void Verify_Invalid_Number()
        {
            System.Exception exception = null;
            var stringValue = "InvalidNumberFormat";

            try
            {
                var actualNumber = ConvertHelper.ConvertToInt(stringValue);
            }
            catch (IncorrectFormatException e)
            {
                exception = e;
            }

            Assert.IsNotNull(exception, "The Incorrect Format Exception wasn't thrown.");
        }

        [TestMethod]
        public void Verify_Empty_String()
        {
            System.Exception exception = null;
            var stringValue = string.Empty;

            try
            {
                var actualNumber = ConvertHelper.ConvertToInt(stringValue);
            }
            catch (EmptyStringException e)
            {

                exception = e ;
            }

            Assert.IsNotNull(exception, "The Empty String Exception wasn't thrown.");
        }

        [TestMethod]
        public void Verify_Null()
        {
            System.Exception exception = null;
            var stringValue = null as string;

            try
            {
                var actualNumber = ConvertHelper.ConvertToInt(stringValue);
            }
            catch (NullException e)
            {

                exception = e;
            }

            Assert.IsNotNull(exception, "The Null Exception wasn't thrown.");
        }
    }
}
