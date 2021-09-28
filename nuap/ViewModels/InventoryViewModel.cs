namespace nuap.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Services;
    using System.Collections.Generic;
    using System.Linq;
    using Xamarin.Forms;
    using nuap.Views;

    public class InventoryViewModel: BaseViewModel
    {
        private ApiService apiService;
        private ObservableCollection<CategoryItemViewModel> categories;
        private bool isRefreshing;

        public ObservableCollection<CategoryItemViewModel> Categories
        {
            get { return this.categories; }
            set { SetValue(ref this.categories, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public ICommand ReturnCommand
        {
            get
            {
                return new RelayCommand(Return);
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadCategories);
            }
        }

        public InventoryViewModel()
        {
            this.apiService = new ApiService();
            this.LoadCategories();
        }


        private async void LoadCategories()
        {
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();
            if (! connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Aceptar");
                return;
            }

            var mainViewModel = MainViewModel.GetInstance();

            int categoryID = 0;
            if (mainViewModel.CategoryID != null)
            {
                categoryID = mainViewModel.CategoryID.Id;
            }

            var response = await this.apiService.GetCategories(
                mainViewModel.User.api_token,
                "https://thenuap.com",
                categoryID);

            if (response == null)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ha ocurrido un error",
                    "Aceptar");
                return;
            }

            if (response.Data == null)
            {
                this.IsRefreshing = false;

                if (mainViewModel.CategoryID != null)
                {
                    mainViewModel.ProductCommerce = new ProductCommerceViewModel(mainViewModel.CategoryID);

                    mainViewModel.CategoryID = null;
                    await Application.Current.MainPage.Navigation.PopAsync();
                    await Application.Current.MainPage.Navigation.PushAsync(new ProductCommercePage());

                    return;
                } else
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Información",
                        response.Errors.First().Detail,
                        "Aceptar");
                    return;
                }
            }

            mainViewModel.CategoryList = response.Data;

            this.Categories = new ObservableCollection<CategoryItemViewModel>(ToCategoryViewModel());
            this.IsRefreshing = false;
        }

        private IEnumerable<CategoryItemViewModel> ToCategoryViewModel()
        {
            return MainViewModel.GetInstance().CategoryList.Select(c => new CategoryItemViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Image = "https://thenuap.com/"+c.Image
            });
        }

        private async void Return()
        {
            var mainViewModel = MainViewModel.GetInstance();
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
