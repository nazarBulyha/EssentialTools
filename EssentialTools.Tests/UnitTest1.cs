using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EssentialTools.Models;

namespace EssentialTools.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        private IDiscountHelper getTestObject()
        {
            return new MinimumDiscountHelper();
        }

        [TestMethod]
        public void Discount_Above_100()
        {
            // arrange (організація)
            IDiscountHelper target = getTestObject();
            decimal total = 200;

            // act (акт)
            var discountedTotal = target.ApplyDiscount(total);

            // assert (утвердження)
            Assert.AreEqual(total * 0.9M, discountedTotal);
        }

        [TestMethod]
        public void Discount_Between_10_And_100()
        {
            // arrange (организация)
            IDiscountHelper target = getTestObject();

            // act (акт)
            decimal TenDollarDiscount = target.ApplyDiscount(10);
            decimal HundredDollarDiscount = target.ApplyDiscount(100);
            decimal FiftyDollarDiscount = target.ApplyDiscount(50);

            // assert (утверждение)
            Assert.AreEqual(9.50M, TenDollarDiscount, "$10 разница");
            Assert.AreEqual(95, HundredDollarDiscount, "$100 разница");
            Assert.AreEqual(47.5M, FiftyDollarDiscount, "$50 разница");
        }

        [TestMethod]
        public void Discount_Less_Than_10()
        {
            // arrange (організація)
            IDiscountHelper target = getTestObject();

            // act (акт)
            decimal discount5 = target.ApplyDiscount(5);
            decimal discount0 = target.ApplyDiscount(0);

            // assert (утвердження)
            Assert.AreEqual(5, discount5);
            Assert.AreEqual(0, discount0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Discount_Negative_Total()
        {
            // arrange (організація)
            IDiscountHelper target = getTestObject();

            // act (акт)
            target.ApplyDiscount(-1);
        }
    }
}
