# PDFHelper
## Overview
PDFHelper is a console application that allows you to:

1. Convert PDF to Text: Extract and display the text from a PDF.
2. Convert Text to PDF: Create a PDF from user-entered text, with an optional header.

## Dependencies
- .NET SDK
- Itext
- Itext.bouncy.castle-adapter
### How to install dependencies via NuGet:
```bash
dotnet add package itext --version 8.0.5
dotnet add package itext.bouncy-castle-adapter --version 8.0.5
```
## Running the Program
### Clone the repository:

```bash
git clone https://github.com/loganmwiggins/PDFHelper.git
```
### Build and run the application:
```bash
dotnet build
dotnet run
