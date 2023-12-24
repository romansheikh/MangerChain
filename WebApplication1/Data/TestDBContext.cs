using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
namespace WebApplication1.Data
{
    public class TestDBContext : DbContext
    {
        public TestDBContext(DbContextOptions<TestDBContext> options) : base(options){}
        public DbSet<EmployeeInfo> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().HasData(
            new Position { Id = 1, Name = "General Manager" },
            new Position { Id = 2, Name = "Manager" },
            new Position { Id = 3, Name = "Office Executive" }           
             );

            modelBuilder.Entity<EmployeeInfo>().HasData(
                new EmployeeInfo
                {
                    Id = 1,
                    Name = "John",
                    Salary = 50000.00m,
                    IsBonusAdded = true,
                    JoinDate = DateTime.Parse("2020-01-15"),
                    PositionId = 1,
                    ManagerId = null
                },
                new EmployeeInfo
                {
                    Id = 2,
                    Name = "Ron",
                    Salary = 40000.00m,
                    IsBonusAdded = true,
                    JoinDate = DateTime.Parse("2021-05-20"),
                    PositionId = 2,
                    ManagerId = 1
                },
                new EmployeeInfo
                {
                    Id = 3,
                    Name = "Jack",
                    Salary = 30000.00m,
                    IsBonusAdded = false,
                    JoinDate = DateTime.Parse("2022-03-10"),
                    PositionId = 3,
                    ManagerId = 2
                },
                new EmployeeInfo
                {
                    Id = 4,
                    Name = "Jane",
                    Salary = 32000.00m,
                    IsBonusAdded = true,
                    JoinDate = DateTime.Parse("2022-08-05"),
                    PositionId = 3,
                    ManagerId = 2
                },
                new EmployeeInfo
                {
                    Id = 5,
                    Name = "Hun",
                    Salary = 28000.00m,
                    IsBonusAdded = false,
                    JoinDate = DateTime.Parse("2023-02-15"),
                    PositionId = 3,
                    ManagerId = 4
                },
                new EmployeeInfo
                {
                    Id = 6,
                    Name = "Mike",
                    Salary = 35000.00m,
                    IsBonusAdded = true,
                    JoinDate = DateTime.Parse("2021-10-12"),
                    PositionId = 2,
                    ManagerId = 1
                },
                new EmployeeInfo
                {
                    Id = 7,
                    Name = "Sara",
                    Salary = 29000.00m,
                    IsBonusAdded = false,
                    JoinDate = DateTime.Parse("2023-06-25"),
                    PositionId = 3,
                    ManagerId = 6
                },
                new EmployeeInfo
                {
                    Id = 8,
                    Name = "Alex",
                    Salary = 31000.00m,
                    IsBonusAdded = true,
                    JoinDate = DateTime.Parse("2023-08-18"),
                    PositionId = 3,
                    ManagerId = 6
                },
                new EmployeeInfo
                {
                    Id = 9,
                    Name = "Chris",
                    Salary = 27000.00m,
                    IsBonusAdded = false,
                    JoinDate = DateTime.Parse("2023-12-01"),
                    PositionId = 3,
                    ManagerId = 7
                },
                new EmployeeInfo
                {
                    Id = 10,
                    Name = "Emily",
                    Salary = 32000.00m,
                    IsBonusAdded = true,
                    JoinDate = DateTime.Parse("2022-11-09"),
                    PositionId = 3,
                    ManagerId = 7
                }
            );


        }

    }
}
