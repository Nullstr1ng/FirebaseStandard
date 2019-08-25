using GalaSoft.MvvmLight.Command;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HelloFirebaseLibrary.ViewModel
{
    public class ViewModel_SignIn : VMBase
    {
        #region events

        #endregion

        #region vars

        #endregion

        #region properties
        private bool _ShowSignInView = false;
        public bool ShowSignInView
        {
            get { return _ShowSignInView; }
            set { Set(nameof(ShowSignInView), ref _ShowSignInView, value); }
        }

        private bool _ShowSignUpView = false;
        public bool ShowSignUpView
        {
            get { return _ShowSignUpView; }
            set { Set(nameof(ShowSignUpView), ref _ShowSignUpView, value); }
        }

        private string _Email = string.Empty;
        public string Email
        {
            get { return _Email; }
            set { Set(nameof(Email), ref _Email, value); }
        }

        private string _Password = string.Empty;
        public string Password
        {
            get { return _Password; }
            set { Set(nameof(Password), ref _Password, value); }
        }
        #endregion

        #region commands
        public ICommand Command_SignIn { get; set; }
        public ICommand Command_SignUp { get; set; }
        #endregion

        #region ctors
        public ViewModel_SignIn()
        {
            InitCommands();

            // used only in UWP & WPF
            // or anything that supports design time updates
            if (base.IsInDesignMode)
            {
                DesignData();
            }
            else
            {
                RuntimeData();
            }
        }
        #endregion

        #region command methods
        void Command_SignIn_Click()
        {
        }

        void Command_SignUp_Click()
        {
            this.ShowSignInView = false;
            this.ShowSignUpView = true;
        }
        #endregion

        #region methods
        void InitCommands()
        {
            if (Command_SignIn == null) Command_SignIn = new RelayCommand(Command_SignIn_Click);
            if (Command_SignUp == null) Command_SignUp = new RelayCommand(Command_SignUp_Click);
        }

        void DesignData()
        {
            this.ShowSignInView = true;
        }

        void RuntimeData()
        {
            this.ShowSignInView = true;
        }

        public async Task RefreshData()
        {

        }
        #endregion
    }
}
