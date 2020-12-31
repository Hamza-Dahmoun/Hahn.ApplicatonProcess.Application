using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.December2020.Data
{
    public interface IEntity<TKey>
    {
        //This interface is created to be implemented by Entities (Models) in order to have more freedom in choosing 
        //the Id type
        TKey Id { get; set; }
    }
}
