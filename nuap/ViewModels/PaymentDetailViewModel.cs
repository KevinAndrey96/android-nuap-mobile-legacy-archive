namespace nuap.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using Rg.Plugins.Popup.Services;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;

    public class PaymentDetailViewModel: BaseViewModel
    {
        private string status;
        private string statusColor;
        private string voucher;
        private string paymentDate;
        private string requestDate;
        private string value;
        private string balance;
        private int paymentID;
        private bool isEnabled;
        private bool isVisible;

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        public bool IsVisible
        {
            get { return this.isVisible; }
            set { SetValue(ref this.isVisible, value); }
        }

        public string Status
        {
            get { return this.status; }
            set { SetValue(ref this.status, value); }
        }

        public string StatusColor
        {
            get { return this.statusColor; }
            set { SetValue(ref this.statusColor, value); }
        }

        public string Voucher
        {
            get { return this.voucher; }
            set { SetValue(ref this.voucher, value); }
        }

        public string PaymentDate
        {
            get { return this.paymentDate; }
            set { SetValue(ref this.paymentDate, value); }
        }

        public string RequestDate
        {
            get { return this.requestDate; }
            set { SetValue(ref this.requestDate, value); }
        }

        public int PaymentID
        {
            get { return this.paymentID; }
            set { SetValue(ref this.paymentID, value); }
        }

        public string Value
        {
            get { return this.value; }
            set { SetValue(ref this.value, value); }
        }

        public string Balance
        {
            get { return this.balance; }
            set { SetValue(ref this.balance, value); }
        }

        public ICommand VoucherCommand
        {
            get
            {
                return new RelayCommand(ViewVoucher);
            }
        }

        public ICommand ReturnCommand
        {
            get
            {
                return new RelayCommand(Return);
            }
        }

        public PaymentDetailViewModel(Payment payment)
        {
            this.IsEnabled = false;
            this.IsVisible = false;
            this.PaymentDate = payment.PaymentDate;
            this.RequestDate = payment.RequestDate;
            this.Status = payment.Status;
            this.StatusColor = payment.StatusColor;
            this.Voucher = payment.Voucher;
            this.Value = payment.Value;
            this.PaymentID = payment.Id;

            if (this.Status == "Aprobado")
            {
                this.IsVisible = true;
                this.IsEnabled = true;
            }

            var mainViewModel = MainViewModel.GetInstance();
            this.Balance = mainViewModel.User.balance;
        }

        private async void ViewVoucher()
        {
            var mainViewModel = MainViewModel.GetInstance();
            if (string.IsNullOrEmpty(this.Voucher))
            {
                mainViewModel.VoucherImage = "https://thenuap.com/images/nuap.jpg";
            } else
            {
                mainViewModel.VoucherImage = "https://thenuap.com/" + this.Voucher;
            }
            
            mainViewModel.VoucherPopup = new VoucherViewModel();

            var page = new VoucherPage();
            await PopupNavigation.Instance.PushAsync(page);
        }

        private async void Return()
        {
            var mainViewModel = MainViewModel.GetInstance();
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
