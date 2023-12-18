using db;
using db.Models;
using Microsoft.EntityFrameworkCore;
using YerayHalterofilia.Models;

namespace YerayHalterofilia.Services
{
    public class CountryServices : ICountryServices
    {
        private readonly WeightliftingContext _context;
        public CountryServices(WeightliftingContext context)
        {
            _context = context;
        }

        public async Task<List<CountryModel>> GetCountries()
        {
            return await _context.Queryable<Country>()
                .Select(c => (CountryModel)c).ToListAsync();
        }

        public async Task CreateCountry(string type, string cod)
        {
            await _context.Insert<Country>(new Country { Name = type, Cod = cod });
            await _context.SaveAll();
        }

        public async Task UpdateCountry(CountryModel country)
        {
            var countrydb = await _context.Queryable<Country>(t => t.Id == country.Id).FirstOrDefaultAsync();
            if (countrydb == null)
                throw new Exception();
            countrydb.Name = country.Name;
            countrydb.Cod = country.Cod;
            await _context.SaveAll();
        }

        public async Task DeleteCountry(int idCountry)
        {
            var countrydb = await _context.Queryable<Country>(t => t.Id == idCountry).FirstOrDefaultAsync();
            if (countrydb == null)
                throw new Exception();
            _context.Delete<Country>(countrydb);
            await _context.SaveAll();
        }
    }
}
