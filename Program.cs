using System;
using Microsoft.EntityFrameworkCore;

namespace EfCoreValueObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            InitDb();

            using (var context = new CompanyContext())
            {
                var company = new Company(Guid.NewGuid(), "My Company");
                company.AssignAddress(new CompanyAddress("Sofia", "Mlados1"));
                company.AssignAddress(new CompanyAddress("Plovdiv", "Mlados1"));

                context.Companies.Add(company);
                context.SaveChanges();
            }
        }

        private static void InitDb()
        {
            using (var context = new CompanyContext())
            {
                context.Database.EnsureCreated();
                context.Database.Migrate();
            }
        }
    }
}
