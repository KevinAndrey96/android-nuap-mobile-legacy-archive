namespace nuap.ViewModels
{
    public class VoucherViewModel : BaseViewModel
    {
        private string voucher;

        public string Voucher
        {
            get { return this.voucher; }
            set { SetValue(ref this.voucher, value); }
        }
       
        public VoucherViewModel()
        {
            var mainViewModel = MainViewModel.GetInstance();
            this.Voucher = mainViewModel.VoucherImage;
        }
    }
}
