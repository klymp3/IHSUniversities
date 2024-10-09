IronWord is a library developed and maintained by Iron Software that helps C# Software Engineers load, manipulate, and save Word documents in .NET applications & websites.

Visit our website for a quick-start guide at: https://ironsoftware.com/csharp/word/

C# Code Example
========================
using IronWord;
using IronWord.Models;
using IronSoftware.Drawing;

// Load an existing DOCX
var docx1 = new WordDocument("existing.docx");

// Or, make a new DOCX
var docx_new = new WordDocument();

// Add text to a paragraph
Paragraph paragraph = new();
paragraph.AddText("Hello IronWord!");

// Add image to a paragraph
Image image = new Image("example.jpg");
image.Width = 400; // px
image.Height = 300; // px
image.Position = new ElementPosition()
{
    X = 0, // pts
    Y = 72  // pts
};
paragraph.AddImage(image);

// Add paragraph
docx1.AddParagraph(paragraph);

// Save over the existing DOCX
docx1.Save("existing.docx");

// Or save as a new DOCX
docx1.SaveAs("output.docx");

Documentation Links
========================
- Code Samples	:   https://ironsoftware.com/csharp/word/examples/create-empty-word/
- Tutorials		:   https://ironsoftware.com/csharp/word/tutorials/document-element/
- API Reference   :   https://ironsoftware.com/csharp/word/object-reference/api/
- Licensing       :   https://ironsoftware.com/csharp/word/licensing/
- Support         :   support@ironsoftware.com

Compatibility
========================
* C#, F#, and VB.NET
* .NET 8, .NET 7, .NET 6, .NET 5, Core 2x & 3x, Standard 2.0 & 2.1, and Framework 4.6.2+
* Mobile, Console, Web, and Desktop Application
* Windows 10+, macOS 10.14, Linux (Debian, CentOS, Ubuntu), Android, iOS 12, Docker, Azure, and AWS
* Microsoft Visual Studio or Jetbrains ReSharper & Rider
