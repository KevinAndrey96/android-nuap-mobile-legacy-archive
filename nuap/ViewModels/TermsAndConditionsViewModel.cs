namespace nuap.ViewModels
{
    public class TermsAndConditionsViewModel : BaseViewModel
    {
        private string url;

        public string Url
        {
            get { return this.url; }
            set { SetValue(ref this.url, value); }
        }

        public TermsAndConditionsViewModel()
        {
            var mainViewModel = MainViewModel.GetInstance();
            this.Url = "https://thenuap.com/commerce/terms-and-conditions";
        }
    }
}
