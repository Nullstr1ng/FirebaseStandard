using GalaSoft.MvvmLight.Ioc;

namespace HelloFirebaseLibrary.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<ViewModel_SignUp>();
            SimpleIoc.Default.Register<ViewModel_SignIn>();
        }

        public ViewModel_SignUp SignUp
        {
            get
            {
                return SimpleIoc.Default.GetInstance<ViewModel_SignUp>();
            }
        }

        public ViewModel_SignIn SignIn
        {
            get
            {
                return SimpleIoc.Default.GetInstance<ViewModel_SignIn>();
            }
        }
    }
}
