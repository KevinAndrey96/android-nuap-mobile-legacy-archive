namespace nuap.ViewModels
{
    public class PaymentConfirmViewModel: BaseViewModel
    {
        private string date;
        private string value;

        public string Value
        {
            get { return this.value; }
            set { SetValue(ref this.value, value); }
        }

        public string Date
        {
            get { return this.date; }
            set { SetValue(ref this.date, value); }
        }

        public PaymentConfirmViewModel(string value)
        {
            this.Value = value;
            this.Date = System.DateTime.Now.ToString();
        }
    }
}
