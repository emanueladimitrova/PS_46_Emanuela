using System;
using System.Collections.Generic;
using System.Text;

namespace UserLogin
{
    public class User
    {
        public Int32 UserId { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String FakNum { get; set; }
        public Int32 Role { get; set; }

        public DateTime Created { get; set; }

        public DateTime? ActiveUntil { get; set; }

    }
}
