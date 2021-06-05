namespace nuap.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;

    public class PaymentItemViewModel : Payment
    {
        public ICommand PaymentDetailCommand
        {
            get
            {
                return new RelayCommand(PaymentDetail);
            }
        }

        private async void PaymentDetail()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.PaymentDetail = new PaymentDetailViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new PaymentDetailPage());
        }
    }
}
