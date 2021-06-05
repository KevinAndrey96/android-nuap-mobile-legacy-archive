using GalaSoft.MvvmLight.Command;
using nuap.Services;
using nuap.Views;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace nuap.ViewModels
{
    public class PaymentRequestViewModel: BaseViewModel
    {
        private ApiService apiService;
        private bool isRefreshing;
        private string balance;
        private string value;
        private int commerceID;

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public string Balance
        {
            get { return this.balance; }
            set { SetValue(ref this.balance, value); }
        }

        public int CommerceID
        {
            get { return this.commerceID; }
            set { SetValue(ref this.commerceID, value); }
        }
        public string Value
        {
            get { return this.value; }
            set { SetValue(ref this.value, value); }
        }

        public ICommand RequestCommand
        {
            get
            {
                return new RelayCommand(RequestPayment);
            }
        }

        public PaymentRequestViewModel()
        {
            this.apiService = new ApiService();
            var mainViewModel = MainViewModel.GetInstance();
            this.Balance = mainViewModel.User.balance;
            this.CommerceID = mainViewModel.User.id;
        }

        private async void RequestPayment()
        {
            if (string.IsNullOrEmpty(this.Value))
            {
                await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Debes ingresar el valor que deseas solicitar",
                        "Aceptar"
                    );
                return;
            }

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

            var response = await this.apiService.RequestPayment(
                mainViewModel.User.api_token,
                "https://thenuap.com",
                this.Value);

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
                    response.Errors.First().Detail,
                    "Aceptar");
                return;
            }

            await Application.Current.MainPage.DisplayAlert(
                "",
                "Hemos creado tu solicitud exitosamente",
                "Aceptar");

            mainViewModel.User.balance = response.Data.Balance;
            mainViewModel.PaymentConfirm = new PaymentConfirmViewModel(response.Data.Value);
            await Application.Current.MainPage.Navigation.PushAsync(new PaymentConfirmPage());
        }
    }
}
