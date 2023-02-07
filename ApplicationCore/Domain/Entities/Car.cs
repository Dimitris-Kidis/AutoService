using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain.Entities
{
    public class Car : BaseEntity
    {
        public int ClientId { get; set; }
        public User Client { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Engine { get; set; }
        public string DriveType { get; set; }
        public string Transmission { get; set; }
        public string Mileage { get; set; }
        public string Services { get; set; }
        public ICollection<Consultation> Consultations { get; set; }
    }
}
