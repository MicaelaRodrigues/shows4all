using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shows4AllMicaela.Data
{
    public enum Role
    {
        Administrator,
        Client
    }

    public class User
    {
        public int Id { get; set; }
        public Role UserType { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }


    }
}
