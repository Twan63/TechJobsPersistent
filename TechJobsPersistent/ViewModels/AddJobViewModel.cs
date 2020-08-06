using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using TechJobsPersistent.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TechJobsPersistent.ViewModels
{
    public class AddJobViewModel
    {
        public int EmployerId { get; set; }

       // [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }

      // [Required (ErrorMessage = "Skill is required")]
        public string JobSkill { get; set; }
        public List<int> SkillsId { get; set; }
        public List<Skill> Skill{ get; set; }
        public List<SelectListItem> Employers { get; set;  }
        public AddJobViewModel()
        {

        }
        public AddJobViewModel(List<Employer> employers, List<Skill> skills )
        {
            Employers = new List<SelectListItem>();

            foreach (var i in employers)
            {
                Employers.Add(new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = i.Name
                }) ;
                  
            }

            Skill = skills;


        }
    }

    
}
