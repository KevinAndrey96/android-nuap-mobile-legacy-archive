namespace nuap.ViewModels
{
    using System.Collections.ObjectModel;
    using Models;
    using Services;
    using Xamarin.Forms;
    using System.Linq;
    using System.Collections.Generic;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Views;
    using nuap.Helpers;
    using Newtonsoft.Json;

    public class HomeCommerceViewModel : BaseViewModel
    {
        private ApiService apiService;
        private ObservableCollection<TicketItemViewModel> tickets;
        private ObservableCollection<Address> address;
        private bool isRefreshing;
        private bool isRefreshingInit;
        private string companyName;
        private string logo;
        private int addressID = 0;

        private string cartImage;

        private string addressOne;
        private string addressOneN;
        private string addressOneColor;
        private string addressTwo;
        private string addressTwoN;
        private string addressTwoColor;
        private string addressThree;
        private string addressThreeN;
        private string addressThreeColor;
        private string addressFour;
        private string addressFourN;
        private string addressFourColor;
        private string addressFive;
        private string addressFiveN;
        private string addressFiveColor;

        private bool viewAddressOne;
        private bool viewAddressTwo;
        private bool viewAddressThree;
        private bool viewAddressFour;
        private bool viewAddressFive;

        private string c1n;
        private string c1i;
        private string c2n;
        private string c2i;
        private string c3n;
        private string c3i;
        private string c4n;
        private string c4i;
        private string c5n;
        private string c5i;

        private bool c1;
        private bool c2;
        private bool c3;
        private bool c4;
        private bool c5;

        private bool s1;
        private bool s2;
        private bool s3;
        private bool s4;
        private bool s5;

        private string s1n;
        private string s1i;
        private string s2n;
        private string s2i;
        private string s3n;
        private string s3i;
        private string s4n;
        private string s4i;
        private string s5n;
        private string s5i;

        private bool o1;
        private bool o2;
        private bool o3;
        private bool o4;
        private bool o5;

        private string o1n;
        private string o1i;
        private string o1p;
        private string o1rp;
        private string o2n;
        private string o2i;
        private string o2p;
        private string o2rp;
        private string o3n;
        private string o3i;
        private string o3p;
        private string o3rp;
        private string o4n;
        private string o4i;
        private string o4p;
        private string o4rp;
        private string o5n;
        private string o5i;
        private string o5p;
        private string o5rp;

        private bool d1;
        private bool d2;
        private bool d3;
        private bool d4;
        private bool d5;

        private string d1n;
        private string d1i;
        private string d1p;
        private string d2n;
        private string d2i;
        private string d2p;
        private string d3n;
        private string d3i;
        private string d3p;
        private string d4n;
        private string d4i;
        private string d4p;
        private string d5n;
        private string d5i;
        private string d5p;

        private bool enabled1;
        private bool enabled2;
        private bool enabled3;
        private bool enabled4;
        private bool enabled5;
        private bool enabled6;
        private bool enabled7;
        private bool enabled8;
        private bool enabled9;
        private bool enabled10;

        private bool enabled11;
        private bool enabled12;
        private bool enabled13;
        private bool enabled14;
        private bool enabled15;
        private bool enabled16;
        private bool enabled17;
        private bool enabled18;
        private bool enabled19;
        private bool enabled20;

        public bool Enabled1
        {
            get { return this.enabled1; }
            set { SetValue(ref this.enabled1, value); }
        }

        public bool Enabled2
        {
            get { return this.enabled2; }
            set { SetValue(ref this.enabled2, value); }
        }

        public bool Enabled3
        {
            get { return this.enabled3; }
            set { SetValue(ref this.enabled3, value); }
        }

        public bool Enabled4
        {
            get { return this.enabled4; }
            set { SetValue(ref this.enabled4, value); }
        }

        public bool Enabled5
        {
            get { return this.enabled5; }
            set { SetValue(ref this.enabled5, value); }
        }

        public bool Enabled6
        {
            get { return this.enabled6; }
            set { SetValue(ref this.enabled6, value); }
        }

        public bool Enabled7
        {
            get { return this.enabled7; }
            set { SetValue(ref this.enabled7, value); }
        }

        public bool Enabled8
        {
            get { return this.enabled8; }
            set { SetValue(ref this.enabled8, value); }
        }

        public bool Enabled9
        {
            get { return this.enabled9; }
            set { SetValue(ref this.enabled9, value); }
        }

        public bool Enabled10
        {
            get { return this.enabled10; }
            set { SetValue(ref this.enabled10, value); }
        }

        public bool Enabled11
        {
            get { return this.enabled11; }
            set { SetValue(ref this.enabled11, value); }
        }

        public bool Enabled12
        {
            get { return this.enabled12; }
            set { SetValue(ref this.enabled12, value); }
        }

        public bool Enabled13
        {
            get { return this.enabled13; }
            set { SetValue(ref this.enabled13, value); }
        }

        public bool Enabled14
        {
            get { return this.enabled14; }
            set { SetValue(ref this.enabled14, value); }
        }

        public bool Enabled15
        {
            get { return this.enabled15; }
            set { SetValue(ref this.enabled15, value); }
        }

        public bool Enabled16
        {
            get { return this.enabled16; }
            set { SetValue(ref this.enabled16, value); }
        }

        public bool Enabled17
        {
            get { return this.enabled17; }
            set { SetValue(ref this.enabled17, value); }
        }

        public bool Enabled18
        {
            get { return this.enabled18; }
            set { SetValue(ref this.enabled18, value); }
        }

        public bool Enabled19
        {
            get { return this.enabled19; }
            set { SetValue(ref this.enabled19, value); }
        }

        public bool Enabled20
        {
            get { return this.enabled20; }
            set { SetValue(ref this.enabled20, value); }
        }

        public ObservableCollection<TicketItemViewModel> Tickets
        {
            get { return this.tickets; }
            set { SetValue(ref this.tickets, value); }
        }

        public ObservableCollection<Address> Address
        {
            get { return this.address; }
            set { SetValue(ref this.address, value); }
        }

        public string CartImage
        {
            get { return this.cartImage; }
            set { SetValue(ref this.cartImage, value); }
        }

        public string CompanyName
        {
            get { return this.companyName; }
            set { SetValue(ref this.companyName, value); }
        }

        public bool ViewAddressOne
        {
            get { return this.viewAddressOne; }
            set { SetValue(ref this.viewAddressOne, value); }
        }

        public bool ViewAddressTwo
        {
            get { return this.viewAddressTwo; }
            set { SetValue(ref this.viewAddressTwo, value); }
        }

        public bool ViewAddressThree
        {
            get { return this.viewAddressThree; }
            set { SetValue(ref this.viewAddressThree, value); }
        }

        public bool ViewAddressFour
        {
            get { return this.viewAddressFour; }
            set { SetValue(ref this.viewAddressFour, value); }
        }

        public bool ViewAddressFive
        {
            get { return this.viewAddressFive; }
            set { SetValue(ref this.viewAddressFive, value); }
        }

        public bool D1
        {
            get { return this.d1; }
            set { SetValue(ref this.d1, value); }
        }

        public bool D2
        {
            get { return this.d2; }
            set { SetValue(ref this.d2, value); }
        }

        public bool D3
        {
            get { return this.d3; }
            set { SetValue(ref this.d3, value); }
        }

        public bool D4
        {
            get { return this.d4; }
            set { SetValue(ref this.d4, value); }
        }

        public bool D5
        {
            get { return this.d5; }
            set { SetValue(ref this.d5, value); }
        }

        public bool C1
        {
            get { return this.c1; }
            set { SetValue(ref this.c1, value); }
        }

        public bool C2
        {
            get { return this.c2; }
            set { SetValue(ref this.c2, value); }
        }

        public bool C3
        {
            get { return this.c3; }
            set { SetValue(ref this.c3, value); }
        }

        public bool C4
        {
            get { return this.c4; }
            set { SetValue(ref this.c4, value); }
        }

        public bool C5
        {
            get { return this.c5; }
            set { SetValue(ref this.c5, value); }
        }

        public bool O1
        {
            get { return this.o1; }
            set { SetValue(ref this.o1, value); }
        }

        public bool O2
        {
            get { return this.o2; }
            set { SetValue(ref this.o2, value); }
        }

        public bool O3
        {
            get { return this.o3; }
            set { SetValue(ref this.o3, value); }
        }

        public bool O4
        {
            get { return this.o4; }
            set { SetValue(ref this.o4, value); }
        }

        public bool O5
        {
            get { return this.o5; }
            set { SetValue(ref this.o5, value); }
        }

        public bool S1
        {
            get { return this.s1; }
            set { SetValue(ref this.s1, value); }
        }

        public bool S2
        {
            get { return this.s2; }
            set { SetValue(ref this.s2, value); }
        }

        public bool S3
        {
            get { return this.s3; }
            set { SetValue(ref this.s3, value); }
        }

        public bool S4
        {
            get { return this.s4; }
            set { SetValue(ref this.s4, value); }
        }

        public bool S5
        {
            get { return this.s5; }
            set { SetValue(ref this.s5, value); }
        }

        public string S1n
        {
            get { return this.s1n; }
            set { SetValue(ref this.s1n, value); }
        }

        public string S1i
        {
            get { return this.s1i; }
            set { SetValue(ref this.s1i, value); }
        }

        public string S2n
        {
            get { return this.s2n; }
            set { SetValue(ref this.s2n, value); }
        }

        public string S2i
        {
            get { return this.s2i; }
            set { SetValue(ref this.s2i, value); }
        }

        public string S3n
        {
            get { return this.s3n; }
            set { SetValue(ref this.s3n, value); }
        }

        public string S3i
        {
            get { return this.s3i; }
            set { SetValue(ref this.s3i, value); }
        }

        public string S4n
        {
            get { return this.s4n; }
            set { SetValue(ref this.s4n, value); }
        }

        public string S4i
        {
            get { return this.s4i; }
            set { SetValue(ref this.s4i, value); }
        }

        public string S5n
        {
            get { return this.s5n; }
            set { SetValue(ref this.s5n, value); }
        }

        public string S5i
        {
            get { return this.s5i; }
            set { SetValue(ref this.s5i, value); }
        }

        public string D1n
        {
            get { return this.d1n; }
            set { SetValue(ref this.d1n, value); }
        }

        public string D1i
        {
            get { return this.d1i; }
            set { SetValue(ref this.d1i, value); }
        }

        public string D1p
        {
            get { return this.d1p; }
            set { SetValue(ref this.d1p, value); }
        }

        public string D2n
        {
            get { return this.d2n; }
            set { SetValue(ref this.d2n, value); }
        }

        public string D2i
        {
            get { return this.d2i; }
            set { SetValue(ref this.d2i, value); }
        }

        public string D2p
        {
            get { return this.d2p; }
            set { SetValue(ref this.d2p, value); }
        }

        public string D3n
        {
            get { return this.d3n; }
            set { SetValue(ref this.d3n, value); }
        }

        public string D3i
        {
            get { return this.d3i; }
            set { SetValue(ref this.d3i, value); }
        }

        public string D3p
        {
            get { return this.d3p; }
            set { SetValue(ref this.d3p, value); }
        }

        public string D4n
        {
            get { return this.d4n; }
            set { SetValue(ref this.d4n, value); }
        }

        public string D4i
        {
            get { return this.d4i; }
            set { SetValue(ref this.d4i, value); }
        }

        public string D4p
        {
            get { return this.d4p; }
            set { SetValue(ref this.d4p, value); }
        }

        public string D5n
        {
            get { return this.d5n; }
            set { SetValue(ref this.d5n, value); }
        }

        public string D5i
        {
            get { return this.d5i; }
            set { SetValue(ref this.d5i, value); }
        }

        public string D5p
        {
            get { return this.d5p; }
            set { SetValue(ref this.d5p, value); }
        }

        public string O1n
        {
            get { return this.o1n; }
            set { SetValue(ref this.o1n, value); }
        }

        public string O1i
        {
            get { return this.o1i; }
            set { SetValue(ref this.o1i, value); }
        }

        public string O1p
        {
            get { return this.o1p; }
            set { SetValue(ref this.o1p, value); }
        }

        public string O1rp
        {
            get { return this.o1rp; }
            set { SetValue(ref this.o1rp, value); }
        }

        public string O2n
        {
            get { return this.o2n; }
            set { SetValue(ref this.o2n, value); }
        }

        public string O2i
        {
            get { return this.o2i; }
            set { SetValue(ref this.o2i, value); }
        }

        public string O2p
        {
            get { return this.o2p; }
            set { SetValue(ref this.o2p, value); }
        }

        public string O2rp
        {
            get { return this.o2rp; }
            set { SetValue(ref this.o2rp, value); }
        }

        public string O3n
        {
            get { return this.o3n; }
            set { SetValue(ref this.o3n, value); }
        }

        public string O3i
        {
            get { return this.o3i; }
            set { SetValue(ref this.o3i, value); }
        }

        public string O3p
        {
            get { return this.o3p; }
            set { SetValue(ref this.o3p, value); }
        }

        public string O3rp
        {
            get { return this.o3rp; }
            set { SetValue(ref this.o3rp, value); }
        }

        public string O4n
        {
            get { return this.o4n; }
            set { SetValue(ref this.o4n, value); }
        }

        public string O4i
        {
            get { return this.o4i; }
            set { SetValue(ref this.o4i, value); }
        }

        public string O4p
        {
            get { return this.o4p; }
            set { SetValue(ref this.o4p, value); }
        }

        public string O4rp
        {
            get { return this.o4rp; }
            set { SetValue(ref this.o4rp, value); }
        }

        public string O5n
        {
            get { return this.o5n; }
            set { SetValue(ref this.o5n, value); }
        }

        public string O5i
        {
            get { return this.o5i; }
            set { SetValue(ref this.o5i, value); }
        }

        public string O5p
        {
            get { return this.o5p; }
            set { SetValue(ref this.o5p, value); }
        }

        public string O5rp
        {
            get { return this.o5rp; }
            set { SetValue(ref this.o5rp, value); }
        }

        public string C1n
        {
            get { return this.c1n; }
            set { SetValue(ref this.c1n, value); }
        }

        public string C1i
        {
            get { return this.c1i; }
            set { SetValue(ref this.c1i, value); }
        }

        public string C2n
        {
            get { return this.c2n; }
            set { SetValue(ref this.c2n, value); }
        }

        public string C2i
        {
            get { return this.c2i; }
            set { SetValue(ref this.c2i, value); }
        }

        public string C3n
        {
            get { return this.c3n; }
            set { SetValue(ref this.c3n, value); }
        }

        public string C3i
        {
            get { return this.c3i; }
            set { SetValue(ref this.c3i, value); }
        }

        public string C4n
        {
            get { return this.c4n; }
            set { SetValue(ref this.c4n, value); }
        }

        public string C4i
        {
            get { return this.c4i; }
            set { SetValue(ref this.c4i, value); }
        }

        public string C5n
        {
            get { return this.c5n; }
            set { SetValue(ref this.c5n, value); }
        }

        public string C5i
        {
            get { return this.c5i; }
            set { SetValue(ref this.c5i, value); }
        }

        public string AddressOne
        {
            get { return this.addressOne; }
            set { SetValue(ref this.addressOne, value); }
        }

        public string AddressOneN
        {
            get { return this.addressOneN; }
            set { SetValue(ref this.addressOneN, value); }
        }

        public string AddressOneColor
        {
            get { return this.addressOneColor; }
            set { SetValue(ref this.addressOneColor, value); }
        }

        public string AddressTwoColor
        {
            get { return this.addressTwoColor; }
            set { SetValue(ref this.addressTwoColor, value); }
        }

        public string AddressThreeColor
        {
            get { return this.addressThreeColor; }
            set { SetValue(ref this.addressThreeColor, value); }
        }

        public string AddressFourColor
        {
            get { return this.addressFourColor; }
            set { SetValue(ref this.addressFourColor, value); }
        }

        public string AddressFiveColor
        {
            get { return this.addressFiveColor; }
            set { SetValue(ref this.addressFiveColor, value); }
        }

        public string AddressTwo
        {
            get { return this.addressTwo; }
            set { SetValue(ref this.addressTwo, value); }
        }

        public string AddressTwoN
        {
            get { return this.addressTwoN; }
            set { SetValue(ref this.addressTwoN, value); }
        }

        public string AddressThree
        {
            get { return this.addressThree; }
            set { SetValue(ref this.addressThree, value); }
        }

        public string AddressThreeN
        {
            get { return this.addressThreeN; }
            set { SetValue(ref this.addressThreeN, value); }
        }

        public string AddressFour
        {
            get { return this.addressFour; }
            set { SetValue(ref this.addressFour, value); }
        }

        public string AddressFourN
        {
            get { return this.addressFourN; }
            set { SetValue(ref this.addressFourN, value); }
        }

        public string AddressFive
        {
            get { return this.addressFive; }
            set { SetValue(ref this.addressFive, value); }
        }

        public string AddressFiveN
        {
            get { return this.addressFiveN; }
            set { SetValue(ref this.addressFiveN, value); }
        }

        public string Logo
        {
            get { return this.logo; }
            set { SetValue(ref this.logo, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public bool IsRefreshingInit
        {
            get { return this.isRefreshingInit; }
            set { SetValue(ref this.isRefreshingInit, value); }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadTickets);
            }
        }

        public ICommand RefreshInitCommand
        {
            get
            {
                return new RelayCommand(LoadAddress);
            }
        }

        public ICommand CreateTicketCommand
        {
            get
            {
                return new RelayCommand(CreateTicket);
            }
        }

        public ICommand ProfileCommand
        {
            get
            {
                return new RelayCommand(EditProfile);
            }
        }

        public ICommand InventoryCommand
        {
            get
            {
                return new RelayCommand(Inventory);
            }
        }

        public ICommand OrdersCommand
        {
            get
            {
                return new RelayCommand(Orders);
            }
        }

        public ICommand SalesCommand
        {
            get
            {
                return new RelayCommand(Sales);
            }
        }

        public ICommand GetAllCategoriesCommand
        {
            get
            {
                return new RelayCommand(GetAllCategories);
            }
        }

        public ICommand GetCategoryProductsC1Command
        {
            get
            {
                return new RelayCommand(GetCategoryProductsC1);
            }
        }

        public ICommand GetCategoryProductsC2Command
        {
            get
            {
                return new RelayCommand(GetCategoryProductsC2);
            }
        }

        public ICommand GetCategoryProductsC3Command
        {
            get
            {
                return new RelayCommand(GetCategoryProductsC3);
            }
        }

        public ICommand GetCategoryProductsC4Command
        {
            get
            {
                return new RelayCommand(GetCategoryProductsC4);
            }
        }

        public ICommand GetCategoryProductsC5Command
        {
            get
            {
                return new RelayCommand(GetCategoryProductsC5);
            }
        }

        public ICommand ViewStoreOneCommand
        {
            get
            {
                return new RelayCommand(GetStoreOne);
            }
        }

        public ICommand ViewStoreTwoCommand
        {
            get
            {
                return new RelayCommand(GetStoreTwo);
            }
        }

        public ICommand ViewStoreThreeCommand
        {
            get
            {
                return new RelayCommand(GetStoreThree);
            }
        }

        public ICommand ViewStoreFourCommand
        {
            get
            {
                return new RelayCommand(GetStoreFour);
            }
        }

        public ICommand ViewStoreFiveCommand
        {
            get
            {
                return new RelayCommand(GetStoreFive);
            }
        }

        public ICommand AddProductO1Command
        {
            get
            {
                return new RelayCommand(AddProductO1);
            }
        }

        public ICommand AddProductO2Command
        {
            get
            {
                return new RelayCommand(AddProductO2);
            }
        }

        public ICommand AddProductO3Command
        {
            get
            {
                return new RelayCommand(AddProductO3);
            }
        }

        public ICommand AddProductO4Command
        {
            get
            {
                return new RelayCommand(AddProductO4);
            }
        }

        public ICommand AddProductO5Command
        {
            get
            {
                return new RelayCommand(AddProductO5);
            }
        }

        public ICommand AddProductD1Command
        {
            get
            {
                return new RelayCommand(AddProductD1);
            }
        }

        public ICommand AddProductD2Command
        {
            get
            {
                return new RelayCommand(AddProductD2);
            }
        }

        public ICommand AddProductD3Command
        {
            get
            {
                return new RelayCommand(AddProductD3);
            }
        }

        public ICommand AddProductD4Command
        {
            get
            {
                return new RelayCommand(AddProductD4);
            }
        }

        public ICommand AddProductD5Command
        {
            get
            {
                return new RelayCommand(AddProductD5);
            }
        }

        public ICommand CartCommand
        {
            get
            {
                return new RelayCommand(Cart);
            }
        }

        public ICommand LogoutCommand
        {
            get
            {
                return new RelayCommand(Logout);
            }
        }

        public ICommand AccountCommand
        {
            get
            {
                return new RelayCommand(Account);
            }
        }

        public ICommand AddressCommand
        {
            get
            {
                return new RelayCommand(AddressList);
            }
        }

        public ICommand PaymentCommand
        {
            get
            {
                return new RelayCommand(Payments);
            }
        }

        public ICommand RequestPaymentCommand
        {
            get
            {
                return new RelayCommand(RequestPayment);
            }
        }

        public HomeCommerceViewModel()
        {
            this.apiService = new ApiService();

            this.EnabledButtons();
            this.CheckAddress();
            this.GetCompanyName();
            this.LoadTickets();

            if (!string.IsNullOrEmpty(Settings.CartList)) {
                this.CartImage = "cart";
            } else
            {
                this.CartImage = "shoppingcart";
            }
            
            this.IsRefreshing = false;
        }

        private async void CheckAddress()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.CategoryID = null;

            if (mainViewModel.AddressDetail != null)
            {
                this.addressID = mainViewModel.AddressDetail.Id;

                this.LoadAddress();
                this.LoadCategories();
                this.LoadStores();
                this.LoadSales();
                this.LoadFeatured();
            } else
            {
                var connection = await this.apiService.CheckConnection();

                if (!connection.IsSuccess)
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        connection.Message,
                        "Aceptar");
                    return;
                }

                var response = await this.apiService.GetAddress(
                    mainViewModel.User.api_token,
                    "https://thenuap.com");

                if (response == null)
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ha ocurrido un error",
                        "Aceptar");
                    return;
                }

                if (response.Data == null)
                {
                    mainViewModel.CreateAddress = new CreateAddressViewModel();
                    await Application.Current.MainPage.Navigation.PushAsync(new CreateAddressPage());
                } else
                {
                    var list = response.Data;
                    mainViewModel.AddressDetail = list[0];
                    Settings.AddressDetail = JsonConvert.SerializeObject(mainViewModel.AddressDetail);

                    this.addressID = mainViewModel.AddressDetail.Id;

                    this.LoadAddress();
                    this.LoadCategories();
                    this.LoadStores();
                    this.LoadSales();
                    this.LoadFeatured();
                }
            }
        }

        private async void Account()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Account = new AccountViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new AccountPage());
        }

        private async void Logout()
        {
            Settings.Email = string.Empty;
            Settings.Token = string.Empty;
            Settings.Phone = string.Empty;
            Settings.UserType = string.Empty;
            Settings.AddressDetail = null;
            Settings.CartList = null;

            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.User = null;
            mainViewModel.AddressDetail = null;
            mainViewModel.CartList = null;

            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async void RequestPayment()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.PaymentRequest = new PaymentRequestViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new PaymentRequestPage());
        }

        private async void AddressList()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Address = new AddressViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new AddressPage());
        }

        private async void Payments()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Payments = new PaymentsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new PaymentsPage());
        }

        private async void GetCategoryProductsC1()
        {
            this.DisabledButtons();

            this.IsRefreshingInit = true;
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
                "https://thenuap.com");

            if (response == null)
            {
                this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ha ocurrido un error",
                    "Aceptar");
                return;
            }

            if (response.Data == null)
            {
                this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Errors.First().Detail,
                    "Aceptar"); 
                return;
            }

            var list = response.Data;

            foreach (var item in list)
            {
                if (item.Name == this.C1n)
                {
                    this.EnabledButtons();

                    mainViewModel.CategoryProduct = new CategoryProductViewModel(item);
                    await Application.Current.MainPage.Navigation.PushAsync(new CategoryProductsPage());
                }
            }
        }

        private async void GetCategoryProductsC2()
        {
            this.DisabledButtons();

            this.IsRefreshingInit = true;
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
                "https://thenuap.com");

            if (response == null)
            {
                this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ha ocurrido un error",
                    "Aceptar");
                return;
            }

            if (response.Data == null)
            {
                this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Errors.First().Detail,
                    "Aceptar");
                return;
            }

            var list = response.Data;


            foreach (var item in list)
            {
                if (item.Name == this.C2n)
                {
                    this.EnabledButtons();

                    mainViewModel.CategoryProduct = new CategoryProductViewModel(item);
                    await Application.Current.MainPage.Navigation.PushAsync(new CategoryProductsPage());
                }
            }
        }

        private async void GetCategoryProductsC3()
        {
            this.DisabledButtons();

            this.IsRefreshingInit = true;
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
                "https://thenuap.com");

            if (response == null)
            {
                this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ha ocurrido un error",
                    "Aceptar");
                return;
            }

            if (response.Data == null)
            {
                this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Errors.First().Detail,
                    "Aceptar");
                return;
            }

            var list = response.Data;


            foreach (var item in list)
            {
                if (item.Name == this.C3n)
                {
                    this.EnabledButtons();

                    mainViewModel.CategoryProduct = new CategoryProductViewModel(item);
                    await Application.Current.MainPage.Navigation.PushAsync(new CategoryProductsPage());
                }
            }
        }

        private async void GetCategoryProductsC4()
        {
            this.DisabledButtons();

            this.IsRefreshingInit = true;
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
                "https://thenuap.com");

            if (response == null)
            {
                this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ha ocurrido un error",
                    "Aceptar");
                return;
            }

            if (response.Data == null)
            {
                this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Errors.First().Detail,
                    "Aceptar");
                return;
            }

            var list = (List<Category>)response.Data;


            foreach (var item in list)
            {
                if (item.Name == this.C4n)
                {
                    this.EnabledButtons();

                    mainViewModel.CategoryProduct = new CategoryProductViewModel(item);
                    await Application.Current.MainPage.Navigation.PushAsync(new CategoryProductsPage());
                }
            }
        }

        private async void GetCategoryProductsC5()
        {
            this.DisabledButtons();

            this.IsRefreshingInit = true;
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
                "https://thenuap.com");

            if (response == null)
            {
                this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ha ocurrido un error",
                    "Aceptar");
                return;
            }

            if (response.Data == null)
            {
                this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Errors.First().Detail,
                    "Aceptar");
                return;
            }

            var list = response.Data;


            foreach (var item in list)
            {
                if (item.Name == this.C5n)
                {
                    this.EnabledButtons();

                    mainViewModel.CategoryProduct = new CategoryProductViewModel(item);
                    await Application.Current.MainPage.Navigation.PushAsync(new CategoryProductsPage());
                }
            }
        }

        private async void GetStoreOne()
        {
            this.DisabledButtons();

            this.IsRefreshingInit = true;
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

            var response = await this.apiService.GetStores(
                mainViewModel.User.api_token,
                "https://thenuap.com",
                mainViewModel.AddressDetail.Id);

            if (response == null)
            {
                this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ha ocurrido un error",
                    "Aceptar");
                return;
            }

            if (response.Data == null)
            {
                this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Informacion",
                    response.Errors.First().Detail,
                    "Aceptar");
                return;
            }

            var list = response.Data;


            foreach (var item in list)
            {
                if (item.BusinessName == this.S1n)
                {
                    this.EnabledButtons();

                    mainViewModel.Store = new StoreViewModel(item);
                    await Application.Current.MainPage.Navigation.PushAsync(new StoreTabbedPage());
                }
            }
        }

        private async void GetStoreTwo()
        {
            this.DisabledButtons();

            this.IsRefreshingInit = true;
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

            var response = await this.apiService.GetStores(
                mainViewModel.User.api_token,
                "https://thenuap.com",
                mainViewModel.AddressDetail.Id);

            if (response == null)
            {
                this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ha ocurrido un error",
                    "Aceptar");
                return;
            }

            if (response.Data == null)
            {
                this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Informacion",
                    response.Errors.First().Detail,
                    "Aceptar");
                return;
            }

            var list = response.Data;

            foreach (var item in list)
            {
                if (item.BusinessName == this.S2n)
                {
                    this.EnabledButtons();

                    mainViewModel.Store = new StoreViewModel(item);
                    await Application.Current.MainPage.Navigation.PushAsync(new StoreTabbedPage());
                }
            }
        }

        private async void GetStoreThree()
        {
            this.DisabledButtons();

            this.IsRefreshingInit = true;
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

            var response = await this.apiService.GetStores(
                mainViewModel.User.api_token,
                "https://thenuap.com",
                mainViewModel.AddressDetail.Id);

            if (response == null)
            {
                this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ha ocurrido un error",
                    "Aceptar");
                return;
            }

            if (response.Data == null)
            {
                this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Informacion",
                    response.Errors.First().Detail,
                    "Aceptar");
                return;
            }

            var list = response.Data;


            foreach (var item in list)
            {
                if (item.BusinessName == this.S3n)
                {
                    this.EnabledButtons();

                    mainViewModel.Store = new StoreViewModel(item);
                    await Application.Current.MainPage.Navigation.PushAsync(new StoreTabbedPage());
                }
            }
        }

        private async void GetStoreFour()
        {
            this.DisabledButtons();

            this.IsRefreshingInit = true;
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

            var response = await this.apiService.GetStores(
                mainViewModel.User.api_token,
                "https://thenuap.com",
                mainViewModel.AddressDetail.Id);

            if (response == null)
            {
                this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ha ocurrido un error",
                    "Aceptar");
                return;
            }

            if (response.Data == null)
            {
                this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Informacion",
                    response.Errors.First().Detail,
                    "Aceptar");
                return;
            }

            var list = response.Data;

            foreach (var item in list)
            {
                if (item.BusinessName == this.S4n)
                {
                    this.EnabledButtons();

                    mainViewModel.Store = new StoreViewModel(item);
                    await Application.Current.MainPage.Navigation.PushAsync(new StoreTabbedPage());
                }
            }
        }

        private async void GetStoreFive()
        {
            this.DisabledButtons();

            this.IsRefreshingInit = true;
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

            var response = await this.apiService.GetStores(
                mainViewModel.User.api_token,
                "https://thenuap.com",
                mainViewModel.AddressDetail.Id);

            if (response == null)
            {
                this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ha ocurrido un error",
                    "Aceptar");
                return;
            }

            if (response.Data == null)
            {
                this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Informacion",
                    response.Errors.First().Detail,
                    "Aceptar");
                return;
            }

            var list = response.Data;

            foreach (var item in list)
            {
                if (item.BusinessName == this.S5n)
                {
                    this.EnabledButtons();

                    mainViewModel.Store = new StoreViewModel(item);
                    await Application.Current.MainPage.Navigation.PushAsync(new StoreTabbedPage());
                }
            }
        }

        private void AddProductO1()
        {
            this.GetProduct(this.O1n);
        }

        private void AddProductO2()
        {
            this.GetProduct(this.O2n);
        }

        private void AddProductO3()
        {
            this.GetProduct(this.O3n);
        }

        private void AddProductO4()
        {
            this.GetProduct(this.O4n);
        }

        private void AddProductO5()
        {
            this.GetProduct(this.O5n);
        }

        private void AddProductD1()
        {
            this.GetProduct(this.D1n);
        }

        private void AddProductD2()
        {
            this.GetProduct(this.D2n);
        }

        private void AddProductD3()
        {
            this.GetProduct(this.D3n);
        }

        private void AddProductD4()
        {
            this.GetProduct(this.D4n);
        }

        private void AddProductD5()
        {
            this.GetProduct(this.D5n);
        }

        private async void GetProduct(string product)
        {
            this.DisabledButtons();
            var mainViewModel = MainViewModel.GetInstance();

            var response = await this.apiService.GetSales(
                mainViewModel.User.api_token,
                "https://thenuap.com",
                mainViewModel.AddressDetail.Id);

            if (response == null)
            {
                this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ha ocurrido un error",
                    "Aceptar");
                return;
            }

            if (response.Data == null)
            {
                /*this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Errors.First().Detail,
                    "Aceptar");*/
                return;
            }

            var list = response.Data;


            foreach (var item in list)
            {
                if (item.Name == product)
                {
                    this.EnabledButtons();

                    mainViewModel.ProductDetail = new ProductDetailViewModel(item);
                    await Application.Current.MainPage.Navigation.PushAsync(new ProductDetailPage());
                }
            }
        }

        private async void CreateTicket()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.CreateTicket = new CreateTicketViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new CreateTicketPage());
        }

        private async void Cart()
        {
            var mainViewModel = MainViewModel.GetInstance();
            if (mainViewModel.CartList == null)
            {
                mainViewModel.CartEmpty = new CartEmptyViewModel();
                await Application.Current.MainPage.Navigation.PushAsync(new CartEmptyPage());
            } else
            {
                mainViewModel.Cart = new CartViewModel();
                await Application.Current.MainPage.Navigation.PushAsync(new CartPage());
            }
        }

        private async void LoadTickets()
        {
            this.IsRefreshing = true;

            var mainViewModel = MainViewModel.GetInstance();

            var response = await this.apiService.GetTickets(
                mainViewModel.User.api_token,
                "https://thenuap.com");

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
                /*this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Errors.First().Detail,
                    "Aceptar");*/
                return;
            }

            mainViewModel.TicketList = (List<Ticket>)response.Data;
            this.Tickets = new ObservableCollection<TicketItemViewModel>(ToTicketViewModel());
            this.IsRefreshing = false;
        }

        private async void GetCompanyName()
        {
            var mainViewModel = MainViewModel.GetInstance();

            var response = await this.apiService.GetCommerceProfile(
                mainViewModel.User.api_token,
                "https://thenuap.com");

            if (response == null)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ha ocurrido un error",
                    "Aceptar");
                return;
            }

            if (response.Data == null)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Errors.First().Detail,
                    "Aceptar");
                return;
            }

            this.CompanyName = response.Data.BusinessName;
            this.Logo = "https://thenuap.com/" + response.Data.UrlLogo;
        }

        private async void EditProfile()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.CommerceProfile = new CommerceProfileViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new CommerceProfilePage());
        }

        private async void Inventory()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Inventory = new InventoryViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new InventoryPage());
        }

        private async void Orders()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Orders = new OrdersViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new OrdersPage());
        }

        private async void Sales()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Sales = new SalesViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new SalesPage());
        }

        private async void GetAllCategories()
        {
            var mainViewModel = MainViewModel.GetInstance();
            
            mainViewModel.AllCategories = new CategoryViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new CategoryPage());
        }

        private async void LoadAddress()
        {
            this.IsRefreshingInit = true;

            var mainViewModel = MainViewModel.GetInstance();

            var response = await this.apiService.GetAddress(
                mainViewModel.User.api_token,
                "https://thenuap.com");

            if (response == null)
            {
                this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ha ocurrido un error",
                    "Aceptar");
                return;
            }

            if (response.Data == null)
            {
                /*this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Errors.First().Detail,
                    "Aceptar");*/
                return;
            }

            var list = response.Data;

            this.ViewAddressOne = false;
            this.ViewAddressTwo = false;
            this.ViewAddressThree = false;
            this.ViewAddressFour = false;
            this.ViewAddressFive = false;

            int count = 0;
            foreach (var item in list)
            {
                if (string.IsNullOrEmpty(Settings.AddressText))
                {
                    this.AddressOneColor = "#b1d9fc";
                    this.AddressOne = mainViewModel.AddressDetail.Addres;
                    this.AddressOneN = mainViewModel.AddressDetail.Neighborhood;
                    this.ViewAddressOne = true;
                } else if (count == 0)
                {
                    this.AddressOneColor = "#e9e9e9";
                    this.AddressOne = item.Addres;
                    this.AddressOneN = item.Neighborhood;
                    this.ViewAddressOne = true;
                }

                if (count == 1 && item.Id != this.addressID)
                {
                    this.AddressTwoColor = "#e9e9e9";
                    this.AddressTwo = item.Addres;
                    this.AddressTwoN = item.Neighborhood;
                    this.ViewAddressTwo = true;
                }

                if (count == 2 && item.Id != this.addressID)
                {
                    this.AddressThreeColor = "#e9e9e9";
                    this.AddressThree = item.Addres;
                    this.AddressThreeN = item.Neighborhood;
                    this.ViewAddressThree = true;
                }

                if (count == 3 && item.Id != this.addressID)
                {
                    this.AddressFourColor = "#e9e9e9";
                    this.AddressFour = item.Addres;
                    this.AddressFourN = item.Neighborhood;
                    this.ViewAddressFour = true;
                }

                if (count == 4 && item.Id != this.addressID)
                {
                    this.AddressFiveColor = "#e9e9e9";
                    this.AddressFive = item.Addres;
                    this.AddressFiveN = item.Neighborhood;
                    this.viewAddressFive = true;
                }

                if ((item.Id != this.addressID) || count == 0)
                {
                    count++;
                }
            }

            this.Address = new ObservableCollection<Address>(list);
            this.IsRefreshingInit = false;
        }

        private async void LoadCategories()
        {
            this.IsRefreshingInit = true;
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
                "https://thenuap.com");

            if (response == null)
            {
                this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ha ocurrido un error",
                    "Aceptar");
                return;
            }

            if (response.Data == null)
            {
                /*this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Errors.First().Detail,
                    "Aceptar*/
                return;
            }

            var list = response.Data;

            this.C1 = false;
            this.C2 = false;
            this.C3 = false;
            this.C4 = false;
            this.C5 = false;

            int count = 0;
            foreach (var item in list)
            {
                if (count == 0)
                {
                    this.C1n = item.Name;
                    this.C1i = "https://thenuap.com/" + item.Image;
                    this.C1 = true;
                }
                if (count == 1)
                {
                    this.C2n = item.Name;
                    this.C2i = "https://thenuap.com/" + item.Image;
                    this.C2 = true;
                }
                if (count == 2)
                {
                    this.C3n = item.Name;
                    this.C3i = "https://thenuap.com/" + item.Image;
                    this.C3 = true;
                }
                if (count == 3)
                {
                    this.C4n = item.Name;
                    this.C4i = "https://thenuap.com/" + item.Image;
                    this.C4= true;
                }
                if (count == 4)
                {
                    this.C5n = item.Name;
                    this.C5i = "https://thenuap.com/" + item.Image;
                    this.C5 = true;
                }
                count++;
            }

            this.IsRefreshingInit = false;
        }

        private async void LoadStores()
        {
            this.IsRefreshingInit = true;
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

            var response = await this.apiService.GetStores(
                mainViewModel.User.api_token,
                "https://thenuap.com",
                mainViewModel.AddressDetail.Id);

            if (response == null)
            {
                this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ha ocurrido un error",
                    "Aceptar");
                return;
            }

            if (response.Data == null)
            {
                /*this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Errors.First().Detail,
                    "Aceptar");*/
                return;
            }

            var list = response.Data;

            this.S1 = false;
            this.S2 = false;
            this.S3 = false;
            this.S4 = false;
            this.S5 = false;

            int count = 0;
            foreach (var item in list)
            {
                if (count == 0)
                {
                    this.S1n = item.BusinessName;
                    this.S1i = "https://thenuap.com/" + item.UrlLogo;
                    this.S1 = true;
                }
                if (count == 1)
                {
                    this.S2n = item.BusinessName;
                    this.S2i = "https://thenuap.com/" + item.UrlLogo;
                    this.S2 = true;
                }
                if (count == 2)
                {
                    this.S3n = item.BusinessName;
                    this.S3i = "https://thenuap.com/" + item.UrlLogo;
                    this.S3 = true;
                }
                if (count == 3)
                {
                    this.S4n = item.BusinessName;
                    this.S4i = "https://thenuap.com/" + item.UrlLogo;
                    this.S4 = true;
                }
                if (count == 4)
                {
                    this.S5n = item.BusinessName;
                    this.S5i = "https://thenuap.com/" + item.UrlLogo;
                    this.S5 = true;
                }
                count++;
            }

            this.IsRefreshingInit = false;
        }

        private async void LoadSales()
        {
            this.IsRefreshingInit = true;

            var mainViewModel = MainViewModel.GetInstance();

            var response = await this.apiService.GetSales(
                mainViewModel.User.api_token,
                "https://thenuap.com",
                mainViewModel.AddressDetail.Id);

            if (response == null)
            {
                this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ha ocurrido un error",
                    "Aceptar");
                return;
            }

            if (response.Data == null)
            {
                /*this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Errors.First().Detail,
                    "Aceptar");*/
                return;
            }

            var list = response.Data;

            this.O1 = false;
            this.O2 = false;
            this.O3 = false;
            this.O4 = false;
            this.O5 = false;

            int count = 0;
            foreach (var item in list)
            {
                string url;
                if (item.Image.Contains("https"))
                {
                    url = item.Image;
                }
                else
                {
                    url = "https://thenuap.com/" + item.Image;
                }

                if (count == 0)
                {
                    this.O1n = item.Name;
                    this.O1i = url;
                    this.O1 = true;
                    this.O1p = item.TotalPrice;
                    this.O1rp = item.FormatSalePrice;
                }
                if (count == 1)
                {
                    this.O2n = item.Name;
                    this.O2i = url;
                    this.O2 = true;
                    this.O2p = item.TotalPrice;
                    this.O2rp = item.FormatSalePrice;
                }
                if (count == 2)
                {
                    this.O3n = item.Name;
                    this.O3i = url;
                    this.O3 = true;
                    this.O3p = item.TotalPrice;
                    this.O3rp = item.FormatSalePrice;
                }
                if (count == 3)
                {
                    this.O4n = item.Name;
                    this.O4i = url;
                    this.O4 = true;
                    this.O4p = item.TotalPrice;
                    this.O4rp = item.FormatSalePrice;
                }
                if (count == 4)
                {
                    this.O5n = item.Name;
                    this.O5i = url;
                    this.O5 = true;
                    this.O5p = item.TotalPrice;
                    this.O5rp = item.FormatSalePrice;
                }
                count++;
            }

            this.IsRefreshingInit = false;
        }

        private async void LoadFeatured()
        {
            this.IsRefreshingInit = true;
            var mainViewModel = MainViewModel.GetInstance();

            var response = await this.apiService.GetSales(
                mainViewModel.User.api_token,
                "https://thenuap.com",
                mainViewModel.AddressDetail.Id);

            if (response == null)
            {
                this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ha ocurrido un error",
                    "Aceptar");
                return;
            }

            if (response.Data == null)
            {
                /*this.IsRefreshingInit = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Errors.First().Detail,
                    "Aceptar");*/
                return;
            }

            var list = response.Data;

            this.D1 = false;
            this.D2 = false;
            this.D3 = false;
            this.D4 = false;
            this.D5 = false;

            int count = 0;
            foreach (var item in list)
            {
                string url;
                if (item.Image.Contains("https"))
                {
                    url = item.Image;
                } else
                {
                    url = "https://thenuap.com/" + item.Image;
                }
                
                if (count == 0)
                {
                    this.D1n = item.Name;
                    this.D1i = url;
                    this.D1 = true;
                    this.D1p = item.TotalPrice;
                }
                if (count == 1)
                {
                    this.D2n = item.Name;
                    this.D2i = url;
                    this.D2 = true;
                    this.D2p = item.TotalPrice;
                }
                if (count == 2)
                {
                    this.D3n = item.Name;
                    this.D3i = url;
                    this.D3 = true;
                    this.D3p = item.TotalPrice;
                }
                if (count == 3)
                {
                    this.D4n = item.Name;
                    this.D4i = url;
                    this.D4 = true;
                    this.D4p = item.TotalPrice;
                }
                if (count == 4)
                {
                    this.D5n = item.Name;
                    this.D5i = url;
                    this.D5 = true;
                    this.D5p = item.TotalPrice;
                }
                count++;
            }

            this.IsRefreshingInit = false;
        }

        private IEnumerable<TicketItemViewModel> ToTicketViewModel()
        {
            return MainViewModel.GetInstance().TicketList.Select(t => new TicketItemViewModel
            {
                Id = t.Id,
                UserId = t.UserId,
                UserType = t.UserType,
                Issues = t.Issues,
                InitDate = t.InitDate,
                FinishDate = t.FinishDate,
                Status = t.Status,
                Description = t.Description
            });
        }

        private void EnabledButtons()
        {
            this.Enabled1 = true;
            this.Enabled2 = true;
            this.Enabled3 = true;
            this.Enabled4 = true;
            this.Enabled5 = true;
            this.Enabled6 = true;
            this.Enabled7 = true;
            this.Enabled8 = true;
            this.Enabled9 = true;
            this.Enabled10 = true;
            this.Enabled11 = true;
            this.Enabled12 = true;
            this.Enabled13 = true;
            this.Enabled14 = true;
            this.Enabled15 = true;
            this.Enabled16 = true;
            this.Enabled17 = true;
            this.Enabled18 = true;
            this.Enabled19 = true;
            this.Enabled20 = true;
        }

        private void DisabledButtons()
        {
            this.Enabled1 = false;
            this.Enabled2 = false;
            this.Enabled3 = false;
            this.Enabled4 = false;
            this.Enabled5 = false;
            this.Enabled6 = false;
            this.Enabled7 = false;
            this.Enabled8 = false;
            this.Enabled9 = false;
            this.Enabled10 = false;
            this.Enabled11 = false;
            this.Enabled12 = false;
            this.Enabled13 = false;
            this.Enabled14 = false;
            this.Enabled15 = false;
            this.Enabled16 = false;
            this.Enabled17 = false;
            this.Enabled18 = false;
            this.Enabled19 = false;
            this.Enabled20 = false;
        }
    }
}
