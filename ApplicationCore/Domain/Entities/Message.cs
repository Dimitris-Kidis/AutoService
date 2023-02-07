using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain.Entities
{
    public class Message : BaseEntity
    {
        public int Sender { get; set; }
        public User Client { get; set; }

        public int Receiver { get; set; }
        public User Master { get; set; }
        public string Text { get; set; }
        public bool Seen { get; set; }
    }
}
