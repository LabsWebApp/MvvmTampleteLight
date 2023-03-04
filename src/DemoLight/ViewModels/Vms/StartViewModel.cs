using System;
using System.Windows.Input;
using static DataModels.Helpers;

namespace DemoLight.WpfView.ViewModels.Vms;

class StartViewModel : ViewModelBase
{
    private (string Code, byte[] Img) _model;

    public StartViewModel()
    {
        _model = CaptchaModel.Captcha.GenerateImageAsByteArray();
        _captcha = _model.Img;
        Refresh = new CommonCommand(() =>
        {
            _model = CaptchaModel.Captcha.GenerateImageAsByteArray();
            Captcha = _model.Img;
        });
    }

    public Action? Ok { private get; set; }

    private byte[]? _captcha;
    public byte[]? Captcha
    {
        get => _captcha;
        set => SetField(ref _captcha, value);
    }

    public string Code
    {
        set
        {
            if (VerifyHashedString(value, _model.Code)) Ok?.Invoke();
        }
    }

    public ICommand Refresh { get; }
}