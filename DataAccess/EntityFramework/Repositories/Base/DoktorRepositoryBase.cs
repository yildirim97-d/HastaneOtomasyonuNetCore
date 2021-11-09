using AppCore.DataAccess.EntityFramework.Bases;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework.Repositories.Base
{
    public abstract class DoktorRepositoryBase : RepositoryBase<Doktor>
    {
        protected DoktorRepositoryBase(DbContext db) : base(db)
        {

        }
    }
}
