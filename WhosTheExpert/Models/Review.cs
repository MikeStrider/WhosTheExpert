using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WhosTheExpert.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        public string FromName { get; set; }

        [Required]
        public string ToName { get; set; }

        [Required]
        public string WriteUp { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        public int ProfessionId { get; set; }

    }
}
