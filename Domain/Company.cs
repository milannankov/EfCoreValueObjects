using System;
using System.Collections.Generic;
using System.Linq;

namespace EfCoreValueObjects
{
    public class Company
    {
        private List<CompanyAddress> addresses = new List<CompanyAddress>();

        public Company(Guid id, string name)
        {
            Assertions.AssertNotNullAndNotEmpty(name, "Must provide name");

            this.Id = id;
            this.Name = name;
        }

        public Guid Id { get; }
        
        public string Name { get; }

        public IEnumerable<CompanyAddress> Addresses
        {
            get
            {
                return this.addresses;
            }
        }

        public void AssignAddress(CompanyAddress address)
        {
            Assertions.AssertNotNull(address, "Must provide address");

            var exists = this.addresses.Contains(address);

            if (!exists)
            {
                this.addresses.Add(address);
            }
        }
    }
}