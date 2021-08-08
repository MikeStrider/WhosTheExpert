using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhosTheExpert.Models
{
    public class ReviewUserViewModel
    {
        public Review Review { get; set; }

        public IEnumerable<User> User { get; set; }
    }
}
