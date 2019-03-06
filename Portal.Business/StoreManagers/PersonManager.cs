using System;
using System.Linq;
using Portal.Business.Contracts;
using Portal.Domain;
using Portal.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Portal.Business.Utilities;

namespace Portal.Business.StoreManagers
{
    public class PersonManager : IPersonManager
    {
        private readonly ApplicationDbContext _context;

        public PersonManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public NotificationResult<Person> Save(Person model)
        {
            var notification = new NotificationResult<Person>();

            try
            {
                model.OnCreated = DateTime.Now.ToUniversalTime();
                var modelObj = _context.Person.Add(model).Entity;
                _context.SaveChanges();

                notification.Succeed = true;
                notification.TObj = modelObj;
            }
            catch (Exception ex)
            {
                notification.Succeed = false;
                notification.TObj = null;
            }

            return notification;
        }

        public NotificationResult<Person> Edit(Person model)
        {
            var notification = new NotificationResult<Person>();

            try
            {
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();

                notification.Succeed = true;
                notification.TObj = model;
            }
            catch (Exception ex)
            {
                notification.Succeed = false;
                notification.TObj = null;
            }

            return notification;
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