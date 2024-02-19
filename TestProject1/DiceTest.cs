using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]
    public class DiceTest
    {
        public static decimal RollTestSides(int sides)
        {
            if (sides <= 0) { return 0; } 
            var rand = new Random();
            return Convert.ToDecimal(rand.Next(1, sides+1));
        }

        [TestMethod]
        public void RollTestSides0()
        {
            Assert.AreEqual(0, RollTestSides(0));
        }

        [TestMethod]
        public void RollTestSides10()
        {
            Assert.IsTrue(RollTestSides(10) <= 10 && RollTestSides(10) > 0);
        }
    }
}
