namespace nuap.ViewModels
{
    using Models;
    using System.Collections.Generic;

    public class MainViewModel
    {
        public string AddressText
        {
            get;
            set;
        }

        public string AddressNeighborhood
        {
            get;
            set;
        }

        public int AddressID
        {
            get;
            set;
        }

        public TermsAndConditionsViewModel TermsAndConditions
        {
            get;
            set;
        }

        public ChangePasswordViewModel ChangePassword
        {
            get;
            set;
        }

        public LoginViewModel Login
        {
            get;
            set;
        }

        public VoucherViewModel VoucherPopup
        {
            get;
            set;
        }

        public AddAndRemoveProductsViewModel AddAndRemoveProductsPopup
        {
            get;
            set;
        }

        public SelectAddressViewModel SelectAddress
        {
            get;
            set;
        }

        public string VoucherImage
        {
            get;
            set;
        }

        public StoreViewModel Store
        {
            get;
            set;
        }

        public HomeCommerceViewModel HomeCommerce
        {
            get;
            set;
        }

        public SupportViewModel Support
        {
            get;
            set;
        }

        public MessagesViewModel Messages
        {
            get;
            set;
        }

        public AccountViewModel Account
        {
            get;
            set;
        }

        public CreateOrderSuccessViewModel CreateOrderSuccess
        {
            get;
            set;
        }

        public CreateTicketViewModel CreateTicket
        {
            get;
            set;
        }

        public CreateOrderViewModel CreateOrder
        {
            get;
            set;
        }

        public UserProfileViewModel UserProfile
        {
            get;
            set;
        }

        public CommerceProfileViewModel CommerceProfile
        {
            get;
            set;
        }

        public InventoryViewModel Inventory
        {
            get;
            set;
        }

        public ProductCommerceViewModel ProductCommerce
        {
            get;
            set;
        }

        public CreateProductViewModel CreateProduct
        {
            get;
            set;
        }

        public EditProductViewModel EditProduct
        {
            get;
            set;
        }

        public OrdersViewModel Orders
        {
            get;
            set;
        }

        public OrderDetailViewModel OrderDetail
        {
            get;
            set;
        }

        public SellerDetailViewModel SellerDetail
        {
            get;
            set;
        }

        public RatingViewModel Rating
        {
            get;
            set;
        }

        public SalesViewModel Sales
        {
            get;
            set;
        }

        public SalesDetailViewModel SalesDetail
        {
            get;
            set;
        }

        public PaymentDetailViewModel PaymentDetail
        {
            get;
            set;
        }

        public UpdateOrderStatusViewModel UpdateOrderStatus
        {
            get;
            set;
        }

        public CategoryViewModel AllCategories
        {
            get;
            set;
        }

        public CategoryProductViewModel CategoryProduct
        {
            get;
            set;
        }

        public ProductDetailViewModel ProductDetail
        {
            get;
            set;
        }

        public AddressViewModel Address
        {
            get;
            set;
        }

        public CartViewModel Cart
        {
            get;
            set;
        }

        public CartEmptyViewModel CartEmpty
        {
            get;
            set;
        }

        public PaymentGatewayViewModel PaymentGateway
        {
            get;
            set;
        }

        public CreateAddressViewModel CreateAddress
        {
            get;
            set;
        }

        public CreateDefaultAddressViewModel CreateAddressDefault
        {
            get;
            set;
        }

        public GenerateOtpViewModel GenerateOTP
        {
            get;
            set;
        }

        public VerifyOtpViewModel VerifyOTP
        {
            get;
            set;
        }

        public PaymentsViewModel Payments
        {
            get;
            set;
        }

        public PaymentRequestViewModel PaymentRequest
        {
            get;
            set;
        }

        public PaymentConfirmViewModel PaymentConfirm
        {
            get;
            set;
        }


        public User User
        {
            get;
            set;
        }

        public List<Ticket> TicketList
        {
            get;
            set;
        }

        public List<Category> CategoryList
        {
            get;
            set;
        }

        public List<Cart> CartList
        {
            get;
            set;
        }

        public Address AddressDetail
        {
            get;
            set;
        }

        public List<Product> ProductCategoryList
        {
            get;
            set;
        }

        public List<Order> OrderList
        {
            get;
            set;
        }

        public List<Product> ProductList
        {
            get;
            set;
        }

        public int CategoryProductID
        {
            get;
            set;
        }

        public Category CategoryID
        {
            get;
            set;
        }

        public int SellerID
        {
            get;
            set;
        }

        public int OrderID
        {
            get;
            set;
        }

        public string OrderStatus
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public string OrderAddress
        {
            get;
            set;
        }

        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
        }

        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
    }
}
