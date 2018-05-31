using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Chirper
    {
        [Key]
        public int id { set; get; }
        public string body { set; get; }
        public string email { set; get; }
        public string date_time { set; get; }

    }
}
