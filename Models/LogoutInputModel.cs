using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomanCinema.Models
{
    public class LogoutInputModel : LoginInputModel
    {
        public string LogoutId { get; internal set; }
    }
}
