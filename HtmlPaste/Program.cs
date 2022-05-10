using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HtmlPaste
{
    public class Program
    {
        
        [STAThread]
        static int Main(string[] args)
        {
            try
            {
                RootCommand command = CreateCommandLineParser();

                return command.InvokeAsync(args).Result;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing: {ex.ToString()} ");

                return -1;
            }
        }

        private static RootCommand CreateCommandLineParser()
        {
            var command = new RootCommand("Replaces HTML formatted text to the text version")
                {
                    new Option<bool>(new string[] {"--full-html", "-f" },
                        () => false,
                        "Returns the full HTML from the clipboard text rather than only the HTML fragment"),
                    new Option<bool>(new string[] {"--raw", "-r" },
                        () => false,
                        "Returns the full clipboard HTML text, including clipboard headers."),
                    new Option<bool>(new string[] {"--console", "-c" },
                        () => false,
                        "Outputs to the console instead of copying the result to the clipboard"),

                };

            command.Handler = CommandHandler.Create<bool, bool, bool>((fullHtml, raw, console) =>
            {
                return ParseHtml(fullHtml, raw, console);
            }

);

            return command;
        }

        static int ParseHtml(bool fullHtml, bool raw, bool toConsole)
        {

            string html = Clipboard.GetText(TextDataFormat.Html);

            if (string.IsNullOrEmpty(html) == false)
            {
                string htmlText;

                if (raw)
                {
                    htmlText = html;
                }
                else
                {
                    var clipboardHtml = new ClipboardHtml(html);


                    if(fullHtml)
                    {

                        htmlText = clipboardHtml.GetHtml();
                    }
                    else
                    {
                        htmlText = clipboardHtml.GetFragment();
                    }
                }

                if(toConsole)
                {
                    Console.WriteLine(htmlText);
                }
                else
                {
                    Clipboard.SetText(htmlText, TextDataFormat.UnicodeText);
                }

                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
