using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Business.Exceptions
{
    public class DataNotUpdatedException : Exception
    {
        //We'll be using this exception whever changes to data aren't made to the db
        public DataNotUpdatedException(string message) : base(message)
        {
        }
    }
}
