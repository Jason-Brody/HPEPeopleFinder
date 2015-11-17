using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Utils;
using PeopleFinder;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            HPUserViewModel vm = new HPUserViewModel();
            var dic = vm.ToDic();
            Assert.AreEqual<int>(dic.Count, 20);
        }
    }
}
