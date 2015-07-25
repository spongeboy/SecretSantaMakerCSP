using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SecretSantaMakerCSP.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PassingNullShouldReturnNull()
        {
            var solver = new DrawMaker();

            var result = solver.MakeNextDraw(null, null);

            Assert.IsNull(result);
        }
    }
}
