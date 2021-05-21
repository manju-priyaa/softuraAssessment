using Microsoft.Extensions.Logging;
using MVCPersonProfileTest4Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonProfileTest4Project.Services
{
    public class PersonsProfileManager : IRepo<PersonsProfile>
    {
        private PersonsProfileContext _context;
        private ILogger<PersonsProfileManager> _logger;
        public PersonsProfileManager(PersonsProfileContext context,ILogger<PersonsProfileManager> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Add(PersonsProfile t)
        {
            try
            {
                _context.personsprofiles.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                _logger.LogDebug(e.Message);
            }
        }

        public void Delete(PersonsProfile t)
        {
            try
            {
                _context.personsprofiles.Remove(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                _logger.LogDebug(e.Message);
            }
        }

        public PersonsProfile Get(int id)
        {
            try
            {
                PersonsProfile personsprofile = _context.personsprofiles.FirstOrDefault(a => a.Id == id);
                return personsprofile;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public IEnumerable<PersonsProfile> GetAll()
        {
            try
            {
                if (_context.personsprofiles.Count() == 0)
                    return null;
                return _context.personsprofiles.ToList();
            }
            catch (Exception e)
            {

                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public void Update(int id, PersonsProfile t)
        {
            PersonsProfile personsprofile = Get(id);
            if (personsprofile != null)
            {
                personsprofile.Name = t.Name;
                personsprofile.Age = t.Age;
                personsprofile.Qualification = t.Qualification;
                personsprofile.IsEmployed = t.IsEmployed;
                personsprofile.NoticePeriod = t.NoticePeriod;
                personsprofile.CurrentCTC = t.CurrentCTC;
            }
             _context.SaveChanges();
        }
    }
}
