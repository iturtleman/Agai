namespace AgaiUI.Data
{
    using System;
    using System.IO;
    using System.Threading;
    using Microsoft.AspNetCore.Components.Forms;

    public record MySQLiteFile : IBrowserFile
    {
        private readonly string fullyQualifiedFilePath;

        public MySQLiteFile(string fullyQualifiedFilePath, string contentType)
        {
            this.fullyQualifiedFilePath = fullyQualifiedFilePath;
            var fi = new FileInfo(fullyQualifiedFilePath);
            LastModified = fi.LastWriteTime;
            Size= fi.Length;
            ContentType = contentType;
        }

        public string Name => Path.GetFileName(fullyQualifiedFilePath);

        public DateTimeOffset LastModified { get; }

        public long Size { get; }

        public string ContentType { get; }

        public Stream OpenReadStream(long maxAllowedSize = long.MaxValue, CancellationToken cancellationToken = default)
        {
            if (Size > maxAllowedSize)
            {
                throw new IOException($"Supplied file with size {Size} bytes exceeds the maximum of {maxAllowedSize} bytes.");
            }

            return File.OpenRead(fullyQualifiedFilePath);
        }
    }
}