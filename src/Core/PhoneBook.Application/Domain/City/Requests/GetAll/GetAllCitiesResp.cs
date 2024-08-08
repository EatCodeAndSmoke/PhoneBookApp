using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Domain.City.Requests.GetAllCities
{
    public record GetAllCitiesResp
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
