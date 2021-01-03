using Hahn.ApplicatonProcess.December2020.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class ApplicationDBContext:DbContext
    {
        public DbSet<Applicant> Applicant { get; set; }
    }
}
