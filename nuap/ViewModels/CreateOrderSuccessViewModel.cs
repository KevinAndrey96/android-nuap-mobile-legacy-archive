namespace nuap.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;

    public class CreateOrderSuccessViewModel: BaseViewModel
    {
        public ICommand ReturnHomeCommand
        {
            get
            {
                return new RelayCommand(ReturnHome);
            }
        }

        public CreateOrderSuccessViewModel()
        {
        }

        private async void ReturnHome()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.HomeCommerce = new HomeCommerceViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new HomeCommerceTabbedPage());
        }
    }
}
