namespace DocxPreview.Blazor;

public class DocxRenderOptions
{
    public string ClassName { get; set; } = "docx";
    public bool InWrapper { get; set; } = true;
    public bool HideWrapperOnPrint { get; set; } = false;
    public bool IgnoreWidth { get; set; } = false;
    public bool IgnoreHeight { get; set; } = false;
    public bool IgnoreFonts { get; set; } = false;
    public bool BreakPages { get; set; } = true;
    public bool IgnoreLastRenderedPageBreak { get; set; } = true;
    public bool Experimental { get; set; } = false;
    public bool TrimXmlDeclaration { get; set; } = true;
    public bool UseBase64URL { get; set; } = false;
    public bool RenderChanges { get; set; } = false;
    public bool RenderHeaders { get; set; } = true;
    public bool RenderFooters { get; set; } = true;
    public bool RenderFootnotes { get; set; } = true;
    public bool RenderEndnotes { get; set; } = true;
    public bool RenderComments { get; set; } = false;
    public bool RenderAltChunks { get; set; } = true;
    public bool Debug { get; set; } = false;

    internal object ToJsObject()
    {
        return new
        {
            className = ClassName,
            inWrapper = InWrapper,
            hideWrapperOnPrint = HideWrapperOnPrint,
            ignoreWidth = IgnoreWidth,
            ignoreHeight = IgnoreHeight,
            ignoreFonts = IgnoreFonts,
            breakPages = BreakPages,
            ignoreLastRenderedPageBreak = IgnoreLastRenderedPageBreak,
            experimental = Experimental,
            trimXmlDeclaration = TrimXmlDeclaration,
            useBase64URL = UseBase64URL,
            renderChanges = RenderChanges,
            renderHeaders = RenderHeaders,
            renderFooters = RenderFooters,
            renderFootnotes = RenderFootnotes,
            renderEndnotes = RenderEndnotes,
            renderComments = RenderComments,
            renderAltChunks = RenderAltChunks,
            debug = Debug
        };
    }
}
