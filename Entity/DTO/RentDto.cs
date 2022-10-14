using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
    public class RentalDto : IDto
    {
        public int rentalId { get; set; }
        public int carId { get; set; }
        public int userId { get; set; }
    }
}
