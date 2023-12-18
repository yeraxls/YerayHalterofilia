using YerayHalterofilia.Models;

namespace YerayHalterofilia.Services
{
    public interface ITypeLiftingServices
    {
        Task CreateTypeLifting(string type);
        Task DeleteTypeLifting(int idTypeLifting);
        Task<List<TypeLiftingModel>> GetTypeLifting();
        Task UpdateTypeLifting(TypeLiftingModel typeLifting);
    }
}