using DataAccess.EntityFramework.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework.Repositories
{
    public class DoktorHastaneRepositories: DoktorHastaneRepositoryBase

    {
       public DoktorHastaneRepositories(DbContext db) : base(db)
        {

        }
    }
}
