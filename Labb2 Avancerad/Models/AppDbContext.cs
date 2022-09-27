using Bogus;
using Microsoft.EntityFrameworkCore;

namespace Labb2_Avancerad.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<Personal> Personals { get; set; }
        public DbSet<Department> Departments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var personalIds = 1;
            var personalStock = new Faker<Personal>()
                .RuleFor(m => m.PersonalId, f => personalIds++)
                .RuleFor(m => m.FirstName, f => f.Name.FirstName())
                .RuleFor(m => m.LastName, f => f.Name.LastName())
                .RuleFor(m => m.Adress, f => f.Address.FullAddress())
                .RuleFor(m => m.Email, f => f.Internet.Email())
                .RuleFor(m => m.Gender, f => f.Person.Gender.ToString())
                .RuleFor(m => m.PhoneNumber, f => f.Person.Phone.ToString())
                .RuleFor(m => m.Salary, f => ((double)f.Finance.Amount(100, 10000)))
                .RuleFor(m => m.DepartmentId, f => f.Random.Number(1, 5));


            var departmentIds = 1;

            var departmentStock = new Faker<Department>()
                .RuleFor(m => m.DepartmentId, f => departmentIds++)
                .RuleFor(m => m.DepartmentName, f => f.Commerce.Department());




            modelBuilder
                .Entity<Personal>()
                .HasData(personalStock.GenerateBetween(20, 20));

            modelBuilder
                .Entity<Department>()
                .HasData(departmentStock.GenerateBetween(5, 5));














        }
    }
}
