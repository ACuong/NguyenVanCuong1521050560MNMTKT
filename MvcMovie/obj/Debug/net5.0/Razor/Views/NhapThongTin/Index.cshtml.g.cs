#pragma checksum "D:\HocTap\MaNguonMoTKT2\BTThucHanh\MvcMovie\Views\NhapThongTin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "881746427c4b4c4dbaac6769c537db7b10d6cd62"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_NhapThongTin_Index), @"mvc.1.0.view", @"/Views/NhapThongTin/Index.cshtml")]
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
#nullable restore
#line 1 "D:\HocTap\MaNguonMoTKT2\BTThucHanh\MvcMovie\Views\_ViewImports.cshtml"
using MvcMovie;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\HocTap\MaNguonMoTKT2\BTThucHanh\MvcMovie\Views\_ViewImports.cshtml"
using MvcMovie.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"881746427c4b4c4dbaac6769c537db7b10d6cd62", @"/Views/NhapThongTin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"686ad2e38abb871af45be971520cc6c3156da389", @"/Views/_ViewImports.cshtml")]
    public class Views_NhapThongTin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\HocTap\MaNguonMoTKT2\BTThucHanh\MvcMovie\Views\NhapThongTin\Index.cshtml"
  
    ViewData["Title"] = "Nhap thong tin";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2>Nhap thong tin</h2>\r\n");
#nullable restore
#line 5 "D:\HocTap\MaNguonMoTKT2\BTThucHanh\MvcMovie\Views\NhapThongTin\Index.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Nhập vào Tên</p>\r\n    <input type=\"text\" name=\"Ten\" />\r\n    <p>Nhập vào Tuổi</p>\r\n    <input type=\"text\" name=\"Tuoi\" />\r\n    <input type=\"submit\" value=\"Nhap Thong Tin\" />\r\n");
#nullable restore
#line 12 "D:\HocTap\MaNguonMoTKT2\BTThucHanh\MvcMovie\Views\NhapThongTin\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<br> \r\n<h2>Thông tin vua nhap</h2>\r\n<p>Tên: ");
#nullable restore
#line 15 "D:\HocTap\MaNguonMoTKT2\BTThucHanh\MvcMovie\Views\NhapThongTin\Index.cshtml"
   Write(ViewBag.Ten);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>Tuổi: ");
#nullable restore
#line 16 "D:\HocTap\MaNguonMoTKT2\BTThucHanh\MvcMovie\Views\NhapThongTin\Index.cshtml"
    Write(ViewBag.Tuoi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
