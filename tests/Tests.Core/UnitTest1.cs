using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [Category("Api")]
        public void Test1()
        {
            Assert.Pass();  
        }

        [Test]
        [Category("Fail")]
        public void Test2()
        {
            Assert.Fail();
        }
    }
}