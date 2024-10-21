using SingleLog.Enums;
using SingleLog.Models;
using SingleLog.Utilities;

namespace SingleLog.Interfaces
{
    public interface ISingleLog<T1, T2> where T1 : BaseLogStep where T2 : Enumeration
    {
        Task<T1> CreateBaseLogAsync();
        Task<T1> GetBaseLogAsync();
        Task WriteLogAsync(LogTypes typeLog, T1 value);
        Task WriteLogAsync(T1 value);
    }
}
