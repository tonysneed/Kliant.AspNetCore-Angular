using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWebApi.Repositories
{
    public interface IValuesRepository
    {
        Task<IEnumerable<string>> GetValues();

        Task<string> GetValue(int id);

        Task CreateValue(int id, string value);

        Task UpdateValue(int id, string value);

        Task DeleteValue(int id);
    }
}