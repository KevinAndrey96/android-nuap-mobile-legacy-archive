namespace nuap.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using Newtonsoft.Json;
    using nuap.Helpers;
    using nuap.Views;
    using System.Collections.Generic;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class AddAndRemoveProductsViewModel: BaseViewModel
    {
        private Cart cart;
        private int quantity;
        private string image;
        private double total;
        private double price;
        private int stock;

        public double Total
        {
            get { return this.total; }
            set { SetValue(ref this.total, value); }
        }

        public double Price
        {
            get { return this.price; }
            set { SetValue(ref this.price, value); }
        }

        public int Quantity
        {
            get { return this.quantity; }
            set
            {
                SetValue(ref this.quantity, value);
                this.Validate();
            }
        }

        public int Stock
        {
            get { return this.stock; }
            set { SetValue(ref this.stock, value); }
        }

        public Cart Cart
        {
            get { return this.cart; }
            set { SetValue(ref this.cart, value); }
        }

        public string Image
        {
            get { return this.image; }
            set { SetValue(ref this.image, value); }
        }

        public ICommand DiminishCommand
        {
            get
            {
                return new RelayCommand(Diminish);
            }
        }

        public ICommand IncreaseCommand
        {
            get
            {
                return new RelayCommand(Increase);
            }
        }

        public ICommand AddCartCommand
        {
            get
            {
                return new RelayCommand(AddCart);
            }
        }


        public AddAndRemoveProductsViewModel(Cart cart)
        {
            this.Cart = cart;
            this.Quantity = cart.Quantity;
            this.Image = cart.Image;
            this.Stock = cart.Stock;
        }

        private async void Diminish()
        {
            if ((this.Quantity - 1) < 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "",
                    "No puedes agregar menos de 0 productos",
                    "Aceptar");
                return;
            }
            else
            {
                this.Quantity = this.Quantity - 1;
                this.Total = this.Price * this.Quantity;
            }
        }

        private async void Increase()
        {
            if ((this.Quantity + 1) > this.cart.Stock)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "",
                    "No puedes agregar más de " + this.cart.Stock + " productos",
                    "Aceptar");
                return;
            }
            else
            {
                this.Quantity = this.Quantity + 1;
                this.Total = this.Price * this.Quantity;
            }
        }

        private async void Validate()
        {
            if ((this.Quantity) > this.cart.Stock)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "",
                    "No puedes agregar más de " + this.cart.Stock + " productos",
                    "Aceptar");
                return;
            }
            else if (this.Quantity < 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "",
                    "No puedes agregar menos de 0 productos",
                    "Aceptar");
                return;
            }
            else
            {
                this.Total = this.Price * this.Quantity;
            }
        }

        private async void AddCart()
        {
            var mainViewModel = MainViewModel.GetInstance();
            List<Cart> cartList = new List<Cart>();

            foreach (var item in mainViewModel.CartList)
            {
                if (item.Id == this.cart.Id && this.Quantity == 0)
                {
                    continue;
                }

                if (item.Id == this.cart.Id && this.Quantity != 0)
                {
                    item.Quantity = this.Quantity;
                    cartList.Add(item);
                }
            }

            mainViewModel.CartList = new List<Cart>();
            mainViewModel.CartList = cartList;

            Settings.CartList = JsonConvert.SerializeObject(mainViewModel.CartList);
            await Application.Current.MainPage.DisplayAlert(
                    "",
                    "Hemos actualizado las unidades de este producto",
                    "Aceptar");

            if (mainViewModel.CartList.Count == 0)
            {
                mainViewModel.CartEmpty = new CartEmptyViewModel();
                await Application.Current.MainPage.Navigation.PopAsync();
                await Application.Current.MainPage.Navigation.PushAsync(new CartEmptyPage());
            } else
            {
                mainViewModel.Cart = new CartViewModel();
                await Application.Current.MainPage.Navigation.PopAsync();
                await Application.Current.MainPage.Navigation.PushAsync(new CartPage());
            }
        }
    }
}
