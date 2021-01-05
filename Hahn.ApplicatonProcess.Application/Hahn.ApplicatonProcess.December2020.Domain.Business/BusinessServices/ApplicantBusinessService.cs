﻿using Hahn.ApplicatonProcess.December2020.Data;
using Hahn.ApplicatonProcess.December2020.DataAbstraction;
using Hahn.ApplicatonProcess.December2020.Domain.Business.Exceptions;
using Hahn.ApplicatonProcess.December2020.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Business.BusinessServices
{
    public class ApplicantBusinessService
    {
        //protected readonly ApplicantRepository _applicantRepository;
        protected readonly IRepository<Applicant, int> _applicantRepository;
        public ApplicantBusinessService(IRepository<Applicant, int> applicantRepository)
        {
            //injecting repository service
            _applicantRepository = applicantRepository;
        }


        public int Add(Applicant entity)
        {
            try
            {
                int result = _applicantRepository.Add(entity);
                if (result == 0)
                {
                    throw new DataNotUpdatedException("Create operation failed!");
                }
                return result;
            }
            catch (DataNotUpdatedException E)
            {
                throw E;
            }
            catch (Exception E)
            {
                throw E;
            }
        }

        public int Count()
        {
            try
            {
                return _applicantRepository.Count();
            }
            catch (Exception E)
            {
                throw E;
            }
        }

        public int Count(Expression<Func<Applicant, bool>> predicate)
        {
            try
            {
                return _applicantRepository.Count(predicate);
            }
            catch (Exception E)
            {
                throw E;
            }
        }

        public int Delete(Applicant entity)
        {
            try
            {
                int result = _applicantRepository.Delete(entity);
                if (result == 0)
                {
                    throw new DataNotUpdatedException("Delete operation failed!");
                }
                return result;
            }
            catch (DataNotUpdatedException E)
            {
                throw E;
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
                return _applicantRepository.GetAll();
            }
            catch (Exception E)
            {
                throw E;
            }
        }

        public List<Applicant> GetAllFiltered(Expression<Func<Applicant, bool>> predicate)
        {
            try
            {
                return _applicantRepository.GetAllFiltered(predicate);
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
                return _applicantRepository.GetById(Id);
            }
            catch (Exception E)
            {
                throw E;
            }
        }

        public Applicant GetSingle(Expression<Func<Applicant, bool>> predicate)
        {
            try
            {
                return _applicantRepository.GetSingle(predicate);
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
                int result = _applicantRepository.Update(entity);
                if (result == 0)
                {
                    throw new DataNotUpdatedException("Update operation failed!");
                }
                return result;
            }
            catch (DataNotUpdatedException E)
            {
                throw E;
            }
            catch (Exception E)
            {
                throw E;
            }
        }
    }
}
