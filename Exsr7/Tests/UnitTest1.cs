using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        private static int F(int N, int K) => Exsr7.Exsr7.FindMagaradjaPlacements(N, K);
        [TestMethod]
        public void DefaultTest1()
        {
            int result = F(3, 1);
            Assert.AreEqual(9, result);
        }
        [TestMethod]
        public void DefaultTest2()
        {
            int result = F(4, 2);
            Assert.AreEqual(20, result);
        }
        [TestMethod]
        public void DefaultTest3()
        {
            int result = F(5, 3);
            Assert.AreEqual(48, result);
        }

        [TestMethod]
        public void Test1()
        {
            int result = F(10, 10);
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void Test2()
        {
            int result = F(1, 1);
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void Test3()
        {
            for (int i = 3; i <= 10; i++)
            {
                int result = F(i, i);
                Assert.AreEqual(0, result);
            }
        }
        [TestMethod]
        public void Test4()
        {
            int result = F(10, 1);
            Assert.AreEqual(100, result);
        }
        [TestMethod]
        public void Test5()
        {
            int result = F(1, 10);
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void Test6()
        {
            int result = F(5, 10);
            Assert.AreEqual(0, result);
        }
    }
}