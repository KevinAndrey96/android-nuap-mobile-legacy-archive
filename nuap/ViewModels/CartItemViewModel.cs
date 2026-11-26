namespace nuap.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System.Windows.Input;
    using Views;
    using Rg.Plugins.Popup.Services;

    public class CartItemViewModel : Cart
    {
        public ICommand AddAndRemoveProductsCommand
        {
            get
            {
                return new RelayCommand(AddAndRemoveProducts);
            }
        }

        private async void AddAndRemoveProducts()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.AddAndRemoveProductsPopup = new AddAndRemoveProductsViewModel(this);

            var page = new AddAndRemoveProductsPage();
            await PopupNavigation.Instance.PushAsync(page);
        }
    }
}
