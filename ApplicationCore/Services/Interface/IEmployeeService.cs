using ApplicationCore.DomainModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services.Interface
{
    public interface IEmployeeService
    {
        Task CreateAsync(EmployeeDM model);

        Task DeleteAsync(int id);

        Task UpdateAsync(EmployeeDM model);

        Task<IReadOnlyList<EmployeeDM>> ListAllAsync();

        Task<EmployeeDM> GetBy(int id);

    }
}
