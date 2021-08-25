namespace nuap.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using nuap.Models;
    using nuap.Views;
    using Services;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Helpers;

    public class CreateOrderViewModel : BaseViewModel
    {
        private ApiService apiService;
        private bool isEnabled;

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        public ICommand CreateOrderWithCardCommand
        {
            get
            {
                return new RelayCommand(CreateOrderWithCard);
            }
        }

        public ICommand CreateOrderWithCashCommand
        {
            get
            {
                return new RelayCommand(CreateOrderWithCash);
            }
        }

        public CreateOrderViewModel()
        {
            this.IsEnabled = false;
            this.apiService = new ApiService();
        }

        private async void CreateOrderWithCard()
        {
            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Aceptar");
                return;
            }

            var mainViewModel = MainViewModel.GetInstance();
            var data = new CartDataService();
            data.IsCash = false;
            data.Products = mainViewModel.CartList;

            var response = await this.apiService.CreateOrder(
                 "https://thenuap.com",
                 mainViewModel.User.api_token,
                 mainViewModel.AddressDetail.Id,
                 data);

            if (response == null)
            {
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

            List<int> orders = response.Data.Orders;
            string url = "https://thenuap.com/payment-gateway?";
            string user = "user=" + mainViewModel.User.id;
            int count = 0;
            foreach (var item in orders)
            {
                url += "orders[" + count + "]=" + item + "&";
                count++;
            }

            url += user;

            mainViewModel.CartList = null;

            Settings.CartList = null;
            mainViewModel.PaymentGateway = new PaymentGatewayViewModel(url);
            await Application.Current.MainPage.Navigation.PushAsync(new PaymentGatewayPage());
        }

        private async void CreateOrderWithCash()
        {
            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Aceptar");
                return;
            }

            var mainViewModel = MainViewModel.GetInstance();
            var data = new CartDataService();
            data.IsCash = true;
            data.Products = mainViewModel.CartList;

            var response = await this.apiService.CreateOrder(
                 "https://thenuap.com",
                 mainViewModel.User.api_token,
                 19,
                 data);

            if (response == null)
            {
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

            mainViewModel.CartList = null;

            Settings.CartList = null;
            mainViewModel.CreateOrderSuccess = new CreateOrderSuccessViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new CreateOrderSuccessPage());
        }
    }
}
