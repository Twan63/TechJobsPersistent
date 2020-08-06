using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;
using TechJobsPersistent.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace TechJobsPersistent.Controllers
{
    public class HomeController : Controller
    {
        private JobDbContext context;

        public HomeController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Job> jobs = context.Jobs.Include(j => j.Employer).ToList();

            return View(jobs);
        }

        [HttpGet("/Add")]
        public IActionResult AddJob()
        {
            AddJobViewModel newJob = new AddJobViewModel(context.Employers.ToList(), context.Skills.ToList());
              
            return View(newJob);
        }

        public IActionResult ProcessAddJobForm(AddJobViewModel jobView, string[] selectedSkills )
        {
            if (ModelState.IsValid)
            {

                Job nooJob = new Job
                {
                    Name = jobView.Name,
                
                    EmployerId = jobView.EmployerId,
                    Employer = context.Employers.Find(jobView.EmployerId)
                };
                foreach (var i in selectedSkills)
                {
                    JobSkill nooSkill = new JobSkill
                    {
                        JobId = nooJob.Id,
                        Job = nooJob,
                        SkillId = Int32.Parse(i),
                       // Skill = nooJob.Skill

                    };
                    context.JobSkills.Add(nooSkill);
                }
                context.Jobs.Add(nooJob);
                context.SaveChanges();

                return Redirect("Index");

            }


            return View("Add", jobView);
        }

        public IActionResult Detail(int id)
        {
            Job theJob = context.Jobs
                .Include(j => j.Employer)
                .Single(j => j.Id == id);

            List<JobSkill> jobSkills = context.JobSkills
                .Where(js => js.JobId == id)
                .Include(js => js.Skill)
                .ToList();

            JobDetailViewModel viewModel = new JobDetailViewModel(theJob, jobSkills);
            return View(viewModel);
        }
    }
}
