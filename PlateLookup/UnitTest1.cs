using System;
using Xunit;
using PageFramework;
using PageFramework.Pages;

namespace PlateLookup
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Browser.Initialize();
            var VirginiaPage = new VirginiaPage();
            VirginiaPage.Goto();
            Browser.Close();
        }
    }
}
