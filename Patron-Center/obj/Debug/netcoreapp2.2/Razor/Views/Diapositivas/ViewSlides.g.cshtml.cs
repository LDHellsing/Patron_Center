#pragma checksum "C:\PatronCenter\Patron-Center\Views\Diapositivas\ViewSlides.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5840d7a81476f53fe5a902c9f1060db831f808ed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Diapositivas_ViewSlides), @"mvc.1.0.view", @"/Views/Diapositivas/ViewSlides.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Diapositivas/ViewSlides.cshtml", typeof(AspNetCore.Views_Diapositivas_ViewSlides))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\PatronCenter\Patron-Center\Views\_ViewImports.cshtml"
using Patron_Center;

#line default
#line hidden
#line 2 "C:\PatronCenter\Patron-Center\Views\_ViewImports.cshtml"
using Patron_Center.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5840d7a81476f53fe5a902c9f1060db831f808ed", @"/Views/Diapositivas/ViewSlides.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac15b4dcef0ea199b8a0969b7ebf808693eb7279", @"/Views/_ViewImports.cshtml")]
    public class Views_Diapositivas_ViewSlides : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Patron_Center.Models.Diapositiva>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\PatronCenter\Patron-Center\Views\Diapositivas\ViewSlides.cshtml"
  
    ViewData["Title"] = "VerDiapositivas";

#line default
#line hidden
            BeginContext(105, 233, true);
            WriteLiteral("\r\n<h1>VerDiapositivas</h1>\r\n\r\n<div id=\"carouselExampleIndicators\" class=\"carousel slide\" data-ride=\"carousel\" data-interval=\"false\" style=\"background-color:dimgrey;color:white;height:80%;\">\r\n\r\n    <ol class=\"carousel-indicators\">\r\n\r\n");
            EndContext();
#line 12 "C:\PatronCenter\Patron-Center\Views\Diapositivas\ViewSlides.cshtml"
         for (int i = 0; i < Model.Count(); i++)
        {
            

#line default
#line hidden
#line 14 "C:\PatronCenter\Patron-Center\Views\Diapositivas\ViewSlides.cshtml"
             if (i == 0)
            {

#line default
#line hidden
            BeginContext(440, 101, true);
            WriteLiteral("                <li data-target=\"#carouselExampleIndicators\" data-slide-to=\"0\" class=\"active\"></li>\r\n");
            EndContext();
#line 17 "C:\PatronCenter\Patron-Center\Views\Diapositivas\ViewSlides.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(589, 76, true);
            WriteLiteral("                <li data-target=\"#carouselExampleIndicators\" data-slide-to=\"");
            EndContext();
            BeginContext(666, 1, false);
#line 20 "C:\PatronCenter\Patron-Center\Views\Diapositivas\ViewSlides.cshtml"
                                                                       Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(667, 9, true);
            WriteLiteral("\"></li>\r\n");
            EndContext();
#line 21 "C:\PatronCenter\Patron-Center\Views\Diapositivas\ViewSlides.cshtml"
            }

#line default
#line hidden
#line 21 "C:\PatronCenter\Patron-Center\Views\Diapositivas\ViewSlides.cshtml"
             
        }

#line default
#line hidden
            BeginContext(702, 49, true);
            WriteLiteral("    </ol>\r\n\r\n    <div class=\"carousel-inner\">\r\n\r\n");
            EndContext();
#line 27 "C:\PatronCenter\Patron-Center\Views\Diapositivas\ViewSlides.cshtml"
         foreach (var item in Model)
        {
            

#line default
#line hidden
#line 29 "C:\PatronCenter\Patron-Center\Views\Diapositivas\ViewSlides.cshtml"
             if (Model.First() == item)
            {

#line default
#line hidden
            BeginContext(856, 164, true);
            WriteLiteral("        <div class=\"carousel-item active\" style=\"text-align:center;font:Sans-serif;font-size:25px;padding: 25px 100px 25px 100px;min-height:600px\">\r\n            <a>");
            EndContext();
            BeginContext(1021, 40, false);
#line 32 "C:\PatronCenter\Patron-Center\Views\Diapositivas\ViewSlides.cshtml"
          Write(Html.DisplayFor(modelItem => item.Texto));

#line default
#line hidden
            EndContext();
            BeginContext(1061, 51, true);
            WriteLiteral("</a>\r\n            <iframe width=\"1203\" height=\"684\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 1112, "\"", 1132, 1);
#line 33 "C:\PatronCenter\Patron-Center\Views\Diapositivas\ViewSlides.cshtml"
WriteAttributeValue("", 1118, item.UrlVideo, 1118, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1133, 154, true);
            WriteLiteral(" frameborder=\"0\" allow=\"accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture\" allowfullscreen></iframe>\r\n            \r\n        </div>\r\n");
            EndContext();
#line 36 "C:\PatronCenter\Patron-Center\Views\Diapositivas\ViewSlides.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(1335, 149, true);
            WriteLiteral("    <div class=\"carousel-item\" style=\"text-align:center;font:Sans-serif;font-size:25px;padding: 25px 100px 25px 100px;min-height:600px\">\r\n        <a>");
            EndContext();
            BeginContext(1485, 40, false);
#line 40 "C:\PatronCenter\Patron-Center\Views\Diapositivas\ViewSlides.cshtml"
      Write(Html.DisplayFor(modelItem => item.Texto));

#line default
#line hidden
            EndContext();
            BeginContext(1525, 47, true);
            WriteLiteral("</a>\r\n        <iframe width=\"1203\" height=\"684\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 1572, "\"", 1592, 1);
#line 41 "C:\PatronCenter\Patron-Center\Views\Diapositivas\ViewSlides.cshtml"
WriteAttributeValue("", 1578, item.UrlVideo, 1578, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1593, 136, true);
            WriteLiteral(" frameborder=\"0\" allow=\"accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture\" allowfullscreen></iframe>\r\n    </div>\r\n");
            EndContext();
#line 43 "C:\PatronCenter\Patron-Center\Views\Diapositivas\ViewSlides.cshtml"
            }

#line default
#line hidden
#line 43 "C:\PatronCenter\Patron-Center\Views\Diapositivas\ViewSlides.cshtml"
             

        }

#line default
#line hidden
            BeginContext(1757, 496, true);
            WriteLiteral(@"    </div>

    <a class=""carousel-control-prev"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""prev"">
        <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
        <span class=""sr-only"">Previous</span>
    </a>
    <a class=""carousel-control-next"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""next"">
        <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
        <span class=""sr-only"">Next</span>
    </a>
</div>
");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Patron_Center.Models.Diapositiva>> Html { get; private set; }
    }
}
#pragma warning restore 1591
