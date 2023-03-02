using System;
using System.Windows.Controls;
using static DataModels.Helpers;

namespace DemoLight.ViewModels.Vms;

class StartViewModel : ViewModelBase
{
    private readonly (string Code, byte[] Img) _captcha = CaptchaModel.Captcha.GenerateImageAsByteArray();
    public Action? Ok { private get; set; }

    public byte[] Captcha => _captcha.Img;

    public string Code
    {
        set
        {
            if (VerifyHashedString(value, _captcha.Code)) Ok?.Invoke();
        }
    }
}