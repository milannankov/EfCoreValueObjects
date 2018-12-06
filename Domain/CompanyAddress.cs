using System;
using System.Collections.Generic;
using System.Linq;

namespace EfCoreValueObjects
{
    public class CompanyAddress : ValueObject
    {
        public CompanyAddress(string city, string addressLine1)
        {
            Assertions.AssertNotNullAndNotEmpty(city, "Must provide city");
            Assertions.AssertNotNullAndNotEmpty(addressLine1, "Must provide address line");

            this.City = city;
            this.AddressLine1 = addressLine1;
        }

        public string City { get; }

        public string AddressLine1 { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.City;
            yield return this.AddressLine1;
        }
    }
}