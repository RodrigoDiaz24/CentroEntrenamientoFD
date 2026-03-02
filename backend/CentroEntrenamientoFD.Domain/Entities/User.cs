using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEntrenamientoFD.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string? GoogleId { get; private set; }

        private User() { }

        public User(string email, string fullName, string passwordHash, string? googleId = null)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            Email = email;
            PasswordHash = passwordHash;
            GoogleId = googleId;
        }

        public void SetGoogleId(string googleId)
        {
            GoogleId = googleId;
        }
    }
}
