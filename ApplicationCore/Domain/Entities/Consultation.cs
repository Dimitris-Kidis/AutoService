using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain.Entities
{
    public class Consultation : BaseEntity
    {
        public int ClientId { get; set; }
        public User Client { get; set; }

        public int MasterId { get; set; }
        public User Master { get; set; }
        public bool Done { get; set; }
        public bool Rated { get; set; }
        public int Stars { get; set; }
        public string Comment { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
