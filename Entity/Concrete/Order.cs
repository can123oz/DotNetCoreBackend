using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string FullName { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime ReturnDate { get; set; }
        public int DaysRented { get; set; }
    }
}
