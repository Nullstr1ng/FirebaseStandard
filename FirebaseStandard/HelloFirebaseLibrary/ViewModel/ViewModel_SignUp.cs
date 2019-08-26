using FirebaseStandard.Authentication;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using HelloFirebaseLibrary.Model;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HelloFirebaseLibrary.ViewModel
{
    public class ViewModel_SignUp : VMBase
    {
        #region events
        public event EventHandler<ResponseResult> OnRegistrationStatus;
        #endregion

        #region vars

        #endregion

        #region properties
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

        private string _DisplayName = string.Empty;
        public string DisplayName
        {
            get { return _DisplayName; }
            set { Set(nameof(DisplayName), ref _DisplayName, value); }
        }
        #endregion

        #region commands
        public ICommand Command_SignUp { get; set; }
        #endregion

        #region ctors
        public ViewModel_SignUp()
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
        async void Command_SignUp_Click()
        {
            this.IsBusy = true;

            try
            {
                await this.FirebaseAuth.CreateUserWithEmailAndPasswordAsync(this.Email, this.Password, this.DisplayName, false);

                var VMSignIn = SimpleIoc.Default.GetInstance<ViewModel_SignIn>();
                VMSignIn.ShowSignInView = true;
                VMSignIn.ShowSignUpView = false;
                VMSignIn = null;

                this.OnRegistrationStatus?.Invoke(this, new ResponseResult()
                {
                    Result = true
                });
            }
            catch(FirebaseAuthException fae)
            {
                this.OnRegistrationStatus?.Invoke(this, new ResponseResult()
                {
                    Exception = fae,
                    Result = false,
                    Message = fae.Reason == AuthErrorReason.EmailExists ? "Email already exists." : fae.Reason.ToEnumString()
                }); ;
            }
            catch(Exception ex)
            {
                this.OnRegistrationStatus?.Invoke(this, new ResponseResult()
                {
                    Result = false,
                    Exception = ex
                });
            }

            this.IsBusy = false;
        }
        #endregion

        #region methods
        void InitCommands()
        {
            if (Command_SignUp == null) Command_SignUp = new RelayCommand(Command_SignUp_Click);
        }

        void DesignData()
        {

        }

        void RuntimeData()
        {

        }

        public async Task RefreshData()
        {

        }
        #endregion
    }
}
