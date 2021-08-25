namespace nuap.ViewModels
{
    using nuap.Services;
    using System.Linq;
    using Xamarin.Forms;
    using Views;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;

    public class AccountViewModel: BaseViewModel
    {
        private ApiService apiService;

        private string owner_name;
        private string owner_document;
        private string owner_document_type;
        private string account;
        private string account_type;
        private string bank;
        private string text;
        private string color;
        private bool isEnabled;

        public string Text
        {
            get { return this.text; }
            set { SetValue(ref this.text, value); }
        }

        public string Color
        {
            get { return this.color; }
            set { SetValue(ref this.color, value); }
        }

        public string OwnerName
        {
            get { return this.owner_name; }
            set { SetValue(ref this.owner_name, value); }
        }

        public string OwnerDocument
        {
            get { return this.owner_document; }
            set { SetValue(ref this.owner_document, value); }
        }

        public string OwnerDocumentType
        {
            get { return this.owner_document_type; }
            set { SetValue(ref this.owner_document_type, value); }
        }

        public string Account
        {
            get { return this.account; }
            set { SetValue(ref this.account, value); }
        }

        public string AccountType
        {
            get { return this.account_type; }
            set { SetValue(ref this.account_type, value); }
        }

        public string Bank
        {
            get { return this.bank; }
            set { SetValue(ref this.bank, value); }
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        public ICommand CreateAccountCommand
        {
            get
            {
                return new RelayCommand(CreateAccount);
            }
        }

        public AccountViewModel()
        {
            this.apiService = new ApiService();
            this.DetailAccount();
            this.IsEnabled = false;
        }

        private async void DetailAccount()
        {
            this.IsEnabled = false;

            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Aceptar");
                return;
            }

            var mainViewModel = MainViewModel.GetInstance();

            var response = await this.apiService.DetailAccount(
                mainViewModel.User.api_token,
                "https://thenuap.com");

            if (response.Data == null)
            {
                this.IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ha ocurrido un error",
                    "Aceptar");
                return;
            }

            if (response.Errors != null)
            {
                this.IsEnabled = true;
            } else
            {
                this.IsEnabled = true;
                this.OwnerName = response.Data.OwnerName;
                this.OwnerDocumentType = response.Data.OwnerDocumentType;
                this.OwnerDocument = response.Data.OwnerDocument;
                this.Account = response.Data.Account;
                this.AccountType = response.Data.AccountType;
                this.Bank = response.Data.Bank;

                if (response.Data.Status == true)
                {
                    this.Text = "Aprobado";
                    this.Color = "#4dbc65";
                } else
                {
                    this.Text = "Pendiente";
                    this.Color = "#f26c69";
                }
            }
        }

        private async void CreateAccount()
        {
            if (string.IsNullOrEmpty(this.OwnerName))
            {
                await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Debes ingresar el titular",
                        "Aceptar"
                    );
                return;
            }

            if (string.IsNullOrEmpty(this.OwnerDocument))
            {
                await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Debes ingresar la cuenta del titular",
                        "Aceptar"
                    );
                return;
            }

            if (string.IsNullOrEmpty(this.OwnerDocumentType))
            {
                await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Debes ingresar el tipo de cuenta del titular",
                        "Aceptar"
                    );
                return;
            }

            if (string.IsNullOrEmpty(this.Account))
            {
                await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Debes ingresar el numero de cuenta",
                        "Aceptar"
                    );
                return;
            }

            if (string.IsNullOrEmpty(this.AccountType))
            {
                await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Debes ingresar el tipo de cuenta",
                        "Aceptar"
                    );
                return;
            }

            if (string.IsNullOrEmpty(this.Bank))
            {
                await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Debes ingresar tu banco",
                        "Aceptar"
                    );
                return;
            }

            this.IsEnabled = false;

            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Aceptar");
                return;
            }

            var mainViewModel = MainViewModel.GetInstance();

            var response = await this.apiService.CreateAccount(
                mainViewModel.User.api_token,
                "https://thenuap.com",
                this.OwnerName,
                this.OwnerDocument,
                this.OwnerDocumentType,
                this.Account,
                this.AccountType,
                this.Bank);

            if (response == null)
            {
                this.IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ha ocurrido un error",
                    "Aceptar");
                return;
            }

            if (response.Errors != null)
            {
                await Application.Current.MainPage.DisplayAlert(
                   "Información",
                   response.Errors.First().Detail,
                   "Aceptar");
                return;
            }

            await Application.Current.MainPage.DisplayAlert(
                    "",
                    "Se ha actualizado la información de tu cuenta bancaria, esta estará en espera de validación.",
                    "Aceptar");

            this.IsEnabled = true;
            mainViewModel.HomeCommerce = new HomeCommerceViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new HomeCommerceTabbedPage());
        }
    }
}