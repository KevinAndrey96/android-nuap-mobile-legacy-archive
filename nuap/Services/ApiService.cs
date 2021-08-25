namespace nuap.Services
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Models;
    using Plugin.Connectivity;
    using System.Text;
    using System.Net.Http.Headers;

    public class ApiService
    {
        public async Task<Response> CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "No se ha podido conectar a internet.",
                };
            }

            var isReachable = await CrossConnectivity.Current.IsRemoteReachable(
                "67.205.184.22");
            if (!isReachable)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "No se ha podido conectar a internet.",
                };
            }

            return new Response
            {
                IsSuccess = true,
            };
        }

        public async Task<LoginResponse> GetUser(
            string urlBase,
            string email,
            string password,
            string type
        )
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var response = await client.PostAsync("/api/users/init",
                    new StringContent(string.Format(
                    "email={0}&password={1}&type={2}",
                    email, password, type),
                    Encoding.UTF8, "application/x-www-form-urlencoded"));
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<LoginResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<TicketMessageResponse> GetTicketMessages(
            string accessToken,
            string urlBase,
            int ticketId
        )
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.GetAsync("/api/users/ticket/" + ticketId + "/messages?api_token="+accessToken);
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TicketMessageResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<TicketResponse> GetTickets(
            string accessToken,
            string urlBase
        )
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.GetAsync("/api/users/ticket?api_token=" + accessToken);
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TicketResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ReplyTicketResponse> ReplyTicket(
           string accessToken,
           string urlBase,
           int ticketID,
           string message
        )
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.PostAsync("/api/users/ticket/reply?api_token=" + accessToken,
                new StringContent(string.Format(
                    "ticket_id={0}&message={1}",
                    ticketID, message),
                    Encoding.UTF8, "application/x-www-form-urlencoded"));
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ReplyTicketResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ReplyTicketResponse> CreateTicket(
            string accessToken,
            string urlBase,
            string issues,
            string message
        )
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.PostAsync("/api/users/ticket/create?api_token=" + accessToken,
                new StringContent(string.Format(
                    "issues={0}&message={1}",
                    issues, message),
                    Encoding.UTF8, "application/x-www-form-urlencoded"));
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ReplyTicketResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ProfileUserResponse> GetUserProfile(
            string accessToken,
            string urlBase
        )
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.GetAsync("/api/users/profile?api_token=" + accessToken);
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ProfileUserResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ReplyTicketResponse> EditProfile(
           string accessToken,
           string urlBase,
           string name,
           string email,
           string phone
        )
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.PostAsync("/api/users/profile/edit?api_token=" + accessToken,
                new StringContent(string.Format(
                    "name={0}&email={1}&phone={2}",
                    name, email, phone),
                    Encoding.UTF8, "application/x-www-form-urlencoded"));
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ReplyTicketResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ProfileCommerceResponse> GetCommerceProfile(
            string accessToken,
            string urlBase
        )
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.GetAsync("/api/commerces/profile?api_token=" + accessToken);
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ProfileCommerceResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<CategoryResponse> GetCategories(
            string accessToken,
            string urlBase,
            int categoryID
        )
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.GetAsync("/api/products/categories?id=" + categoryID + "&api_token=" + accessToken);
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<CategoryResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ProductResponse> GetProductsCommerce(
            string accessToken,
            string urlBase,
            int categoryID
        )
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.GetAsync("/api/products/category/" + categoryID + "?api_token=" + accessToken);
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ProductResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<OrderResponse> GetOrders(
            string accessToken,
            string urlBase
        )
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.GetAsync("/api/users/orders?api_token=" + accessToken);
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<OrderResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ReplyTicketResponse> CreateProduct(
           string accessToken,
           string urlBase,
           int categoryID,
           string name,
           string sku,
           string brand,
           string description,
           int stock,
           double weight,
           double height,
           double length,
           double width,
           double purchasePrice,
           double salePrice,
           double specialPrice,
           int hasSpecialPrice,
           int isFeatured,
           string imageArray
        )
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var response = await client.PostAsync("/api/products/commerce/create?api_token=" + accessToken,
                new StringContent(string.Format(
                    "category_id={0}&name={1}&sku={2}&brand={3}&description={4}&is_featured={5}&stock={6}&weight={7}&length={8}&width={9}&height={10}&purchase_price={11}&sale_price={12}&special_price={13}&has_special_price={14}&img={15}",
                    categoryID, name, sku, brand, description, isFeatured, stock, weight, length, width, height, purchasePrice, salePrice, specialPrice, hasSpecialPrice, imageArray),
                    Encoding.UTF8, "application/x-www-form-urlencoded"));
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ReplyTicketResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ReplyTicketResponse> EditProduct(
           string accessToken,
           string urlBase,
           int categoryID,
           string name,
           string sku,
           string brand,
           string description,
           int stock,
           double weight,
           double height,
           double length,
           double width,
           double purchasePrice,
           double salePrice,
           double specialPrice,
           int hasSpecialPrice,
           int isFeatured,
           int productID
        )
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.PostAsync("/api/products/commerce/create?api_token=" + accessToken,
                new StringContent(string.Format(
                    "has_special_price={0}&category_id={1}&name={2}&sku={3}&brand={4}&description={5}&is_featured={6}&stock={7}&weight={8}&length={9}&width={10}&height={11}&purchase_price={12}&sale_price={13}&special_price={14}&product_id={15}",
                    hasSpecialPrice, categoryID, name, sku, brand, description, isFeatured, stock, weight, length, width, height, purchasePrice, salePrice, specialPrice, productID),
                    Encoding.UTF8, "application/x-www-form-urlencoded"));
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ReplyTicketResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<OrderProductResponse> GetProductsByOrder(
            string accessToken,
            string urlBase,
            int orderId
        )
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.GetAsync("/api/users/orders/" + orderId + "/products?api_token=" + accessToken);
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<OrderProductResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ProfileCommerceResponse> GetSellerDetail(
            string accessToken,
            int sellerID,
            string urlBase
        )
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.GetAsync("/api/users/seller/" + sellerID + "/info?api_token=" + accessToken);
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ProfileCommerceResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ReplyTicketResponse> RatingOrder(
            string accessToken,
            string urlBase,
            int orderID,
            int rating,
            string comment
        )
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.PostAsync("/api/users/rating?api_token=" + accessToken,
                new StringContent(string.Format(
                    "order_id={0}&rating={1}&comment={2}",
                    orderID, rating, comment),
                    Encoding.UTF8, "application/x-www-form-urlencoded"));
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ReplyTicketResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<OrderResponse> GetSales(
            string accessToken,
            string urlBase
        )
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.GetAsync("/api/commerces/sales?api_token=" + accessToken);
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<OrderResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ReplyTicketResponse> UpdateStatus(
            string accessToken,
            string urlBase,
            int orderID
        )
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.GetAsync("/api/commerces/order/" + orderID + "/update?api_token=" + accessToken);
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ReplyTicketResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<AddressResponse> GetAddress(
            string accessToken,
            string urlBase
        )
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.GetAsync("/api/users/location?api_token=" + accessToken);
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<AddressResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<CategoryResponse> GetValidCategories(
            string accessToken,
            string urlBase
        )
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.GetAsync("/api/products/valid/categories?api_token=" + accessToken);
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<CategoryResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<StoreProductResponse> GetStores(
            string accessToken,
            string urlBase,
            int address
        )
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.GetAsync("/api/products/stores/address/" + address + "?api_token=" + accessToken);
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<StoreProductResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ProductResponse> GetSales(
            string accessToken,
            string urlBase,
            int address
        )
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.GetAsync("/api/products/sales/address/" + address + "?api_token=" + accessToken);
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ProductResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ProductResponse> GetFeatured(
            string accessToken,
            string urlBase,
            int address
        )
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.GetAsync("/api/products/featured/address/" + address + "?api_token=" + accessToken);
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ProductResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ProductResponse> GetCategoryProducts(
            string accessToken,
            string urlBase,
            int category,
            int address
        )
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.GetAsync("/api/products/category/" + category + "/address/" + address + "?api_token=" + accessToken);
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ProductResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ReplyTicketResponse> RegisterUser(
            string urlBase,
            string email,
            string password,
            string phone,
            string name,
            string last_name,
            string identity_number
        )
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var response = await client.PostAsync("/api/users/register/client",
                    new StringContent(string.Format(
                    "email={0}&password={1}&phone={2}&name={3}&last_name={4}&identity_number={5}",
                    email, password, phone, name, last_name, identity_number),
                    Encoding.UTF8, "application/x-www-form-urlencoded"));
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ReplyTicketResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<CalculateDeliveryResponse> CalculateDelivery(
            string urlBase,
            string accessToken,
            CartDataService listCart
        )
        {
            try
            {
                var request = JsonConvert.SerializeObject(listCart);
                var content = new StringContent(
                    request, Encoding.UTF8,
                    "application/json");
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.PostAsync("/api/products/calculate-delivery?api_token=" + accessToken, content);
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<CalculateDeliveryResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<CreateOrderResponse> CreateOrder(
            string urlBase,
            string accessToken,
            int address,
            CartDataService listCart
        )
        {
            try
            {
                var request = JsonConvert.SerializeObject(listCart);
                var content = new StringContent(
                    request, Encoding.UTF8,
                    "application/json");
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.PostAsync("/api/products/create-order/address/" + address + "?api_token=" + accessToken, content);
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<CreateOrderResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ReplyTicketResponse> GenerateOTP(
           string urlBase,
           string phone
       )
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var response = await client.PostAsync("/api/users/generate-otp",
                    new StringContent(string.Format(
                    "phone={0}",
                    phone),
                    Encoding.UTF8, "application/x-www-form-urlencoded"));
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ReplyTicketResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<LoginResponse> VerifyOTP(
           string urlBase,
           string phone,
           string code
        )
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var response = await client.PostAsync("/api/users/verify-otp",
                    new StringContent(string.Format(
                    "phone={0}&code={1}",
                    phone, code),
                    Encoding.UTF8, "application/x-www-form-urlencoded"));
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<LoginResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<PaymentResponse> GetPayments(
            string accessToken,
            string urlBase
        )
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.GetAsync("/api/commerces/payments?api_token=" + accessToken);
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<PaymentResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ReplyTicketResponse> RequestPayment(
            string accessToken,
            string urlBase,
            string value
        )
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.PostAsync("/api/commerces/request-payment?api_token=" + accessToken,
                new StringContent(string.Format(
                    "value={0}",value),
                    Encoding.UTF8, "application/x-www-form-urlencoded"));
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ReplyTicketResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<BankAccountResponse> CreateAccount(
           string accessToken,
           string urlBase,
           string ownerName,
           string ownerDocument,
           string ownerDocumentType,
           string account,
           string accountType,
           string bank
        )
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.PostAsync("/api/commerces/create/account?api_token=" + accessToken,
                new StringContent(string.Format(
                    "owner_name={0}&owner_document={1}&owner_document_type={2}&account={3}&account_type={4}&bank={5}",
                    ownerName, ownerDocument, ownerDocumentType, account, accountType, bank),
                    Encoding.UTF8, "application/x-www-form-urlencoded"));
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<BankAccountResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<BankAccountResponse> DetailAccount(
            string accessToken,
            string urlBase
        )
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.GetAsync("/api/commerces/detail/account?api_token=" + accessToken);
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<BankAccountResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ReplyTicketResponse> CreateAddress(
           string accessToken,
           string urlBase,
           string city,
           string location,
           string neighborhood,
           string address,
           string latitude,
           string longitude
        )
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.PostAsync("/api/users/location/create?api_token=" + accessToken,
                new StringContent(string.Format(
                    "city={0}&location={1}&neighborhood={2}&address={3}&latitude={4}&longitude={5}",
                    city, location, neighborhood, address, latitude, longitude),
                    Encoding.UTF8, "application/x-www-form-urlencoded"));
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ReplyTicketResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ReplyTicketResponse> DeleteLocation(
            string accessToken,
            string urlBase,
            int addressID
        )
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(urlBase);
                var response = await client.GetAsync("/api/users/location/"+addressID+"/delete?api_token=" + accessToken);
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ReplyTicketResponse>(resultJSON);

                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}