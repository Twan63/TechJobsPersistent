using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsPersistent.Data;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    public class EmployerController : Controller
    {
        private JobDbContext context;

        public EmployerController(JobDbContext varname)
        {
            context = varname; 
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            // passes all of the employer objects in the database to the view 
            List<Employer> employers  = context.Employers.ToList();
            return View(employers);
        }

        public IActionResult Add()
        {
            AddEmployerViewModel  NewEmployerView = new AddEmployerViewModel();

            return View(NewEmployerView);
        }
        [HttpPost]
        public IActionResult ProcessAddEmployerForm( AddEmployerViewModel EmployerViewModel)
        {
            if (ModelState.IsValid)
            {
                Employer nooEmployer = new Employer
                {
                    Name = EmployerViewModel.Name,
                    Location = EmployerViewModel.Location,
                };

                // this adds the new employer to the table

                context.Employers.Add(nooEmployer);
                context.SaveChanges();

                return Redirect("/Employer");
            }
            return View("Add", EmployerViewModel);
        }
        
        public IActionResult About(int id)
        {
            Employer employSearch = context.Employers.Find(id);


            return View(employSearch);
        }
    }
}
