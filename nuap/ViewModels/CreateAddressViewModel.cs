namespace nuap.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    using Xamarin.Forms.GoogleMaps;
    using Services;
    using Views;
    using System;
    using Helpers;
    using Newtonsoft.Json;

    public class CreateAddressViewModel
    {
        private ApiService apiService;
        public ObservableCollection<Pin> PinList { get; set; }
       
        private bool isEnabled = true;
        private string city;
        private string location;
        private string neighborhood;
        private string address;

        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                isEnabled = value;
            }
        }

        public string City
        {
            get { return city; }
            set
            {
                city = value;
            }
        }

        public string Location
        {
            get { return location; }
            set
            {
                location = value;
            }
        }

        public string Neighborhood
        {
            get { return neighborhood; }
            set
            {
                neighborhood = value;
            }
        }

        public string Address
        {
            get { return address; }
            set
            {
                address = value;
            }
        }

        public Command<MapClickedEventArgs> MapClickedCommand =>
            new Command<MapClickedEventArgs>(async args =>
            {
                PinList.Clear();
                PinList.Add(new Pin
                { 
                    Label = "",
                    Position = args.Point
                });
            });

        public Command CreateAddressCommand => new Command(
            async () => await CreateAddress()
        );

        public async Task CreateAddress()
        {
            string lat = null;
            string lon = null;

            try
            {
                lat = PinList.First().Position.Latitude.ToString();
                lon = PinList.First().Position.Longitude.ToString();
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert(
                        "Atención",
                        "Debes seleccionar una ubicación en el mapa",
                        "Aceptar"
                    );
                return;
            }

            if (string.IsNullOrEmpty(this.Address))
            {
                this.IsEnabled = false;

                await Application.Current.MainPage.DisplayAlert(
                        "Atención",
                        "Debes ingresar una dirección",
                        "Aceptar"
                    );
                return;
            }

            if (string.IsNullOrEmpty(this.City))
            {
                this.IsEnabled = false;

                await Application.Current.MainPage.DisplayAlert(
                        "Atención",
                        "Debes ingresar una ciudad",
                        "Aceptar"
                    );
                return;
            }

            if (string.IsNullOrEmpty(this.Location))
            {
                this.IsEnabled = false;

                await Application.Current.MainPage.DisplayAlert(
                        "Atención",
                        "Debes ingresar una localidad",
                        "Aceptar"
                    );
                return;
            }

            if (string.IsNullOrEmpty(this.Neighborhood))
            {
                this.IsEnabled = false;

                await Application.Current.MainPage.DisplayAlert(
                        "Atención",
                        "Debes ingresar un barrio",
                        "Aceptar"
                    );
                return;
            }

            this.apiService = new ApiService();

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

            var response = await this.apiService.CreateAddress(
                mainViewModel.User.api_token,
                "https://thenuap.com",
                this.City,
                this.Location,
                this.Neighborhood,
                this.Address,
                lat,
                lon
            );

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

            await Application.Current.MainPage.DisplayAlert(
                    "",
                    "Se ha creado exitosamente la dirección",
                    "Aceptar");

            var responseAddress = await this.apiService.GetAddress(
                mainViewModel.User.api_token,
                "https://thenuap.com");

            if (response == null)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ha ocurrido un error",
                    "Aceptar");
                return;
            }

            var list = responseAddress.Data;
            mainViewModel.AddressDetail = list[0];
            Settings.AddressDetail = JsonConvert.SerializeObject(mainViewModel.AddressDetail);


            mainViewModel.HomeCommerce = new HomeCommerceViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new HomeCommerceTabbedPage());
        }
    }
}