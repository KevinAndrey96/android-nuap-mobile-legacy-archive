namespace nuap.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;

    public class CartEmptyViewModel: BaseViewModel
    {
        public ICommand InitPageCommand
        {
            get
            {
                return new RelayCommand(InitPage);
            }
        }

        public ICommand ReturnCommand
        {
            get
            {
                return new RelayCommand(Return);
            }
        }

        public CartEmptyViewModel()
        {
        }

        private async void InitPage()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.HomeCommerce = new HomeCommerceViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new HomeCommerceTabbedPage());
        }

        private async void Return()
        {
            var mainViewModel = MainViewModel.GetInstance();
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}