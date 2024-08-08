using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Domain.City.Requests.GetById
{
    public record GetCityByIdResp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
    }
}
