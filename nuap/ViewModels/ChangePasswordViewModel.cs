namespace nuap.ViewModels
{
    public class ChangePasswordViewModel : BaseViewModel
    {
        private string url;

        public string Url
        {
            get { return this.url; }
            set { SetValue(ref this.url, value); }
        }

        public ChangePasswordViewModel()
        {
            var mainViewModel = MainViewModel.GetInstance();
            this.Url = "https://thenuap.com/recover-password";
        }
    }
}
