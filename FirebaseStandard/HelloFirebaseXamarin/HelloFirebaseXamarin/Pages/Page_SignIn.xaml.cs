using HelloFirebaseLibrary.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloFirebaseXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_SignIn : ContentPage
    {
        public Page_SignIn()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((ViewModelLocator)this.BindingContext).SignUp.OnRegistrationStatus += (s, rr) =>
            {
                if((bool)rr.Result)
                {
                    DisplayAlert("Registration Status", "Successfully registered!", "Close");
                }
                else
                {
                    DisplayAlert("Registration Status", $"Failed! Message \"{rr.Message}\"", "Close");
                }
            };

            ((ViewModelLocator)this.BindingContext).SignIn.OnSignInResult += (s, rr) =>
            {
                if((bool)rr.Result)
                {
                    DisplayAlert("Sign-in Status", "Signed-in!", "Close");
                }
                else
                {
                    DisplayAlert("Sign-in Status", $"Failed! Message \"{rr.Message}\"", "Close");
                }
            };
        }
    }
}