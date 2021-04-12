using System.Threading.Tasks;

namespace Chocolate.Payment.Service.Interfaces
{
    public interface IPayPalApiService
    {
        Task<string> GetRedirectUrlToPayPal(double total, string currency);
    }
}
