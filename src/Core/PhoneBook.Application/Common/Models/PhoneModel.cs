using PhoneBook.Application.Domain.PhoneNumber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Common.Models
{
    public record PhoneModel(string Number, PhoneNumberType NumberType);
}
