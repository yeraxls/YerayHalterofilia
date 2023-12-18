namespace YerayHalterofilia.Models
{
    public class ResultsLiftingWeightModels
    {
        public required string Name { get; set; }
        public Dictionary<string, double> Values { get; set; }
        public double TotalWeight { get; set; }
    }
}
