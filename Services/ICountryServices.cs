using YerayHalterofilia.Models;

namespace YerayHalterofilia.Services
{
    public interface ICountryServices
    {
        Task CreateCountry(string type, string cod);
        Task DeleteCountry(int idCountry);
        Task<List<CountryModel>> GetCountries();
        Task UpdateCountry(CountryModel country);
    }
}