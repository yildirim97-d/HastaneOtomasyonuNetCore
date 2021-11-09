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
    public class HastaneService : IHastaneService
    {
        private readonly HastaneRepositoryBase _hastaneRepository;
        public HastaneService(HastaneRepositoryBase hastaneRepository)
        {
            _hastaneRepository = hastaneRepository;
        }
        public Result Add(HastaneModel model)
        {
            try
            {
                if (_hastaneRepository.GetEntityQuery().Any(d => d.HastaneAdi.Trim() == model.HastaneAdi.Trim()))
                {
                    return new ErrorResult("Bu hastane daha önce kayıt edilmiş!");
                }
                var entity = new Hastane()
                {
                    HastaneAdi = model.HastaneAdi,
                    HastaneAdres = model.HastaneAdres


                };
                _hastaneRepository.Add(entity);

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
                var hastane = _hastaneRepository.GetEntityQuery(d => d.Id == id).SingleOrDefault();
                _hastaneRepository.Delete(hastane);
                return new SuccesResult();
            }
            catch (Exception e)
            {

                return new ExceptionResult(e);
            }
        }

        public void Dispose()
        {
            _hastaneRepository.Dispose();
        }

        public IQueryable<HastaneModel> GetQuery()
        {
            var query = _hastaneRepository.GetEntityQuery().OrderBy(d => d.HastaneAdi).Select(d => new HastaneModel()
            {
                Id = d.Id,
                HastaneAdi = d.HastaneAdi,
                HastaneAdres = d.HastaneAdres

            });
            return query;
        }

        public Result Update(HastaneModel model)
        {
            try
            {
                //if (_doktorRepository.GetEntityQuery().Any(d => d.DoktorTcNo.Trim() == model.DoktorTcNo.Trim()))
                //{
                //    return new ErrorResult("Bu Tc No kullanılmaktadır!");
                //}
                var entity = _hastaneRepository.GetEntityQuery(d => d.Id == model.Id).SingleOrDefault();
                entity.HastaneAdi = model.HastaneAdi.Trim();
                entity.HastaneAdres = model.HastaneAdres.Trim();
                _hastaneRepository.Update(entity);
                return new SuccesResult();
            }
            catch (Exception e)
            {

                return new ExceptionResult(e);
            }
        }
    }
}
