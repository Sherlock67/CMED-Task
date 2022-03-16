using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMED_DataAcessLayer.Models
{
    public class Prescription
    {
        [Key]
        public int Prescription_Id { get; set; }

        public DateTime Prescription_Date { get; set; }
      
        public string Name { get; set; }
       
        public int Age { get; set; }

        public string Gender { get; set; }

        public string Diagnosis { get; set; }

        public string Medicine { get; set; }

        public DateTime NextVisitDate { get; set; }
    }
}
