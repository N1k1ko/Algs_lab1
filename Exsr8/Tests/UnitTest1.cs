namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        static int F(int n, int m, int between) => Exsr8.Exsr8.GetResult(n, m, between);

        [TestMethod]
        public void DefaultTest1()
        {
            var result = F(5, 3, 0);
            Assert.AreEqual(4, result);
        }
        [TestMethod]
        public void Test1()
        {
            var result = F(0, 0, 0);
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void Test2()
        {
            var result = F(0, 1000, 0);
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void Test3()
        {
            var result = F(1000, 0, 0);
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void Test4()
        {
            var result = F(1000, 1000, 0);
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void Test5()
        {
            var result = F(500, 1000, 0);
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void Test6()
        {
            var result = F(3, 2, 0);// TT. T.T .TT
            Assert.AreEqual(3, result);
        }
        [TestMethod]
        public void Test7()
        {
            var result = F(7, 2, 0);// TT.....(6) T.T....(5) T..T...(4) T...T..(3) T....T.(2) T.....T (1) 
            Assert.AreEqual(21, result);
        }
        [TestMethod]
        public void Test8()
        {
            var result = F(7, 5, 0);// TTTTT..
            Assert.AreEqual(3, result);
        }
        [TestMethod]
        public void Test9()
        {
            var result = F(7, 4, 0);// TTTT...(4) T.T.T.T(1)
            Assert.AreEqual(5, result);
        }
        [TestMethod]
        public void Test10()
        {
            var result = F(1000, 500, 0);// TTTT...(4) T.T.T.T(1)
            Assert.AreEqual(503, result);
        }
    }
}