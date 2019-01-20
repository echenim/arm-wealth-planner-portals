using System;
using System.Linq;
using PortalAPI.Midleware.Contracts;
using PortalAPI.Domain;
using PortalAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace PortalAPI.Midleware.Implementations
{
    public class PersonService : IPersonService
    {
        private readonly ApplicationDbContext _context;

        public PersonService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Person Save(Person model)
        {
            _context.Add(model);
            model.Id = _context.SaveChanges();
            return model;
        }

        public Person Edit(Person model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return model;
        }

        public Person FindById(Func<Person, bool> predicate)
            => _context.Person.Find(predicate);

        public IQueryable<Person> Get(Func<Person, bool> predicate = null)
            => predicate != null ?
                _context.Person.Where(predicate: predicate).AsQueryable()
                : _context.Person.AsQueryable();

        public Person Delete(Person model)
        {
            _context.Entry(model).State = EntityState.Deleted;
            _context.SaveChanges();
            return model;
        }
    }
}