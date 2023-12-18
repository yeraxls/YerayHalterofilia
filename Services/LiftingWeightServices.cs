using db;
using db.Models;
using Microsoft.EntityFrameworkCore;
using YerayHalterofilia.Models;

namespace YerayHalterofilia.Services
{
    public class LiftingWeightServices : ILiftingWeightServices
    {
        private readonly WeightliftingContext _context;
        public LiftingWeightServices(WeightliftingContext context)
        {
            _context = context;
        }

        public async Task<List<ResultsLiftingWeightModels>> GetLiftingWeights()
        {
            var listResult = new List<ResultsLiftingWeightModels>();
            var liftingGrouped = await _context.Queryable<LiftingWeight>().Include(c => c.TypeLifting).Include(c => c.Competitor)
                .GroupBy(c => c.IdCompetitor).ToListAsync();
            var types = liftingGrouped.SelectMany(c => c.Select(n=>n.TypeLifting)).Distinct().ToList();
            liftingGrouped.ForEach(lift =>
            {
                listResult.Add(GenerateModel(lift, types));
            });

            return listResult.OrderByDescending(c => c.TotalWeight).ToList();
        }

        private ResultsLiftingWeightModels GenerateModel(IGrouping<int, LiftingWeight> lift, List<TypeLifting> types)
        {
            var dict = new Dictionary<string, double>();
            types.ForEach(type => {
                var result = lift.Any(c => c.IdTypeLifting == type.Id)?
                            lift.Where(l => l.IdTypeLifting == type.Id).Select(l => l.Weight).Max()
                            : 0;
                dict.Add(type.Name, result);
            });
            return new ResultsLiftingWeightModels
            {
                Name = lift.First().Competitor.Name,
                Values = dict,
                TotalWeight = dict.Values.Sum()
            };
        }

        public async Task CreateLiftingWeight(NewLiftingWeightModel liftingWeight)
        {
            await _context.Insert<LiftingWeight>(new LiftingWeight
            {
                IdCompetitor = liftingWeight.IdCompetitor,
                IdTypeLifting = liftingWeight.IdTypeLifting,
                Weight = liftingWeight.Weight
            });
            await _context.SaveAll();
        }

        public async Task UpdateLiftingWeight(LiftingsWeightModel liftingsWeight)
        {
            var liftingsWeightdb = await _context.Queryable<LiftingWeight>(t => t.Id == liftingsWeight.Id).FirstOrDefaultAsync();
            if (liftingsWeightdb == null)
                throw new Exception();
            liftingsWeightdb.IdTypeLifting = liftingsWeight.IdTypeLifting;
            liftingsWeightdb.IdCompetitor = liftingsWeight.IdCompetitor;
            liftingsWeightdb.Weight = liftingsWeight.Weight;
            await _context.SaveAll();
        }

        public async Task DeleteLiftingWeight(int id)
        {
            var liftingWeightdb = await _context.Queryable<LiftingWeight>(t => t.Id == id).FirstOrDefaultAsync();
            if (liftingWeightdb == null)
                throw new Exception();
            _context.Delete<LiftingWeight>(liftingWeightdb);
            await _context.SaveAll();
        }

        public async Task<LiftingsWeightModel> GetLiftingWeightByIdCompetitor(int idCompetitor)
        {
            return await _context.Queryable<LiftingWeight>().Include(c => c.TypeLifting).Include(c => c.Competitor)
                .Select(c => (LiftingsWeightModel)c).FirstAsync();
        }

        public async Task<List<LiftingsWeightModel>> GetCompetitorByIdType(int idType)
        {
            return await _context.Queryable<LiftingWeight>(l => l.IdTypeLifting == idType).Include(c => c.TypeLifting).Include(c => c.Competitor)
                 .Select(c => (LiftingsWeightModel)c).ToListAsync();
        }
    }
}
