namespace nuap.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using nuap.Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class StoreViewModel: BaseViewModel
    {
        private int storeID;
        private string email;
        private string phone;
        private string companyName;
        private string commission;
        private string shippingCost;
        private string logo;
        private string header;

        private ApiService apiService;
        private ObservableCollection<CategoryItemViewModel> categories;
        private ObservableCollection<CategoryItemViewModel> categoriesLeft;
        private List<Category> list;
        private List<Category> listLeft;
        private bool isRefreshing;
        private string filter;

        public string Filter
        {
            get { return this.filter; }
            set
            {
                SetValue(ref this.filter, value);
                this.Search();
            }
        }

        public ObservableCollection<CategoryItemViewModel> CategoriesLeft
        {
            get { return this.categoriesLeft; }
            set { SetValue(ref this.categoriesLeft, value); }
        }

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

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadCategories);
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        public ICommand ReturnCommand
        {
            get
            {
                return new RelayCommand(Return);
            }
        }

        public string Header
        {
            get { return this.header; }
            set { SetValue(ref this.header, value); }
        }

        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }

        public string Phone
        {
            get { return this.phone; }
            set { SetValue(ref this.phone, value); }
        }

        public string Commission
        {
            get { return this.commission; }
            set { SetValue(ref this.commission, value); }
        }

        public string ShippingCost
        {
            get { return this.shippingCost; }
            set { SetValue(ref this.shippingCost, value); }
        }

        public string CompanyName
        {
            get { return this.companyName; }
            set { SetValue(ref this.companyName, value); }
        }

        public string Logo
        {
            get { return this.logo; }
            set { SetValue(ref this.logo, value); }
        }

        public int StoreID
        {
            get { return this.storeID; }
            set { SetValue(ref this.storeID, value); }
        }

        public StoreViewModel(Commerce store)
        {
            this.StoreID = store.Id;
            this.Email = store.Email;
            this.Phone = store.Phone;
            this.CompanyName = store.BusinessName;
            this.Commission = store.Commission;
            this.ShippingCost = store.ShippingCost;
            this.Logo = "https://thenuap.com/" + store.UrlLogo;
            this.Header = "https://thenuap.com/" + store.Header;

            this.apiService = new ApiService();
            this.LoadCategories();
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Categories = new ObservableCollection<CategoryItemViewModel>(ToCategoryViewModel(this.list));
                this.CategoriesLeft = new ObservableCollection<CategoryItemViewModel>(ToCategoryViewModel(this.listLeft));
            }
            else
            {
                var mainViewModel = MainViewModel.GetInstance();

                int count = mainViewModel.CategoryList.Count();
                this.Categories = new ObservableCollection<CategoryItemViewModel>
                    (ToCategoryViewModel(mainViewModel.CategoryList).Where(p => p.Name.ToLower().Contains(this.Filter.ToLower())));

                ObservableCollection<CategoryItemViewModel> listOne = new ObservableCollection<CategoryItemViewModel>(); //derecha
                ObservableCollection<CategoryItemViewModel> listTwo = new ObservableCollection<CategoryItemViewModel>(); //izquierda

                foreach (var item in this.Categories)
                {
                    if ((count % 2) == 0)
                        listOne.Add(item);
                    else
                        listTwo.Add(item);

                    count++;
                }

                this.Categories = listOne;
                this.CategoriesLeft = listTwo;
                this.IsRefreshing = false;
            }
        }

        private async void LoadCategories()
        {
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Aceptar");
                return;
            }

            var mainViewModel = MainViewModel.GetInstance();

            var response = await this.apiService.GetValidCategories(
               mainViewModel.User.api_token,
               "https://thenuap.com",
               mainViewModel.AddressDetail.Id,
               this.storeID
            );

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
                await Application.Current.MainPage.DisplayAlert(
                    "Información",
                    response.Errors.First().Detail,
                    "Aceptar");
                return;
            }

            mainViewModel.CategoryList = response.Data;
            this.listLeft = new List<Category>();
            this.list = new List<Category>();

            int count = mainViewModel.CategoryList.Count();
            foreach (var item in mainViewModel.CategoryList)
            {
                if ((count % 2) == 0)
                    this.list.Add(item);
                else
                    this.listLeft.Add(item);

                count++;
            }

            this.Categories = new ObservableCollection<CategoryItemViewModel>(ToCategoryViewModel(this.list));
            this.CategoriesLeft = new ObservableCollection<CategoryItemViewModel>(ToCategoryViewModel(this.listLeft));
            this.IsRefreshing = false;
        }

        private IEnumerable<CategoryItemViewModel> ToCategoryViewModel(List<Category> list)
        {
            return list.Select(c => new CategoryItemViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Image = "https://thenuap.com/" + c.Image
            });
        }

        private async void Return()
        {
            var mainViewModel = MainViewModel.GetInstance();
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
