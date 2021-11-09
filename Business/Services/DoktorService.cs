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
    public class DoktorService : IDoktorService
    {
        private readonly DoktorRepositoryBase _doktorRepository;
        public DoktorService(DoktorRepositoryBase doktorRepository)
        {
            _doktorRepository = doktorRepository;
        }
        public Result Add(DoktorModel model)
        {
           
            try
            {
                if (_doktorRepository.GetEntityQuery().Any(d => d.DoktorTcNo.Trim() == model.DoktorTcNo.Trim()))
                {
                    return new ErrorResult("Tc No daha önce kullanılmış!");
                }
                var entity = new Doktor()
                {
                    DoktorAdi = model.DoktorAdi,
                    DoktorSoyadi = model.DoktorSoyadi,
                    DoktorTcNo = model.DoktorTcNo,

                };
                _doktorRepository.Add(entity);

                return new SuccesResult();
            }
            catch (Exception e)
            {

                return new ExceptionResult(e);
            }
        }

        public Result Delete(int id)
        {
            try
            {
                var doktor = _doktorRepository.GetEntityQuery(d => d.Id == id).SingleOrDefault();
                _doktorRepository.Delete(doktor);
                return new SuccesResult();
            }
            catch (Exception e)
            {

                return new ExceptionResult(e);
            }
           
        }

        public void Dispose()
        {
            _doktorRepository.Dispose();
        }

        public IQueryable<DoktorModel> GetQuery()
        {
            var query = _doktorRepository.GetEntityQuery().OrderBy(d => d.DoktorAdi).Select(d => new DoktorModel()
            {
                Id = d.Id,
                DoktorAdi = d.DoktorAdi,
                DoktorSoyadi = d.DoktorSoyadi,
                DoktorTcNo = d.DoktorTcNo
                
                
            });
            return query;
        }

        public Result Update(DoktorModel model)
        {
            try
            {
                //if (_doktorRepository.GetEntityQuery().Any(d => d.DoktorTcNo.Trim() == model.DoktorTcNo.Trim()))
                //{
                //    return new ErrorResult("Bu Tc No kullanılmaktadır!");
                //}
                var entity = _doktorRepository.GetEntityQuery(d => d.Id == model.Id).SingleOrDefault();
                entity.DoktorAdi = model.DoktorAdi.Trim();
                entity.DoktorSoyadi = model.DoktorSoyadi.Trim();
                entity.DoktorTcNo = model.DoktorTcNo.Trim();
                _doktorRepository.Update(entity);
                return new SuccesResult();
            }
            catch (Exception e)
            {

                return new ExceptionResult(e);
            }
          
        }
    }
}
