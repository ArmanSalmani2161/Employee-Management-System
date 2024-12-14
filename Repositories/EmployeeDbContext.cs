using webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace webapi.Repositories;

public class EmployeeDbContext : DbContext
{
    const string CONNECTION_STRING = "Server=localhost;Database=web_api;User=root;Password=Pratik2003@;";

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {

    }

    public DbSet<Employee> Employees { get; set; }

}