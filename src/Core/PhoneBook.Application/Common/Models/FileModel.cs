using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Common.Models
{
    public record FileModel(string FileName, string ContentType, byte[] FileBytes);
}
