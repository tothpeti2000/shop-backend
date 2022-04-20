using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AsyncResult
    {
        public bool Succeeded { get; set; }
        public List<string> ErrorMessages { get; set; }
        public string? Token { get; set; }
    }
}
