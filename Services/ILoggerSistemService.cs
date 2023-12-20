namespace YerayHalterofilia.Services
{
    public interface ILoggerSistemService
    {
        void Write(string action, string message, bool itsError = false);
    }
}