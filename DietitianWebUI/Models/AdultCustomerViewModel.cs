using Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianWebUI.Models
{
    public class AdultCustomerViewModel
    {
        public AdultCustomer AdultCustomer { get; set; }
        public AdultCustomerDetail AdultCustomerDetail { get; set; }
        public List<AdultCustomer> AdultCustomers { get; set; }
        public IEnumerable<SelectListItem>  Diseases { get; set; }
        
    }
}
