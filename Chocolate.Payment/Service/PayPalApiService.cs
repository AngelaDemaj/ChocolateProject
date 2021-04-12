using Chocolate.Payment.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Chocolate.Payment.Service.Interfaces;

namespace Chocolate.Payment.Service
{
    public class PayPalApiService : IPayPalApiService
    {
        public IConfiguration Configuration { get; }

        public PayPalApiService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<string> GetRedirectUrlToPayPal(double total, string currency)
        {
            try
            {
                var http = GetPayPalHttpClient();
                var accessToken = await GetPayPalAccessTokenAsync(http);
                var createdPayment = await CreatePayPalPaymentAsync(http, accessToken, total, currency);
                return createdPayment.links.First(x => x.rel == "approval_url").href;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex, "Failed to login to PayPal");
                return null;
            }
        }

        public async Task<PayPalPaymentExecutedResponse> ExecutedPayment(string paymentId, string payerId)
        {
            try
            {
                var http = GetPayPalHttpClient();
                var accessToken = await GetPayPalAccessTokenAsync(http);
                return await ExecutePayPalPaymentAsync(http, accessToken, paymentId, payerId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex, "Failed to login to PayPal");
                return null;
            }
        }

        private static HttpClient GetPayPalHttpClient()
        {
            const string sandbox = "https://api.sandbox.paypal.com";
            var http = new HttpClient
            {
                BaseAddress = new Uri(sandbox),
                Timeout = TimeSpan.FromSeconds(30)
            };
            return http;
        }

        private async Task<PayPalAccessToken> GetPayPalAccessTokenAsync(HttpClient http)
        {
            var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes($"{Configuration["PayPal:clientId"]}:{Configuration["PayPal:secret"]}");

            HttpRequestMessage request = new(HttpMethod.Post, "/v1/oauth2/token");

            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(bytes));

            var form = new Dictionary<string, string>
            {
                ["grant_type"] = "client_credentials"
            };

            request.Content = new FormUrlEncodedContent(form);

            HttpResponseMessage response = await http.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            PayPalAccessToken accessToken = JsonConvert.DeserializeObject<PayPalAccessToken>(content);
            return accessToken;
        }

        private async Task<PayPalPaymentCreatedResponse> CreatePayPalPaymentAsync(HttpClient http, PayPalAccessToken accessToken, double total, string currency)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "v1/payments/payment");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.access_token);

            var payment = JObject.FromObject(new
            {
                intent = "sale",
                redirect_urls = new
                {
                    return_url = Configuration["PayPal:returnUrl"],
                    cancel_url = Configuration["PayPal:cancelUrl"]
                },
                payer = new { payment_method = "paypal" },
                transactions = JArray.FromObject(new[]
                {
                    new
                    {
                        amount = new
                        {
                            total,
                            currency
                        }
                    }
                })
            });

            request.Content = new StringContent(JsonConvert.SerializeObject(payment), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await http.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            var paypalPaymentCreated = JsonConvert.DeserializeObject<PayPalPaymentCreatedResponse>(content);
            return paypalPaymentCreated;
        }

        private static async Task<PayPalPaymentExecutedResponse> ExecutePayPalPaymentAsync(HttpClient http, PayPalAccessToken accessToken, string paymentId, string payerId)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"v1/payments/payment/{paymentId}/execute");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.access_token);

            var payment = JObject.FromObject(new
            {
                payer_id = payerId
            });

            request.Content = new StringContent(JsonConvert.SerializeObject(payment), Encoding.UTF8, "application/json");

            var response = await http.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var executedPayment = JsonConvert.DeserializeObject<PayPalPaymentExecutedResponse>(content);
            return executedPayment;
        }
    }
}
