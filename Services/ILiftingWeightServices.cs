using YerayHalterofilia.Models;

namespace YerayHalterofilia.Services
{
    public interface ILiftingWeightServices
    {
        Task CreateLiftingWeight(NewLiftingWeightModel liftingWeight);
        Task DeleteLiftingWeight(int id);
        Task<List<LiftingsWeightModel>> GetCompetitorByIdType(int idType);
        Task<LiftingsWeightModel> GetLiftingWeightByIdCompetitor(int idCompetitor);
        Task<List<ResultsLiftingWeightModels>> GetLiftingWeights();
        Task UpdateLiftingWeight(LiftingsWeightModel liftingsWeight);
    }
}