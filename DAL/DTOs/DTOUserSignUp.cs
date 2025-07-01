using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    public class DTOUserSignUp
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class DTOUserCreated
    {
        public int PersonID { get; set; }
        public string Email { get; set; }
    }
}
