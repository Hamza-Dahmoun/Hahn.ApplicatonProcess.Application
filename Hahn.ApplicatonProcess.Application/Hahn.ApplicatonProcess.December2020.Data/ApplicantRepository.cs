using Hahn.ApplicatonProcess.December2020.DataAbstraction;
using Hahn.ApplicatonProcess.December2020.Domain.Models;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Data
{
    public class ApplicantRepository : IRepository<Applicant, int>
    {
        protected readonly ApplicationDBContext _dbContext;
        protected readonly DbSet<Applicant> _dbSet;

        public ApplicantRepository(ApplicationDBContext dbContext)
        {
            //injecting dbContext & dbSet services
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Applicant>();
        }

        public int Add(Applicant entity)
        {
            try
            {
                _dbContext.Add(entity);
                return _dbContext.SaveChanges();
            }
            catch(Exception E)
            {
                throw E;
            }
        }

        public int Count()
        {
            try
            {
                int count = 0;
                count = _dbSet.AsNoTracking().Count();
                return count;
            }
            catch(Exception E)
            {
                throw E;
            }            
        }

        public int Count(Expression<Func<Applicant, bool>> predicate)
        {            
            try
            {
                return _dbSet.Count(predicate);
            }
            catch(Exception E)
            {
                throw E;
            }
        }

        public int Delete(Applicant entity)
        {
            try
            {
                _dbContext.Remove(entity);
                return _dbContext.SaveChanges();
            }
            catch (Exception E)
            {
                throw E;
            }
        }

        public List<Applicant> GetAll()
        {
            try
            {
                var applicants = _dbSet.ToList();
                return applicants;
            }
            catch(Exception E)
            {
                throw E;
            }
        }

        public List<Applicant> GetAllFiltered(Expression<Func<Applicant, bool>> prediacte)
        {
            try
            {
                return _dbSet.Where(prediacte).ToList();
            }
            catch (Exception E)
            {
                throw E;
            }
        }

        public Applicant GetById(int Id)
        {
            try
            {
                return _dbSet.Where(a => a.ID == Id).SingleOrDefault();
            }
            catch(Exception E)
            {
                throw E;
            }
        }

        public Applicant GetSingle(Expression<Func<Applicant, bool>> predicate)
        {
            try
            {
                return _dbSet.Where(predicate).SingleOrDefault();
            }
            catch (Exception E)
            {
                throw E;
            }
        }

        public int Update(Applicant entity)
        {
            try
            {
                var myEntity = GetById(entity.ID);
                myEntity.Name = entity.Name;
                myEntity.Address = entity.Address;
                myEntity.Age = entity.Age;
                myEntity.CountryOfOrigin = entity.CountryOfOrigin;
                myEntity.EmailAddress = entity.EmailAddress;
                myEntity.FamilyName = entity.FamilyName;
                myEntity.Hired = entity.Hired;
                return _dbContext.SaveChanges();
            }
            catch (Exception E)
            {
                throw E;
            }
        }
    }
}
