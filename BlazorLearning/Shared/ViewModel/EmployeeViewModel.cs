using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorLearning.Shared.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? EmailId { get; set; }
        public string? Address { get; set; }
        public string? MobileNumber { get; set; }

    }
}
