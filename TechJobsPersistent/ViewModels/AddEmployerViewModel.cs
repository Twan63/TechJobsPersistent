using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TechJobsPersistent.Models;

namespace TechJobsPersistent.ViewModels
{
    public class AddEmployerViewModel
    {
        [Required(ErrorMessage = "Name is Required")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Location is Required")]
        public string Location { get; set; }


        public AddEmployerViewModel()
        { 
            
        }
        
    }
        

}
