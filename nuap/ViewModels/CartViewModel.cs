namespace nuap.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Models;
    using Views;
    using Xamarin.Forms;
    using Services;
    using System.Linq;
    using Helpers;

    public class CartViewModel : BaseViewModel
    {
        private ApiService apiService;
        private ObservableCollection<Cart> cart;
        private bool isRefreshing;
        private bool isEnabled;
        private string total;
        private string delivery;
        private string discount;
        private string addressText;

        public string AddressText
        {
            get { return this.addressText; }
            set { SetValue(ref this.addressText, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        public string Total
        {
            get { return this.total; }
            set { SetValue(ref this.total, value); }
        }

        public string Delivery
        {
            get { return this.delivery; }
            set { SetValue(ref this.delivery, value); }
        }

        public string Discount
        {
            get { return this.discount; }
            set { SetValue(ref this.discount, value); }
        }

        public ObservableCollection<Cart> Cart
        {
            get { return this.cart; }
            set { SetValue(ref this.cart, value); }
        }

        public ICommand ChoosePaymentMethodCommand
        {
            get
            {
                return new RelayCommand(ChoosePaymentMethod);
            }
        }

        public ICommand AddProductsCommand
        {
            get
            {
                return new RelayCommand(AddProducts);
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadCart);
            }
        }

        public CartViewModel()
        {
            this.IsEnabled = false;
            this.apiService = new ApiService();
            this.LoadCart();
        }

        private void LoadCart()
        {
            var mainViewModel = MainViewModel.GetInstance();
            this.AddressText = mainViewModel.AddressDetail.Addres;

            this.Cart = new ObservableCollection<Cart>(mainViewModel.CartList);
            this.IsRefreshing = false;
            this.CalculateDelivery();
        }

        private async void CalculateDelivery()
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
            data.Products = mainViewModel.CartList;


            var response = await this.apiService.CalculateDelivery(
                 "https://thenuap.com",
                 mainViewModel.User.api_token,
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
                mainViewModel.CartList = null;
                Settings.CartList = "";

                await Application.Current.MainPage.DisplayAlert(
                    "Información",
                    response.Errors.First().Detail,
                    "Aceptar");

                mainViewModel.HomeCommerce = new HomeCommerceViewModel();
                await Application.Current.MainPage.Navigation.PushAsync(new HomeCommerceTabbedPage());
            } else
            {
                this.Delivery = response.Data.DeliveryTotal;
                this.Total = response.Data.Total;
                this.Discount = response.Data.Discount;

                this.IsEnabled = true;
            }
        }

        private async void ChoosePaymentMethod()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.CreateOrder = new CreateOrderViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new ChoosePaymentMethodPage());
        }

        private async void AddProducts()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.HomeCommerce = new HomeCommerceViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new HomeCommerceTabbedPage());
        }
    }
}
