﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Household;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Home/Index.cshtml")]
    public partial class _Views_Home_Index_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Home_Index_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Views\Home\Index.cshtml"
  
	ViewBag.Title = "Main Page";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"jumbotron\"");

WriteLiteral(">\r\n\t<h1>Household</h1>\r\n\t<p");

WriteLiteral(" class=\"lead\"");

WriteLiteral(">Welcome to our household management system</p>\r\n</div>\r\n\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n\t\t<div");

WriteLiteral(" class=\"panel-finance panel-main-clickable\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 254), Tuple.Create("\"", 319)
, Tuple.Create(Tuple.Create("", 264), Tuple.Create("document.location", 264), true)
, Tuple.Create(Tuple.Create(" ", 281), Tuple.Create("=", 282), true)
, Tuple.Create(Tuple.Create(" ", 283), Tuple.Create("\'", 284), true)
            
            #line 12 "..\..\Views\Home\Index.cshtml"
       , Tuple.Create(Tuple.Create("", 285), Tuple.Create<System.Object, System.Int32>(Url.Action("Finance", "Finance")
            
            #line default
            #line hidden
, 285), false)
, Tuple.Create(Tuple.Create("", 318), Tuple.Create("\'", 318), true)
);

WriteLiteral(">\r\n\t\t\t<div>\r\n\t\t\t\t<h2>Finance</h2>\r\n\t\t\t\t<p>Expenses, purchases and monthly bills</" +
"p>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t</div>\r\n\t<div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n\t\t<div");

WriteLiteral(" class=\"panel-work panel-main-clickable\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 506), Tuple.Create("\"", 566)
, Tuple.Create(Tuple.Create("", 516), Tuple.Create("document.location", 516), true)
, Tuple.Create(Tuple.Create(" ", 533), Tuple.Create("=", 534), true)
, Tuple.Create(Tuple.Create(" ", 535), Tuple.Create("\'", 536), true)
            
            #line 20 "..\..\Views\Home\Index.cshtml"
    , Tuple.Create(Tuple.Create("", 537), Tuple.Create<System.Object, System.Int32>(Url.Action("Work", "Work")
            
            #line default
            #line hidden
, 537), false)
, Tuple.Create(Tuple.Create("", 564), Tuple.Create("\';", 564), true)
);

WriteLiteral(">\r\n\t\t\t<div>\r\n\t\t\t\t<h2>Work</h2>\r\n\t\t\t\t<p>Manage your working hours</p>\r\n\t\t\t</div>\r\n" +
"\t\t</div>\r\n\t</div>\r\n\t<div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n\t\t<div");

WriteLiteral(" class=\"panel-homeHDD panel-main-clickable\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 741), Tuple.Create("\"", 807)
, Tuple.Create(Tuple.Create("", 751), Tuple.Create("document.location", 751), true)
, Tuple.Create(Tuple.Create(" ", 768), Tuple.Create("=", 769), true)
, Tuple.Create(Tuple.Create(" ", 770), Tuple.Create("\'", 771), true)
            
            #line 28 "..\..\Views\Home\Index.cshtml"
       , Tuple.Create(Tuple.Create("", 772), Tuple.Create<System.Object, System.Int32>(Url.Action("HomeHDD", "HomeHDD")
            
            #line default
            #line hidden
, 772), false)
, Tuple.Create(Tuple.Create("", 805), Tuple.Create("\';", 805), true)
);

WriteLiteral(">\r\n\t\t\t<div>\r\n\t\t\t\t<h2>Home-HDD</h2>\r\n\t\t\t\t<p>Come on in and manage your documents a" +
"nd pictures</p>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t</div>\r\n\t<div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n\t\t<div");

WriteLiteral(" class=\"panel-serverManager panel-main-clickable\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 1016), Tuple.Create("\"", 1093)
, Tuple.Create(Tuple.Create("", 1026), Tuple.Create("document.location", 1026), true)
, Tuple.Create(Tuple.Create(" ", 1043), Tuple.Create("=", 1044), true)
, Tuple.Create(Tuple.Create(" ", 1045), Tuple.Create("\'", 1046), true)
            
            #line 36 "..\..\Views\Home\Index.cshtml"
            , Tuple.Create(Tuple.Create("", 1047), Tuple.Create<System.Object, System.Int32>(Url.Action("ServerManager", "ServerManager")
            
            #line default
            #line hidden
, 1047), false)
, Tuple.Create(Tuple.Create("", 1092), Tuple.Create("\'", 1092), true)
);

WriteLiteral(">\r\n\t\t\t<div>\r\n\t\t\t\t<h2>Server Manager</h2>\r\n\t\t\t\t<p>Check out the server and look wh" +
"at\'s going on in the world</p>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t</div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591