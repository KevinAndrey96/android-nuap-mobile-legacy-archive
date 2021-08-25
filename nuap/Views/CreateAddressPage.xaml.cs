namespace nuap.Views
{
    using Xamarin.Forms;
    using nuap.ViewModels;

    public partial class CreateAddressPage : ContentPage
    {
        public CreateAddressPage()
        {
            InitializeComponent();
            BindingContext = new CreateAddressViewModel();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
