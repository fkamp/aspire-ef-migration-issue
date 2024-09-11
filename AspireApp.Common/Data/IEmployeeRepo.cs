using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspireApp.Common.Data;

public interface IEmployeeRepo
{
    Task<IEnumerable<Employee>> GetEmployeesAsync(int count, int page);

    Task<Employee?> GetEmployeeAsync(Guid id);

    Task AddEmployeeAsync(Employee employee);
}
