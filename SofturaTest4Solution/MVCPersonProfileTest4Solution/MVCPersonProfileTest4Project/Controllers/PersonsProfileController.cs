using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCPersonProfileTest4Project.Models;
using MVCPersonProfileTest4Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonProfileTest4Project.Controllers
{
    public class PersonsProfileController : Controller
    {
        private ILogger<PersonsProfileController> _logger;
        private IRepo<PersonsProfile> _repo;
        public PersonsProfileController(IRepo<PersonsProfile> repo, ILogger<PersonsProfileController> logger)
        {
            _logger = logger;
            _repo = repo;
        }
        public IActionResult Index()
        {
            List<PersonsProfile> personsprofile = _repo.GetAll().ToList();
            return View(personsprofile);
        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(PersonsProfile personsprofile)
        {
            _repo.Add(personsprofile);
            return RedirectToAction("Index");

        }
         public IActionResult Edit(int id)
        {
            PersonsProfile personsprofile = _repo.Get(id);
;            return View(personsprofile);

        }
        [HttpPost]
        public IActionResult Edit(int id,PersonsProfile personsprofile )
        {
            _repo.Update(id, personsprofile);
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            PersonsProfile personsprofile = _repo.Get(id);
            return View(personsprofile);

        }
        [HttpPost]
        public IActionResult Delete(PersonsProfile personsprofile)
        {
            _repo.Delete(personsprofile);
            return RedirectToAction("Index");

        }

    }
}
