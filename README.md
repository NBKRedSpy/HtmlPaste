# HtmlPaste
Converts HTML content on the clipboard to the HTML code version

Some programs can render text styled with HTML, but will convert the HTML to pure text when pasted.

A good example is trying to paste HTML from a website into the Visual Studio Code markdown editor.

Using HTML paste, the actual HTML code can be added to the md editor:

![image](https://user-images.githubusercontent.com/54865934/167646598-593ad25c-9b45-4da6-9383-609eb2e5584c.png)


# Usage
* Copy formatted HTML to the clipboard (for example from the browser).
* Run HtmlPaste.exe
* The HTML on the clipboard has now been converted to HTML code.  Paste to the target application.

# Commands
```
HtmlPaste:
  Replaces HTML formatted text to the text version

Usage:
  HtmlPaste [options]

Options:
  -f, --full-html    Returns the full HTML from the clipboard text rather than only the HTML fragment
  -r, --raw          Returns the full clipboard HTML text, including clipboard headers.
  -c, --console      Outputs to the console instead of copying the result to the clipboard
  --version          Show version information
  -?, -h, --help     Show help and usage information
```

# Limitations
The output is from the HTML provided by the source application.  It can be very long as the styling is generally not consolidated.

This app tries to get the HTML version of the text from the clipboard.  If the source application does not create the HTML Format entry, this app will not create HTML code.
