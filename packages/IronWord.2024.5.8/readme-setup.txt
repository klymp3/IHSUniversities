IronWord - The Word Library for .NET
=============================================================
Quickstart:  https://ironsoftware.com/csharp/word/

Compatibility
=============================================================
Supports applications and websites developed in:
- .NET Framework 4.6.2 (and above) for Windows, Linux, macOS, Android, and Azure
- .NET Core 2, 3 (and above) Windows, Linux, macOS, Android, and Azure
- .NET 5 for Windows, Linux, macOS, Android, and Azure
- .NET 6 for Windows, Linux, macOS, Android, and Azure
- .NET 7 for Windows, Linux, macOS, Android, and Azure
- .NET 8 for Windows, Linux, macOS, Android, and Azure

C# Code Example
=============================================================
```csharp
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
```

Documentation
=============================================================

- Code Samples	:   https://ironsoftware.com/csharp/word/examples/create-empty-word/
- Tutorials		:   https://ironsoftware.com/csharp/word/tutorials/document-element/
- API Reference :   https://ironsoftware.com/csharp/word/object-reference/api/
- Licensing     :   https://ironsoftware.com/csharp/word/licensing/
- Support       :   support@ironsoftware.com
