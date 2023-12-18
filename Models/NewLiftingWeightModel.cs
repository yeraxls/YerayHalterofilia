using db.Models;

namespace YerayHalterofilia.Models
{
    public class NewLiftingWeightModel
    {
        public int IdCompetitor { get; set; }
        public int IdTypeLifting { get; set; }
        public double Weight { get; set; }
    }
}
