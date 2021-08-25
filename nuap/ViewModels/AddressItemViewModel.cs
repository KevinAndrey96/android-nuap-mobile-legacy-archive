namespace nuap.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;

    public class AddressItemViewModel : Address
    {
        public ICommand SetAddressCommand
        {
            get
            {
                return new RelayCommand(SetAddress);
            }
        }

        private async void SetAddress()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.SelectAddress = new SelectAddressViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new SelectAddressPage());
        }
    }
}
