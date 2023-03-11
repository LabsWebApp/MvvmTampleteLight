using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLight.WpfView.ViewModels.Vms
{
    class SumViewModel : ViewModelBase
    {
        private readonly Func<int, int, int> _getSum = (x, y) => CalcModel.Calc.Sum(x, y);

        private int _x;
        public int X 
        { 
            get => _x;
            set
            {
                if (SetField(ref _x, value)) SetResult();
            }
        }

        private int _y;
        public int Y
        {
            get => _y;
            set
            {
                if (SetField(ref _y, value)) SetResult();
            }
        }

        public int Result { get; private set; }

        private void SetResult()
        {
            Result = _getSum(_x, _y);
            OnPropertyChanged(nameof(Result));
        }
    }
}
