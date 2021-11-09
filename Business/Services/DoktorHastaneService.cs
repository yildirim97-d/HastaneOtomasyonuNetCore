using AppCore.Business.Models.Results;
using Business.Models;
using Business.Services.Bases;
using DataAccess.EntityFramework.Repositories.Base;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Services
{
    public class DoktorHastaneService : IDoktorHastaneService
    {
        private readonly DoktorHastaneRepositoryBase _doktorHastaneRepository;
        public DoktorHastaneService(DoktorHastaneRepositoryBase doktorHastaneRepository)
        {
            _doktorHastaneRepository = doktorHastaneRepository;
        }
        public Result Add(DoktorHastaneModel model)
        {
            throw new NotImplementedException();
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _doktorHastaneRepository.Dispose();
        }

        public IQueryable<DoktorHastaneModel> GetQuery()
        {
            try
            {
                var query = _doktorHastaneRepository.GetEntityQuery().OrderBy(dh => dh.Hastane.HastaneAdi).Select(dh => new DoktorHastaneModel()
                {
                    DoktorId = dh.DoktorId,
                    HastaneId = dh.HastaneId,
                });
                return query;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Result Update(DoktorHastaneModel model)
        {
            throw new NotImplementedException();
        }
    }
}
