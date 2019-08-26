using FirebaseStandard.Authentication;
using GalaSoft.MvvmLight.Command;
using HelloFirebaseLibrary.Model;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HelloFirebaseLibrary.ViewModel
{
    public class ViewModel_SignIn : VMBase
    {
        #region events
        public event EventHandler<ResponseResult> OnSignInResult;
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
        public ICommand Command_Cancel { get; set; }
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
        async void Command_SignIn_Click()
        {
            this.IsBusy = true;

            try
            {
                await this.FirebaseAuth.SignInWithEmailAndPasswordAsync(this.Email, this.Password);
                this.OnSignInResult?.Invoke(this, new ResponseResult()
                {
                    Result = true
                });
            }
            catch(FirebaseAuthException fae)
            {
                ResponseResult rr = new ResponseResult()
                {
                    Exception = fae,
                    Result = false
                };

                if(fae.Reason == AuthErrorReason.WrongPassword)
                {
                    rr.Message = "Incorrect password";

                    this.OnSignInResult?.Invoke(this, rr);
                }
                else
                {
                    rr.Message = "Something went wrong while signing-in.";

                    this.OnSignInResult?.Invoke(this, rr);
                }
            }

            this.IsBusy = false;
        }

        void Command_SignUp_Click()
        {
            this.ShowSignInView = false;
            this.ShowSignUpView = true;
        }

        void Command_Cancel_Click()
        {
            this.ShowSignInView = true;
            this.ShowSignUpView = false;
        }
        #endregion

        #region methods
        void InitCommands()
        {
            if (Command_SignIn == null) Command_SignIn = new RelayCommand(Command_SignIn_Click);
            if (Command_SignUp == null) Command_SignUp = new RelayCommand(Command_SignUp_Click);
            if (Command_Cancel == null) Command_Cancel = new RelayCommand(Command_Cancel_Click);
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
