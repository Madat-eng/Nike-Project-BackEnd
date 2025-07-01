using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    public class DTOUserLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class DTOUserLoginResult
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string FullName { get; set; }
    }
}
