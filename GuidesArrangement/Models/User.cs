using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidesArrangement
{
    internal class User
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string id, string name, string username, string password)
        {
            Id = id;
            Name = name;
            Username = username;
            Password = password;
        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
