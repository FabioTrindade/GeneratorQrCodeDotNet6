using System.Reflection.Emit;
using GeneratorQrCodeDotNet6.Providers;
using Microsoft.AspNetCore.Mvc;
using SkiaSharp;
using SkiaSharp.QrCode;

namespace GeneratorQrCodeDotNet6.Controllers;

public class QrCodeController : Controller
{
    private readonly IQrCodeProvider _qrCodeProvider;

    public QrCodeController(IQrCodeProvider qrCodeProvider)
    {
        _qrCodeProvider = qrCodeProvider;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(string qrTexto)
    {
        var result = await _qrCodeProvider.GetPic(qrTexto);

        return View(result);
    }
}