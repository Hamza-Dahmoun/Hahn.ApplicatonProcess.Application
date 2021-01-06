using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Business.Exceptions
{
    public class BusinessException:Exception
    {
        //We'll be using this exception whenever a business rule is not satisfied before doing changes to the db
        public BusinessException(string message):base(message)
        {

        }
    }
}
