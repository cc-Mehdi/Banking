using Banking.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Domain.Customers
{
    public class Customer
    {
        public Customer(string cif, string firstName, string lastName, string nationalCode, string mobile, DateTimeOffset? updatedAt = null, DateTimeOffset? deletedAt = null)
        {
            Id = Guid.NewGuid();
            CIF = new CIF(cif);

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                throw new Exception("Firstname or Lastname couldn't be empty");

            FirstName = firstName;
            LastName = lastName;

            if (string.IsNullOrWhiteSpace(nationalCode) || string.IsNullOrWhiteSpace(mobile))
                throw new Exception("NationalCode or Mobile couldn't be empty");

            NationalCode = nationalCode;
            Mobile = mobile;

            Activate();

            CreatedAt = DateTimeOffset.UtcNow;
            UpdatedAt = updatedAt;
            DeletedAt = deletedAt;
        }

        [Required(AllowEmptyStrings = false)]
        public Guid Id { get; private set; }

        [Required(AllowEmptyStrings = false)]
        public CIF CIF { get; private set; }

        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; private set; }

        [Required(AllowEmptyStrings = false)]
        public string LastName { get; private set; }

        [Required(AllowEmptyStrings = false)]
        public string NationalCode { get; private set; }

        [Required(AllowEmptyStrings = false)]
        public string Mobile { get; private set; }
        public CustomerStatus Status { get; private set; }
        public DateTimeOffset CreatedAt { get; private set; }
        public DateTimeOffset? UpdatedAt { get; private set; }
        public DateTimeOffset? DeletedAt { get; private set; }

        public void Activate()
        {
            this.Status = CustomerStatus.Active;
        }

        public void Block()
        {
            this.Status = CustomerStatus.Blocked;
        }
    }
}
