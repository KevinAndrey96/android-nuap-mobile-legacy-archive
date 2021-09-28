namespace nuap.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using nuap.Views;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Helpers;
    using Newtonsoft.Json;
    using Services;
    using System.Linq;

    public class SelectAddressViewModel : BaseViewModel
    {
        private ApiService apiService;
        private string address;
        private Address selectAddress;
        private bool isEnabled;
        private int addressID;

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        public string Address
        {
            get { return this.address; }
            set { SetValue(ref this.address, value); }
        }

        public ICommand ConfirmCommand
        {
            get
            {
                return new RelayCommand(Confirm);
            }
        }

        public ICommand ReturnCommand
        {
            get
            {
                return new RelayCommand(Return);
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return new RelayCommand(Delete);
            }
        }

        public SelectAddressViewModel(Address selectAddress)
        {
            this.apiService = new ApiService();
            this.Address = selectAddress.Addres;
            this.addressID = selectAddress.Id;
            this.selectAddress = selectAddress;
            this.IsEnabled = true;
        }

        private async void Confirm()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.AddressDetail = this.selectAddress;

            Settings.AddressDetail = JsonConvert.SerializeObject(mainViewModel.AddressDetail);

            mainViewModel.HomeCommerce = new HomeCommerceViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new HomeCommerceTabbedPage());
        }

        private async void Delete()
        {
            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Aceptar");
                return;
            }

            var mainViewModel = MainViewModel.GetInstance();

            var response = await this.apiService.DeleteLocation(
                mainViewModel.User.api_token,
                "https://thenuap.com",
                this.addressID);

            if (response == null)
            {
                this.IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ha ocurrido un error",
                    "Aceptar");
                return;
            }

            if (response.Errors != null)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Información",
                    response.Errors.First().Detail,
                    "Aceptar");
                return;
            }

            this.IsEnabled = false;

            await Application.Current.MainPage.DisplayAlert(
                "Información",
                "Se ha eliminado la dirección",
                "Aceptar");

            if (mainViewModel.AddressDetail.Id == this.selectAddress.Id)
            {
                Settings.AddressDetail = null;
                mainViewModel.AddressDetail = null;

                var resp = await this.apiService.GetAddress(
                    mainViewModel.User.api_token,
                    "https://thenuap.com");

                if (resp == null)
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ha ocurrido un error",
                        "Aceptar");
                    return;
                }

                if (resp.Data == null)
                {
                    mainViewModel.CreateAddress = new CreateAddressViewModel();
                    await Application.Current.MainPage.Navigation.PushAsync(new CreateAddressPage());

                    return;
                }
                else
                {
                    var list = resp.Data;
                    mainViewModel.AddressDetail = list[0];
                    Settings.AddressDetail = JsonConvert.SerializeObject(mainViewModel.AddressDetail);

                    mainViewModel.HomeCommerce = new HomeCommerceViewModel();
                    await Application.Current.MainPage.Navigation.PushAsync(new HomeCommerceTabbedPage());

                    return;
                }
            } else
            {
                mainViewModel.HomeCommerce = new HomeCommerceViewModel();
                await Application.Current.MainPage.Navigation.PushAsync(new HomeCommerceTabbedPage());
            }

            return;
        }

        private async void Return()
        {
            var mainViewModel = MainViewModel.GetInstance();
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
