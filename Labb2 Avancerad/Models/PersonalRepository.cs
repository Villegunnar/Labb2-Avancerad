using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Labb2_Avancerad.Models
{
    public class PersonalRepository : IPersonalRepository
    {

        private readonly AppDbContext _context;

        public PersonalRepository(AppDbContext context)
        {
            _context = context;
        }


        // Get All Personal
        public IEnumerable<Personal> GetAllPersonals
        {
            get
            {
                return _context.Personals;

                // För att Returnera Personal med Departments
                // return _context.Personals.Include(p => p.Department);
            }
        }

        // Get Singel Personal
        public Personal GetPersonalById(int personalId)
        {
            return _context.Personals.FirstOrDefault(x => x.PersonalId == personalId);
        }
        // Create Personal
        public Personal AddPersonal(Personal personal)
        {
            _context.Personals.Add(personal);

            return personal;

        }

        // Delete Personal
        public Personal DeletePersonal(int personalId)
        {
            var personalDelete = _context.Personals.FirstOrDefault(x => x.PersonalId == personalId);

            if (personalDelete != null)
            {
                _context.Personals.Remove(personalDelete);
                _context.SaveChanges();
                return personalDelete;
            }

            return null;
        }

        // Update Personal
        public Personal UpdatePersonal(Personal personal)
        {
          

            var personalUpdate = _context.Personals
               .FirstOrDefault(e => e.PersonalId == personal.PersonalId);



            if (personalUpdate != null)
            {

                personalUpdate.FirstName = personal.FirstName;
                personalUpdate.LastName = personal.LastName;
                personalUpdate.Email = personal.Email;
                personalUpdate.Gender = personal.Gender;
                personalUpdate.Adress = personal.Adress;
                personalUpdate.Salary = personal.Salary;
                personalUpdate.PhoneNumber = personal.PhoneNumber;
                personalUpdate.DepartmentId = personal.DepartmentId;

                _context.SaveChanges();
                return personalUpdate;
            }

            return null;
        }
    }
}
