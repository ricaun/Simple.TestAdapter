using NUnit.Framework;

namespace TestProject.Tests
{
    //public class TestAttribute : System.Attribute { }
    public class Tests
    {
        [Test]
        public void Test()
        {
            foreach (var assembly in System.AppDomain.CurrentDomain.GetAssemblies())
            {
                System.Console.WriteLine(assembly.FullName);
            }
        }

        [Test]
        public void TestPassed()
        {

        }

        [Test]
        public void TestNone()
        {

        }

        [Test]
        public void TestSkipped()
        {

        }

        [Test]
        public void TestNotFound()
        {

        }

        [Test]
        public void TestFailed()
        {

        }

        [Test]
        public void TestPassed2()
        {

        }
    }
}