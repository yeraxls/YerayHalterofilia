using YerayHalterofilia.Models;

namespace YerayHalterofilia.Services
{
    public interface ICompetitorServices
    {
        Task CreateCompetitor(NewCompetitorModel competitor);
        Task DeleteCompetitor(int idCompetitor);
        Task<List<CompetitorModel>> GetCompetitors();
        Task UpdateCompetitor(CompetitorModel competitor);
        Task<CompetitorModel> GetCompetitorById(int id);
        Task<List<CompetitorModel>> GetCompetitorByIdCountry(int idCountry);
    }
}