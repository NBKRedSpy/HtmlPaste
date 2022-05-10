using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HtmlPaste
{
    /// <summary>
    /// Parser for the clipboard HTML format
    /// </summary>
    public class ClipboardHtml
    {
        public int StartHtml { get; set; }
        public int EndHtml { get; set; }

        public int StartFragment { get; set; }
        public int EndFragment { get; set; }

        public string ClipboardText { get; set; }

        public ClipboardHtml()
        {

        }

        public ClipboardHtml(string source)
        {
            Load(source);
        }

        public void Load(string source)
        {
            ClipboardText  = source;

            StartHtml = GetValue(source, "StartHTML");
            EndHtml = GetValue(source, "EndHTML");
            StartFragment = GetValue(source, "StartFragment");
            EndFragment = GetValue(source, "EndFragment");
        }

        private int GetValue(string source, string item)
        {
            Match itemMatch = Regex.Match(source, $"^{item}:(\\d+)", RegexOptions.Multiline);

            if (itemMatch.Success == false)
            {
                throw new ApplicationException($"cannot find item '{item}'");
            }

            return int.Parse(itemMatch.Groups[1].Value);
        }

        /// <summary>
        /// Returns the HTML fragment part of the clipboard text.
        /// Generally does not include the body
        /// </summary>
        /// <returns></returns>
        public string GetFragment()
        {
            return ClipboardText.Substring(StartFragment, EndFragment - StartFragment);
        }

        /// <summary>
        /// Returns the full HTML in the clipboard.  
        /// Starts with HTML and generally includes meta data from the source.
        /// </summary>
        /// <returns></returns>
        public string GetHtml()
        {
            return ClipboardText.Substring(StartHtml, EndHtml - StartHtml);
        }

    }
}
