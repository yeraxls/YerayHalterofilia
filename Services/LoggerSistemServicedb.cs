using db;
using db.Models;

namespace YerayHalterofilia.Services
{
    public class LoggerSistemServicedb : ILoggerSistemService
    {
        private readonly WeightliftingContext _context;
        public LoggerSistemServicedb(WeightliftingContext context)
        {
            _context = context;
        }
        public async void Write(string action, string message, bool itsError = false)
        {
            await _context.Insert<Logs>(new Logs { Action = action, Message = message, ItsError = itsError });
            await _context.SaveAll();
        }
    }
}
