namespace nuap
{
    using Xamarin.Forms;
    using Views;
    using Helpers;
    using ViewModels;
    using System;
    using nuap.Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Services;
    using System.Linq;

    public partial class App : Application
    {
        private ApiService apiService;

        public App()
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Settings.Token))
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                var mainViewModel = MainViewModel.GetInstance();

                User Usuario = new User();
                Usuario.api_token = Settings.Token;
                Usuario.role = Settings.UserType;
                Usuario.phone = Settings.Phone;
                Usuario.email = Settings.Email;
                Usuario.balance = Settings.Balance;
                Usuario.id = Int32.Parse(Settings.Id);

                mainViewModel.User = Usuario;

                if (!string.IsNullOrEmpty(Settings.CartList))
                {
                    mainViewModel.CartList = JsonConvert.DeserializeObject<List<Cart>>(Settings.CartList);
                }

                if (!string.IsNullOrEmpty(Settings.AddressDetail))
                {
                    mainViewModel.AddressDetail = JsonConvert.DeserializeObject<Address>(Settings.AddressDetail);
                }

                mainViewModel.HomeCommerce = new HomeCommerceViewModel();
                MainPage = new NavigationPage(new HomeCommerceTabbedPage());
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
