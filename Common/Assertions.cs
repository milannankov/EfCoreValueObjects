using System;
using System.Collections.Generic;
using System.Linq;

namespace EfCoreValueObjects
{
    public class Assertions
    {
        public static void AssertNotNull(object object1, string message)
        {
            if (object1 == null)
            {
                throw new ArgumentNullException(message);
            }
        }

        public static void AssertNotNullAndNotEmpty(string stringValue, string message)
        {
            if (stringValue == null || stringValue.Trim().Length == 0)
            {
                throw new InvalidOperationException(message);
            }
        }
    }
}