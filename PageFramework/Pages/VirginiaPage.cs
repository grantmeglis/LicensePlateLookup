using System;
using System.Collections.Generic;
using System.Text;

namespace PageFramework.Pages
{
    public class VirginiaPage
    {
        private int PAGE_LOAD_TIMEOUT = 7;

        public void Goto()
        {
            Browser.Goto("https://www.dmv.virginia.gov/dmvnet/plate_purchase/select_plate.asp?PLT=&PLTNO=");
        }

        public bool IsAt()
        {
            return Browser.Title.Contains("License Plate Purchase");
        }
    }
}
