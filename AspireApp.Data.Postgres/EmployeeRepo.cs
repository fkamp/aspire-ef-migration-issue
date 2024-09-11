using AspireApp.Common;
using AspireApp.Common.Data;
using Microsoft.EntityFrameworkCore;


namespace AspireApp.Data.Postgres;

public class EmployeeRepo(ApplicationDbContext context) : IEmployeeRepo
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<Employee>> GetEmployeesAsync(int count, int page) =>
        await _context.Employees
            .OrderByDescending(p => p.Id)
            .Skip(count * (page - 1))
            .Take(count)
            .ToListAsync();



    public async Task<Employee?> GetEmployeeAsync(Guid id) =>
        await _context.Employees
            .Where(e => e.Id == id)
            .FirstOrDefaultAsync();


    public async Task AddEmployeeAsync(Employee employee)
    {
        _context.Add(employee);
        await _context.SaveChangesAsync();
    }
}
