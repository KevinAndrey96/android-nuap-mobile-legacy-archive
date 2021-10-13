namespace nuap.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Services;
    using System.Collections.Generic;
    using System.Linq;
    using Xamarin.Forms;
    using Models;
    using Views;

    public class AddressViewModel: BaseViewModel
    {
        private ApiService apiService;
        private ObservableCollection<Address> address;
        private List<Address> list;
        private bool isRefreshing;

        public ObservableCollection<Address> Address
        {
            get { return this.address; }
            set { SetValue(ref this.address, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadAddress);
            }
        }

        public ICommand ReturnCommand
        {
            get
            {
                return new RelayCommand(Return);
            }
        }

        public ICommand CreateAddressCommand
        {
            get
            {
                return new RelayCommand(CreateAddress);
            }
        }

        public AddressViewModel()
        {
            this.apiService = new ApiService();
            this.LoadAddress();
        }

        private async void LoadAddress()
        {
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Aceptar");
                return;
            }

            var mainViewModel = MainViewModel.GetInstance();

            var response = await this.apiService.GetAddress(
                mainViewModel.User.api_token,
                "https://thenuap.com");

            if (response == null)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ha ocurrido un error",
                    "Aceptar");
                return;
            }

            if (response.Data == null)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "",
                    "Debes agregar una dirección para poder continuar",
                    "Aceptar");

                if (Device.RuntimePlatform == Device.iOS)
                {
                    string url = "https://thenuap.com/create-address?";
                    string user = "user=" + mainViewModel.User.id;
                    url += user;

                    mainViewModel.PaymentGateway = new PaymentGatewayViewModel(url);
                    await Application.Current.MainPage.Navigation.PushAsync(new PaymentGatewayPage());
                }
                else
                {
                    mainViewModel.CreateAddress = new CreateAddressViewModel();
                    await Application.Current.MainPage.Navigation.PushAsync(new CreateAddressPage());
                }
            } else
            {
                this.list = response.Data;

                this.Address = new ObservableCollection<Address>(ToAddressItemViewModel(this.list));
                this.IsRefreshing = false;
            }
        }

        private async void CreateAddress()
        {
            var mainViewModel = MainViewModel.GetInstance();

            if (Device.RuntimePlatform == Device.iOS)
            {
                string url = "https://thenuap.com/create-address?";
                string user = "user=" + mainViewModel.User.id;
                url += user;

                mainViewModel.PaymentGateway = new PaymentGatewayViewModel(url);
                await Application.Current.MainPage.Navigation.PushAsync(new PaymentGatewayPage());
            } else
            {
                mainViewModel.CreateAddress = new CreateAddressViewModel();
                await Application.Current.MainPage.Navigation.PushAsync(new CreateAddressPage());
            }            
        }

        private IEnumerable<AddressItemViewModel> ToAddressItemViewModel(List<Address> list)
        {
            return list.Select(a => new AddressItemViewModel
            {
                Id = a.Id,
                Addres = a.Addres,
                Latitude = a.Latitude,
                Longitude = a.Longitude,
                City = a.City,
                Location = a.Location,
                Neighborhood = a.Neighborhood
            });
        }

        private async void Return()
        {
            var mainViewModel = MainViewModel.GetInstance();
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
