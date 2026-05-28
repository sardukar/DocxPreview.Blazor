# DocxPreview.Blazor

Blazor component for previewing DOCX documents, powered by [docx-preview](https://github.com/VolodymyrBaydalka/docxjs).

## Features

- Render `.docx` files directly in Blazor apps (Server and WebAssembly)
- All JavaScript dependencies bundled in the NuGet package — **no CDN, works offline**
- Full set of docx-preview rendering options exposed via `DocxRenderOptions`
- Clean API with JS isolation (no manual `<script>` tags needed)

## Installation

```bash
dotnet add package DocxPreview.Blazor
```

## Usage

```razor
@using DocxPreview.Blazor

<DocxPreview DocumentBytes="@fileBytes"
             Options="@new DocxRenderOptions { BreakPages = true, InWrapper = true }" />
```

### Parameters

| Parameter | Type | Description |
|---|---|---|
| `DocumentBytes` | `byte[]` | Raw `.docx` file content |
| `Options` | `DocxRenderOptions?` | Rendering options (see below) |
| `Class` | `string?` | Additional CSS class for the container |
| `Style` | `string?` | Inline styles for the container |
| `OnRendered` | `EventCallback` | Callback invoked after rendering completes |

### DocxRenderOptions

All options match the [docx-preview API](https://github.com/VolodymyrBaydalka/docxjs#api):

| Property | Default | Description |
|---|---|---|
| `ClassName` | `"docx"` | Class name prefix for document styles |
| `InWrapper` | `true` | Wrap document content in a page-like container |
| `IgnoreWidth` | `false` | Disable page width rendering |
| `IgnoreHeight` | `false` | Disable page height rendering |
| `IgnoreFonts` | `false` | Disable font rendering |
| `BreakPages` | `true` | Enable page breaks |
| `IgnoreLastRenderedPageBreak` | `true` | Ignore editor-inserted page breaks |
| `Experimental` | `false` | Enable experimental features (tab stops) |
| `UseBase64URL` | `false` | Use base64 URLs for images/fonts |
| `RenderHeaders` | `true` | Render document headers |
| `RenderFooters` | `true` | Render document footers |
| `RenderFootnotes` | `true` | Render footnotes |
| `RenderEndnotes` | `true` | Render endnotes |
| `RenderChanges` | `false` | Render tracked changes (experimental) |
| `RenderComments` | `false` | Render comments (experimental) |
| `Debug` | `false` | Enable debug logging |

### Complete Example

```razor
@page "/preview"
@rendermode InteractiveServer
@using DocxPreview.Blazor

<h3>Upload a DOCX file</h3>

<InputFile OnChange="HandleFile" accept=".docx" />

@if (docxBytes != null)
{
    <DocxPreview DocumentBytes="docxBytes"
                 Options="new DocxRenderOptions { BreakPages = true, RenderHeaders = false }" />
}

@code {
    private byte[]? docxBytes;

    private async Task HandleFile(InputFileChangeEventArgs e)
    {
        using var ms = new MemoryStream();
        await e.File.OpenReadStream(50 * 1024 * 1024).CopyToAsync(ms);
        docxBytes = ms.ToArray();
    }
}
```

## Requirements

- .NET 8.0+
- Blazor Server or Blazor WebAssembly

## License

Licensed under the Apache License, Version 2.0.

The bundled `docx-preview.js` and `jszip.js` libraries are distributed under their respective licenses:
- docx-preview — [Apache 2.0](https://github.com/VolodymyrBaydalka/docxjs)
- JSZip — [MIT/GPLv3](https://github.com/Stuk/jszip)
