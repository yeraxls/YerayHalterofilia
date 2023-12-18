using db.Models;

namespace YerayHalterofilia.Models
{
    public class CountryModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Cod { get; set; }


        public static explicit operator CountryModel(Country country)
        {
            return new CountryModel
            {
                Id = country.Id,
                Name = country.Name,
                Cod = country.Cod,
            };
        }
    }
}
