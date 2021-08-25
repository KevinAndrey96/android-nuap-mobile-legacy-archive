namespace nuap.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using nuap.Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;

    public class PaymentsViewModel : BaseViewModel
    {
        private ApiService apiService;
        private ObservableCollection<PaymentItemViewModel> payments;
        private bool isRefreshing;
        private string balance;
        private int listHeight;

        public int ListHeight
        {
            get { return this.listHeight; }
            set { SetValue(ref this.listHeight, value); }
        }

        public ObservableCollection<PaymentItemViewModel> PaymentList
        {
            get { return this.payments; }
            set { SetValue(ref this.payments, value); }
        }

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

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadPayments);
            }
        }

        public ICommand RequestPaymentCommand
        {
            get
            {
                return new RelayCommand(RequestPayment);
            }
        }

        public PaymentsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadPayments();
            this.GetCommerceProfile();
        }

        private async void RequestPayment()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.PaymentRequest = new PaymentRequestViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new PaymentRequestPage());
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

            this.Balance = response.Data.Balance;
        }

        private async void LoadPayments()
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

            var response = await this.apiService.GetPayments(
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
                    "Información",
                    response.Errors.First().Detail,
                    "Aceptar");
                return;
            }

            var list = (List<Payment>)response.Data;
            List<Payment> newList = new List<Payment>();

            foreach (var item in list)
            {

                if (item.Status == "Rechazado")
                {
                    item.StatusColor = "#ffc33a";
                }

                if (item.Status == "Pendiente")
                {
                    item.StatusColor = "#a3cafa";
                }

                if (item.Status == "Aprobado")
                {
                    item.StatusColor = "#95dc4e";
                }

                if (item.Status == "Cancelado")
                {
                    item.StatusColor = "#f78d8d";
                }


                newList.Add(item);
            }

            this.PaymentList = new ObservableCollection<PaymentItemViewModel>(ToPaymentViewModel(newList));
            this.IsRefreshing = false;
            this.ListHeight = this.PaymentList.Count() * 100;
        }

        private IEnumerable<PaymentItemViewModel> ToPaymentViewModel(List<Payment> list)
        {
            return list.Select(o => new PaymentItemViewModel
            {
                Id = o.Id,
                Value = o.Value,
                RequestDate = o.RequestDate,
                PaymentDate = o.PaymentDate,
                Name = o.Name,
                Status = o.Status,
                Voucher = o.Voucher,
                StatusColor = o.StatusColor
            });
        }
    }
}
