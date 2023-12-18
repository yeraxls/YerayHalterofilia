using db.Models;

namespace YerayHalterofilia.Models
{
    public class TypeLiftingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static explicit operator TypeLifting(TypeLiftingModel typeLifting)
        {
            return new TypeLifting
            {
                Id = typeLifting.Id,
                Name = typeLifting.Name
            };
        }

        public static explicit operator TypeLiftingModel(TypeLifting typeLifting)
        {
            return new TypeLiftingModel
            {
                Id = typeLifting.Id,
                Name = typeLifting.Name
            };
        }
    }
}
