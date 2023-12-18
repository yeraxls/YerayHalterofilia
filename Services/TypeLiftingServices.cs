using db;
using db.Models;
using Microsoft.EntityFrameworkCore;
using YerayHalterofilia.Models;

namespace YerayHalterofilia.Services
{
    public class TypeLiftingServices : ITypeLiftingServices
    {
        private readonly WeightliftingContext _context;
        public TypeLiftingServices(WeightliftingContext context)
        {
            _context = context;
        }

        public async Task<List<TypeLiftingModel>> GetTypeLifting()
        {
            return await _context.Queryable<TypeLifting>()
                .Select(c => new TypeLiftingModel { Id = c.Id, Name = c.Name}).ToListAsync();
        }

        public async Task CreateTypeLifting(string type)
        {
            await _context.Insert<TypeLifting>(new TypeLifting { Name= type});
            await _context.SaveAll();
        }

        public async Task UpdateTypeLifting(TypeLiftingModel typeLifting)
        {
            var type = await _context.Queryable<TypeLifting>(t => t.Id == typeLifting.Id).FirstOrDefaultAsync();
            if (type == null)
                throw new Exception();
            type.Name = typeLifting.Name;
            await _context.SaveAll();
        }

        public async Task DeleteTypeLifting(int idTypeLifting)
        {
            var type = await _context.Queryable<TypeLifting>(t => t.Id == idTypeLifting).FirstOrDefaultAsync();
            if(type == null)
                throw new Exception();
            _context.Delete<TypeLifting>(type);
            await _context.SaveAll();
        }
    }
}
