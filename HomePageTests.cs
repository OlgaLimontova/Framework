using NUnit.Framework;

namespace SiteChecker
{
    [TestFixture]
    [Parallelizable]
    public class MainTestClass
    {
        Page homePage;
        CheckingClass checker;

        [SetUp]
        public void ReadErrorsMFBecauseIJustWantGoHomeAndGoHardLikeVladimirPutin() // Method's name by Evgeniy Dima
        {
            homePage = new Page();
            checker = new CheckingClass();
        }

//        [Ignore("")]
        [Test]
        public void MainTestMethodL()
        {
            checker.StartTests(homePage, "l");
        }

//        [Ignore("")]
        [Test]
        public void MainTestMethodM()
        {
            checker.StartTests(homePage, "m");
        }

//        [Ignore("")]
        [Test]
        public void MainTestMethodN()
        {
            checker.StartTests(homePage, "n");
        }

//        [Ignore("")]
        [Test]
        public void MainTestMethodO()
        {
            checker.StartTests(homePage, "o");
        }

//        [Ignore("")]
        [Test]
        public void MainTestMethodP()
        {
            checker.StartTests(homePage, "p");
        }

        [TearDown]
        public static void Cleanup()
        {
            WebDriver.KillDriver();
        }
    }
}