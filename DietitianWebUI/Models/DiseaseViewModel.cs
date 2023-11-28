using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianWebUI.Models
{
    public class DiseaseViewModel
    {
        public Disease Disease { get; set; }
        public List<Disease> Diseases { get; set; }
    }
}
