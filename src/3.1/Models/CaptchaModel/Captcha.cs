using System;
using CaptchaGen.SkiaSharp;
using static DataModels.Helpers;

namespace CaptchaModel
{
    public static class Captcha
    {
        public static (string captchaHashCode, byte[] image) GenerateImageAsByteArray()
        {
#if DEBUG
            var code = new Random().Next(10, 99).ToString();
#else
            var code = new Random().Next(100_000, 999_999).ToString();
#endif

            return (GetHashString(code), new CaptchaGenerator().GenerateImageAsByteArray(code));
        }
    }
}