using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class DiseaseDto :IDto
    {
        public int DiseaseId { get; set; }
        public string DiseaseName { get; set; }
        public string Energy { get; set; }
        public string Protein { get; set; }
        public string Carbohydrate { get; set; }
        public string Oil { get; set; }
        public string VitaminMineral { get; set; }
        public string Posa { get; set; }
        public string Alcohol { get; set; }
        public string Water { get; set; }
        public string Meal { get; set; }
        public string Cholesterol { get; set; }
        public string Salt { get; set; }
    }
}
