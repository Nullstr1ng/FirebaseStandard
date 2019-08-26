using HelloFirebaseLibrary.ViewModel;
using System.Windows;

namespace HelloFirebaseWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ((ViewModelLocator)this.DataContext).SignUp.OnRegistrationStatus += (s, rr) =>
            {
                if ((bool)rr.Result)
                {
                    MessageBox.Show("Successfully registered!", "Registration Status");
                }
                else
                {
                    MessageBox.Show($"Failed! Message \"{rr.Message}\"", "Registration Status");
                }
            };

            ((ViewModelLocator)this.DataContext).SignIn.OnSignInResult += (s, rr) =>
            {
                if ((bool)rr.Result)
                {
                    MessageBox.Show("Signed-in!", "Sign-in Status");
                }
                else
                {
                    MessageBox.Show($"Failed! Message \"{rr.Message}\"", "Sign-in Status");
                }
            };
        }
    }
}
