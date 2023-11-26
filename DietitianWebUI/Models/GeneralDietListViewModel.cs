using Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianWebUI.Models
{
    public class GeneralDietListViewModel
    {
        public GeneralDietList GeneralDietList { get; set; }
        public List<GeneralDietList> GeneralDietLists { get; set; }
        public IEnumerable<SelectListItem> Customers { get; set; }
    }
}
