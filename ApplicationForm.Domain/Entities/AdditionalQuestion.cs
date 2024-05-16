using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForm.Domain.Entities
{
    public class AdditionalQuestion
    {
        public string? Question { get; set; }

        public List<string> Answer { get; set; }
    }
}
