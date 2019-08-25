using GalaSoft.MvvmLight;

namespace HelloFirebaseLibrary.ViewModel
{
    public class VMBase : ViewModelBase
    {
        private bool _IsBusy = false;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set { Set(nameof(IsBusy), ref _IsBusy, value); }
        }

        public VMBase()
        {

        }
    }
}
