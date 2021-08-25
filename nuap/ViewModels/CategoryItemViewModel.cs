namespace nuap.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    using Services;

    public class CategoryItemViewModel : Category
    {
        public ICommand GetProductsCommand
        {
            get
            {
                return new RelayCommand(GetProducts);
            }
        }

        public ICommand GetCategoryProductsCommand
        {
            get
            {
                return new RelayCommand(GetCategoryProducts);
            }
        }

        private async void GetProducts()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.CategoryID = this;

            mainViewModel.Inventory = new InventoryViewModel();

            await Application.Current.MainPage.Navigation.PushAsync(new InventoryPage());
        }

        private async void GetCategoryProducts()
        {
            var mainViewModel = MainViewModel.GetInstance();

            mainViewModel.CategoryProduct = new CategoryProductViewModel(this);

            await Application.Current.MainPage.Navigation.PopAsync();
            await Application.Current.MainPage.Navigation.PushAsync(new CategoryProductsPage());
        }
    }
}
