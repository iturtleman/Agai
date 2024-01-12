namespace AgaiUI.Data
{
    using Microsoft.AspNetCore.Components.Forms;

    public record struct HelpfulFileData(IBrowserFile FileInfo, string FullyQualifiedFilePath)
    {
        public string OriginalFileName => FullyQualifiedFilePath.Split("__").First();
    };
}