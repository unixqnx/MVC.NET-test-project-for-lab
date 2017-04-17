using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViewTest.App_Code
{
    public static class NewHelper
    {
        public static MvcHtmlString MyHelper(string name)
        {
            return new MvcHtmlString($"<input type='submit' value='{name}'/>");
        }
    }
}