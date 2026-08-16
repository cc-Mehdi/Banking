using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Domain.Common
{
    public class CIF
    {
        public string Value { get; }

        public CIF(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length != 8)
                throw new DomainException("Invalid CIF");

            Value = value;
        }
    }
}
