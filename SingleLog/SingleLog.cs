using SingleLog.Enums;
using SingleLog.Interfaces;
using SingleLog.Models;
using SingleLog.Utilities;

namespace SingleLog
{
    public class SingleLog<T1, T2> : ISingleLog<T1, T2> where T1 : BaseLogStep where T2 : Enumeration
    {
        private readonly LoggerManager _loggerManager;
        private T1? _baseLog;

        public SingleLog()
        {
            if(_loggerManager is null)
                _loggerManager = new LoggerManager();
        }

        public Task<T1> CreateBaseLogAsync()
        {
            _baseLog = (T1)Activator.CreateInstance(typeof(T1))!;
            
            return Task.FromResult(_baseLog);
        }

        public Task<T1> GetBaseLogAsync() => Task.FromResult(_baseLog)!;

        public Task WriteLogAsync(LogTypes typeLog, T1 value)
        {
            foreach (var step in value.Steps.Values)
            {
                if (step is not null && step is SubLog)
                    ((SubLog)step).StopwatchStop();
            }

            value.StopwatchStop();

            _loggerManager.WriteLog(typeLog, value);

            return Task.CompletedTask;
        }

        public async Task WriteLogAsync(T1 value) => await WriteLogAsync(value.Level, value);
    }
}
