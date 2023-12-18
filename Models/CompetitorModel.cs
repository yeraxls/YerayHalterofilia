using db.Models;

namespace YerayHalterofilia.Models
{
    public class CompetitorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdCountry { get; set; }
        public CountryModel? Country { get; set; }

        public static explicit operator Competitor(CompetitorModel competitor)
        {
            return new Competitor
            {
                Id = competitor.Id,
                Name = competitor.Name,
                IdCountry = competitor.IdCountry
            };
        }

        public static explicit operator CompetitorModel(Competitor competitor)
        {
            var comp = new CompetitorModel
            {
                Id = competitor.Id,
                Name = competitor.Name,
                IdCountry = competitor.IdCountry
            };
            if(competitor.Country != null)
                comp.Country = (CountryModel)competitor.Country;
            return comp;
        }
    }
}
