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
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<Applicant, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Delete(Applicant entity)
        {
            throw new NotImplementedException();
        }

        public List<Applicant> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Applicant> GetAllFiltered(Expression<Func<Applicant, bool>> prediacte)
        {
            throw new NotImplementedException();
        }

        public Applicant GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Applicant GetSingle(Expression<Func<Applicant, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Update(Applicant entity)
        {
            throw new NotImplementedException();
        }
    }
}
