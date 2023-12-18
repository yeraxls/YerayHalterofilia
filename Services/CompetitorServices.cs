using db;
using db.Models;
using Microsoft.EntityFrameworkCore;
using YerayHalterofilia.Models;

namespace YerayHalterofilia.Services
{
    public class CompetitorServices : ICompetitorServices
    {
        private readonly WeightliftingContext _context;
        public CompetitorServices(WeightliftingContext context)
        {
            _context = context;
        }

        public async Task<List<CompetitorModel>> GetCompetitors()
        {
            return await _context.Queryable<Competitor>().Include(c => c.Country)
                .Select(c => (CompetitorModel)c).ToListAsync();
        }

        public async Task CreateCompetitor(NewCompetitorModel competitor)
        {
            await _context.Insert<Competitor>(new Competitor { Name = competitor.Name, IdCountry = competitor.IdCountry });
            await _context.SaveAll();
        }

        public async Task UpdateCompetitor(CompetitorModel competitor)
        {
            var competitordb = await _context.Queryable<Competitor>(t => t.Id == competitor.Id).FirstOrDefaultAsync();
            if (competitordb == null)
                throw new Exception();
            competitordb.Name = competitor.Name;
            competitordb.IdCountry = competitor.IdCountry;
            await _context.SaveAll();
        }

        public async Task DeleteCompetitor(int idCompetitor)
        {
            var competitordb = await _context.Queryable<Competitor>(t => t.Id == idCompetitor).FirstOrDefaultAsync();
            if (competitordb == null)
                throw new Exception();
            _context.Delete<Competitor>(competitordb);
            await _context.SaveAll();
        }

        public async Task<CompetitorModel> GetCompetitorById(int id)
        {
            return await _context.Queryable<Competitor>(c => c.Id == id).Include(c => c.Country)
               .Select(c => (CompetitorModel)c).FirstAsync();
        }

        public async Task<List<CompetitorModel>> GetCompetitorByIdCountry(int idCountry)
        {
            return await _context.Queryable<Competitor>(c => c.IdCountry == idCountry).Include(c => c.Country)
               .Select(c => (CompetitorModel)c).ToListAsync();
        }
    }
}
