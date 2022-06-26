using System.Threading.Tasks;
using TestAPI.Models;

namespace TestAPI.Services
{
    public interface ILoveQuoteServices
    {
        Task<LoveQuote> GetRandomLoveQuote();
    }
}
