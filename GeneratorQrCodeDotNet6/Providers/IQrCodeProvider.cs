using System;
namespace GeneratorQrCodeDotNet6.Providers
{
	public interface IQrCodeProvider
	{
        Task<byte[]> GetPic(string value);
    }
}

