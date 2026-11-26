namespace nuap.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Services;
    using System.Linq;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;

    public class CommerceProfileViewModel : BaseViewModel
    {
        private ApiService apiService;

        private string email;
        private string phone;
        private string companyName;
        private string commission;
        private string shippingCost;
        private bool isEnabled;
        private string logo;

        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
        
        public string Phone
        {
            get { return this.phone; }
            set { SetValue(ref this.phone, value); }
        }

        public string Commission
        {
            get { return this.commission; }
            set { SetValue(ref this.commission, value); }
        }

        public string ShippingCost
        {
            get { return this.shippingCost; }
            set { SetValue(ref this.shippingCost, value); }
        }

        public string CompanyName
        {
            get { return this.companyName; }
            set { SetValue(ref this.companyName, value); }
        }

        public ICommand ChangePasswordCommand
        {
            get
            {
                return new RelayCommand(ChangePassword);
            }
        }

        public ICommand ReturnCommand
        {
            get
            {
                return new RelayCommand(Return);
            }
        }

        public string Logo
        {
            get { return this.logo; }
            set { SetValue(ref this.logo, value); }
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        public CommerceProfileViewModel()
        {
            this.apiService = new ApiService();
            this.GetCommerceProfile();
            this.IsEnabled = true;
        }

        private async void GetCommerceProfile()
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

            var response = await this.apiService.GetCommerceProfile(
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

            if (response.Data == null)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Información",
                    response.Errors.First().Detail,
                    "Aceptar");
                return;
            }

            this.Email = response.Data.Email;
            this.Phone = response.Data.Phone;
            this.CompanyName = response.Data.BusinessName;
            this.Commission = response.Data.Commission;
            this.ShippingCost = response.Data.ShippingCost;
            this.Logo = "https://thenuap.com/" + response.Data.UrlLogo;
        }

        private async void Return()
        {
            var mainViewModel = MainViewModel.GetInstance();
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async void ChangePassword()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.ChangePassword = new ChangePasswordViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new ChangePasswordPage());
        }
    }
}
