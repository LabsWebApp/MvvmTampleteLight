using System.Windows.Input;
using static DataModels.Helpers;

namespace DemoLight.WpfView.ViewModels.Vms
{
    internal class CaptchaViewModel : ViewModelBase
    {
        private (string Code, byte[] Image) _model;

        public CaptchaViewModel()
        {
            _model = CaptchaModel.Captcha.GenerateImageAsByteArray();
            _captchaImage = _model.Image;
            CaptchaRefresh = new CommonCommand(() =>
            {
                _model = CaptchaModel.Captcha.GenerateImageAsByteArray();
                CaptchaImage = _model.Image;
            }, () => !CaptchaOk);
        }

        public ICommand CaptchaRefresh { get; }

        private byte[] _captchaImage;

        public byte[] CaptchaImage
        {
            get => _captchaImage;
            set => SetField(ref _captchaImage, value);
        }

        public string CaptchaCode
        {
            set
            {
                CaptchaOk = VerifyHashedString(value, _model.Code);
                OnPropertyChanged(nameof(CaptchaOk));
            }
        }

        public virtual bool CaptchaOk { get; private set; }
    }
}
