using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWebApi.Repositories
{
    public class ValuesRepository : IValuesRepository
    {
        private const int Latency = 500;
        private readonly Dictionary<int, string> _values;

        public ValuesRepository()
        {
            _values = new Dictionary<int, string>
            {
                { 1, "value1" },
                { 2, "value2" },
                { 3, "value3" },
                { 4, "value4" },
                { 5, "value5" },
            };
        }

        public async Task CreateValue(int id, string value)
        {
            await Task.Delay(Latency);
            _values.Add(id, value);
        }

        public async Task DeleteValue(int id)
        {
            await Task.Delay(Latency);
            _values.Remove(id);
        }

        public async Task<string> GetValue(int id)
        {
            await Task.Delay(Latency);
            return _values[id];
        }

        public async Task<IEnumerable<string>> GetValues()
        {
            await Task.Delay(Latency);
            return _values.Values;
        }

        public async Task UpdateValue(int id, string value)
        {
            await Task.Delay(Latency);
            _values[id] = value;
        }
    }
}