using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SiteChecker
{
    [TestClass]
    public class MSTestClass1
    {
        Page homePage;
        CheckingClass checker;

        [TestInitialize]
        public void SetUp()
        {
            homePage = new Page();
            checker = new CheckingClass();
        }

        [TestMethod]
        public void MSTestMethodL()
        {
            checker.StartTests(homePage, "l");
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            WebDriver.KillDriver();
        }
    }

    [TestClass]
    public class MSTestClass2
    {
        Page homePage;
        CheckingClass checker;

        [TestInitialize]
        public void SetUp()
        {
            homePage = new Page();
            checker = new CheckingClass();
        }

        [TestMethod]
        public void MSTestMethodM()
        {
            checker.StartTests(homePage, "m");
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            WebDriver.KillDriver();
        }
    }

    [TestClass]
    public class MSTestClass3
    {
        Page homePage;
        CheckingClass checker;

        [TestInitialize]
        public void SetUp()
        {
            homePage = new Page();
            checker = new CheckingClass();
        }

        [TestMethod]
        public void MSTestMethodN()
        {
            checker.StartTests(homePage, "n");
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            WebDriver.KillDriver();
        }
    }

    [TestClass]
    public class MSTestClass4
    {
        Page homePage;
        CheckingClass checker;

        [TestInitialize]
        public void SetUp()
        {
            homePage = new Page();
            checker = new CheckingClass();
        }

        [TestMethod]
        public void MSTestMethodO()
        {
            checker.StartTests(homePage, "o");
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            WebDriver.KillDriver();
        }
    }

    [TestClass]
    public class MSTestClass5
    {
        Page homePage;
        CheckingClass checker;

        [TestInitialize]
        public void SetUp()
        {
            homePage = new Page();
            checker = new CheckingClass();
        }

        [TestMethod]
        public void MSTestMethodP()
        {
            checker.StartTests(homePage, "p");
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            WebDriver.KillDriver();
        }
    }
}