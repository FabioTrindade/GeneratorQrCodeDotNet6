using System;
using SkiaSharp;
using SkiaSharp.QrCode;

namespace GeneratorQrCodeDotNet6.Providers
{
	public class QrCodeProvider : IQrCodeProvider
    {

		public async Task<byte[]> GetPic(string value)
		{
            using var generator = new QRCodeGenerator();

            // Generate QrCode
            var qr = generator.CreateQrCode(value, ECCLevel.L, quietZoneSize: 1);

            // Render to canvas
            var info = new SKImageInfo(256, 256);

            using var surface = SKSurface.Create(info);
            var canvas = surface.Canvas;
            canvas.Render(qr, info.Width, info.Height);

            // Output to Stream -> Memory
            using var image = surface.Snapshot();
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            using var stream = new MemoryStream();
            data.SaveTo(stream);

            return await Task.FromResult(stream.ToArray());
        }

	}
}