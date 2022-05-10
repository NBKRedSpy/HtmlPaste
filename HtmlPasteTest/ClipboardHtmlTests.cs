using Microsoft.VisualStudio.TestTools.UnitTesting;
using HtmlPaste;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlPaste.Tests
{
    [TestClass()]
    public class ClipboardHtmlTests
    {


        private const string SourceHtml = @"Version:1.0
StartHTML:0000000105
EndHTML:0000000880
StartFragment:0000000589
EndFragment:0000000834

<html xmlns:o=""urn:schemas-microsoft-com:office:office""
xmlns:dt=""uuid:C2F41010-65B3-11d1-A29F-00AA00C14882""
xmlns=""http://www.w3.org/TR/REC-html40"">

<head>
<meta http-equiv=Content-Type content=""text/html; charset=utf-8"">
<meta name=ProgId content=OneNote.File>
<meta name=Generator content=""Microsoft OneNote 15"">
</head>

<body lang=en-US style='font-family:Calibri;font-size:11.0pt'>

<p style='margin:0in;font-family:Consolas;font-size:10.5pt'><!--StartFragment--><span
style='color:#569CD6'>let</span><span style='color:#686868'>&nbsp;</span><span
style='color:#8A8A67'>fooFunc</span><span style='color:#686868'>:&nbsp;</span><span
style='color:#48B8A1'>Function</span><span style='color:#686868'>;</span><!--EndFragment--></p>

</body>

</html>
";


        [TestMethod()]
        public void GetFragmentTest()
        {
            var target = new ClipboardHtml();
            target.Load(SourceHtml);

            string expected = "<span\r\nstyle='color:#569CD6'>let</span><span style='color:#686868'>&nbsp;</span><span\r\nstyle='color:#8A8A67'>fooFunc</span><span style='color:#686868'>:&nbsp;</span><span\r\nstyle='color:#48B8A1'>Function</span><span style='color:#686868'>;</span>";
            string result;

            result = target.GetFragment();

            Assert.AreEqual(expected, result);

            
        }

        [TestMethod()]
        public void GetHtmlTest()
        {
            var target = new ClipboardHtml();
            target.Load(SourceHtml);

            string expected = "\r\n<html xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\nxmlns:dt=\"uuid:C2F41010-65B3-11d1-A29F-00AA00C14882\"\r\nxmlns=\"http://www.w3.org/TR/REC-html40\">\r\n\r\n<head>\r\n<meta http-equiv=Content-Type content=\"text/html; charset=utf-8\">\r\n<meta name=ProgId content=OneNote.File>\r\n<meta name=Generator content=\"Microsoft OneNote 15\">\r\n</head>\r\n\r\n<body lang=en-US style='font-family:Calibri;font-size:11.0pt'>\r\n\r\n<p style='margin:0in;font-family:Consolas;font-size:10.5pt'><!--StartFragment--><span\r\nstyle='color:#569CD6'>let</span><span style='color:#686868'>&nbsp;</span><span\r\nstyle='color:#8A8A67'>fooFunc</span><span style='color:#686868'>:&nbsp;</span><span\r\nstyle='color:#48B8A1'>Function</span><span style='color:#686868'>;</span><!--EndFragment--></p>\r\n\r\n</body>\r\n\r\n</html>\r\n";
            string result;

            result = target.GetHtml ();

            Assert.AreEqual(expected, result);

        }
    }
}