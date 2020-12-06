using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace EverlightTestProject
{
    [TestClass]
    public class RegressionTest
    {
        [TestMethod]
        public void OpenBrowserANdVerifyTitle()
        {
            var getBrowser = new TestCases();
            getBrowser.OpenBrowserAndVerifyTitle();
            
        }

        [TestMethod]
        public void CreateNewComputer()
        {
            var getBrowser = new TestCases();
            getBrowser.AddNewComputer();

        }

        [TestMethod]
        public void HandleJavaScriptPopup()
        {
            var getBrowser = new TestCases();
            getBrowser.HandleJavaScript("yes");
        }
    }
}
