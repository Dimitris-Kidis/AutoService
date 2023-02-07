using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace ApplicationCore.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public bool Role { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Avatar { get; set; }
        public string Password { get; set; }
        public string? Experience { get; set; }
        public string? Services { get; set; }
        public string? Description { get; set; }
        public ICollection<Consultation> ClientConsultation { get; set; }
        public ICollection<Consultation> MasterConsultation { get; set; }
        public ICollection<Message> ClientMessage { get; set; }
        public ICollection<Message> MasterMessage { get; set; }
        public ICollection<Car> Cars { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public string CreatedBy { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? LastModifiedAt { get; set; }

    }
}
