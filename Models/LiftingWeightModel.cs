using db.Models;

namespace YerayHalterofilia.Models
{
    public class LiftingsWeightModel
    {
        public int Id { get; set; }
        public int IdTypeLifting { get; set; }
        public TypeLiftingModel TypeLift { get; set; }
        public int IdCompetitor { get; set; }
        public CompetitorModel Competitor { get; set; }
        public double Weight { get; set; }


        public static explicit operator LiftingWeight(LiftingsWeightModel liftingsWeight)
        {
            return new LiftingWeight
            {
                Id = liftingsWeight.Id,
                IdCompetitor = liftingsWeight.IdCompetitor,
                IdTypeLifting = liftingsWeight.IdTypeLifting,
                Weight = liftingsWeight.Weight
            };
        }

        public static explicit operator LiftingsWeightModel(LiftingWeight liftingWeight)
        {
            var competitor = (CompetitorModel)liftingWeight.Competitor;
            var typeLifting = (TypeLiftingModel)liftingWeight.TypeLifting;
            var lift = new LiftingsWeightModel
            {
                Id = liftingWeight.Id,
                IdCompetitor = liftingWeight.IdCompetitor,
                IdTypeLifting = liftingWeight.IdTypeLifting,
                Weight = liftingWeight.Weight,
                Competitor = competitor,
                TypeLift = typeLifting
            };
            return lift;
        }
    }
}
