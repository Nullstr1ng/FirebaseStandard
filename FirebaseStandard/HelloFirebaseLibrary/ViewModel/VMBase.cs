using FirebaseStandard.Authentication;
using GalaSoft.MvvmLight;

namespace HelloFirebaseLibrary.ViewModel
{
    public class VMBase : ViewModelBase
    {
        public FirebaseAuthProvider FirebaseAuth { get; set; } = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyD23hI5mrm_nwwSqpIUdTGLdcVF2UWT-4E"));

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
