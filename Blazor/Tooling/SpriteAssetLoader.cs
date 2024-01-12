using System.Drawing;
using Microsoft.AspNetCore.Components;
namespace AgaiUI.Core.Assets;

public class SpriteAssetLoader : IAssetLoader<Sprite>
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<SpriteAssetLoader> _logger;

    public SpriteAssetLoader(HttpClient httpClient, ILogger<SpriteAssetLoader> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async ValueTask<Sprite> Load(string path)
    {
        _logger.LogInformation($"loading sprite from path: {path}");

        var bytes = await _httpClient.GetByteArrayAsync(path);
        await using var stream = new MemoryStream(bytes);
        using var image = await SixLabors.ImageSharp.Image.LoadAsync(stream);
        var size = new Size(image.Width, image.Height);

        var elementRef = new ElementReference(Guid.NewGuid().ToString());
        return new Sprite(path, elementRef, size, bytes, ImageFormatUtils.FromPath(path));
    }
}
public class Sprite : IAsset
{
    public Sprite(string name, ElementReference source, Size size, byte[] data, ImageFormat format)
    {
        Name = name;
        Source = source;
        Size = size;
        Origin = new Point(size.Width / 2, size.Height / 2);
        Data = data;
        Format = format;
    }

    public string Name { get; }
    public ElementReference Source { get; set; }
    public Size Size { get; }
    public byte[] Data { get; }
    public ImageFormat Format { get; }
    public Point Origin { get; set; }
}
