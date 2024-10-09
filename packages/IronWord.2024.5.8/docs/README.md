![Nuget](https://img.shields.io/nuget/v/IronWord?color=informational&label=latest)  ![Installs](https://img.shields.io/nuget/dt/IronWord?color=informational&label=installs&logo=nuget)  ![Passed](https://img.shields.io/badge/build-%20%E2%9C%93%20522%20tests%20passed%20(0%20failed)%20-107C10?logo=visualstudio) ![windows](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=windows) ![macOS](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=apple) ![linux](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=linux&logoColor=white) ![docker](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=docker&logoColor=white) ![aws](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=amazonaws) ![microsoftazure](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=microsoftazure) [![livechat](https://img.shields.io/badge/Live%20Chat:-24/5-purple?logo=googlechat&logoColor=white)](https://ironsoftware.com/csharp/word/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield#helpscout-support)

# IronWord - The C# Word Library

[![IronWord NuGet Trial Banner Image](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronWord-readme/nuget-trial-banner.png)](https://ironsoftware.com/csharp/word/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topbanner#trial-license)

IronWord is a library developed and maintained by Iron Software that helps C# Software Engineers to load, manipulate, and save Word document in .NET applications & websites.
 
### IronWord excels at:
- Loading, manipulating, and saving Word and DOCX documents.
- PageSetup: Configuring paper size, page orientation, margins, and background color.
- TextRun: Handling text content, styles, splitting, appending text, and adding images.
- TextStyle: Managing font family, size, color, bold, italic, strikethrough, underline, superscript, and subscript.
- Paragraph: Adding text runs, images, shapes, setting styles, alignments, bullets, and numbering lists.
- Table: Manipulating table structure, including adding rows, getting and setting cell values, removing rows, merging cells, and more.
- Image: Loading images from files or streams, setting wrap text, position offset, width, height, and other properties.
- Shape: Setting wrap text, position offset, width, height, shape type, and rotation.

And much more! *Visit [our website](https://ironsoftware.com/csharp/word/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=featureslist) to see all our [code examples](https://ironsoftware.com/csharp/word/examples/add-text/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=featureslist) and a [full list of our features](https://ironsoftware.com/csharp/word/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=featureslist)*

### IronWord Has Cross Platform Support Compatibility With:
- **.NET 8**, .NET 7, .NET 6 and .NET 5, Core 2x & 3x, Standard 2, and Framework 4.6.2+
- Windows, macOS, Linux, Docker, Azure, and AWS

[![IronWord Cross Platform Compatibility Support Image](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronWord-readme/cross-platform-compatibility.png)](https://ironsoftware.com/csharp/word/docs/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=crossplatformbanner)

Our [API reference](https://ironsoftware.com/csharp/word/object-reference/api/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs) and [full licensing information](https://ironsoftware.com/csharp/word/licensing/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs#trial-license) can be found easily on our website.

## Using IronWord

You can install the IronWord NuGet package by simply entering this command in your package manager console:

```
PM> Install-Package IronWord
```

Once installed, add `using IronWord;` to the top of your C# code. Here is a code example to get started with loading, editing, and saving a document:

```csharp
using IronWord;
using IronWord.Models;
using IronSoftware.Drawing;

// Load an existing DOCX
var docx1 = new WordDocument("existing.docx");

// Or, make a new DOCX
var docx_new = new WordDocument();

// Add a paragraph with text
Paragraph paragraph = new();
var textRun = new TextRun()
{
    Text = "Hello IronWord!"
};
paragraph.AddTextRun(textRun);

docx1.AddParagraph(paragraph);

// Add a paragraph with an image
TextRun textRunWithImage = new TextRun();
Image image = new Image("example.jpg");
image.Width = 400; // px
image.Height = 300; // px
image.Position = new ElementPosition() {
    X = 0, // pts
    Y = 72  // pts
};
textRunWithImage.AddChild(image);
docx1.AddParagraph(new Paragraph(textRunWithImage));

// Save over the existing DOCX
docx1.Save("existing.docx");

// Or save as a new DOCX
docx1.SaveAs("output.docx");
```

## Features Table

[![IronWord Features](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronWord-readme/features-table.png)](https://ironsoftware.com/csharp/word/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=featuresbanner)

## Licensing & Support available
For our full list of code examples, tutorials, licensing information, and documentation visit: [https://ironsoftware.com/csharp/word/](https://ironsoftware.com/csharp/word/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)

For support please email us at: support@ironsoftware.com 

## Documentation Links
- How-To Guides : [https://ironsoftware.com/csharp/word/how-to/](https://ironsoftware.com/csharp/word/how-to/html-file-to-pdf/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)
- Code Examples : [https://ironsoftware.com/csharp/word/examples/](https://ironsoftware.com/csharp/word/examples/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)
- API Reference : [https://ironsoftware.com/csharp/word/object-reference/api/](https://ironsoftware.com/csharp/word/object-reference/api/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)
- Tutorials : [https://ironsoftware.com/csharp/word/tutorials/](https://ironsoftware.com/csharp/word/tutorials/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)
- Licensing : [https://ironsoftware.com/csharp/word/licensing/](https://ironsoftware.com/csharp/word/licensing/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)
- Live Chat Support : [https://ironsoftware.com/csharp/word/#helpscout-support](https://ironsoftware.com/csharp/word/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs#helpscout-support)