using AppCore.Business.Models.Results;
using Business.Models;
using Business.Services.Bases;
using DataAccess.EntityFramework.Repositories.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneOtomasyonuNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoktorHastaneController : ControllerBase
    {
        

        private readonly IDoktorHastaneService _doktorHastaneService;
        public DoktorHastaneController(IDoktorHastaneService doktorHastaneService)
        {
            _doktorHastaneService = doktorHastaneService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var query = _doktorHastaneService.GetQuery();
            var model = query.ToList();
            return Ok(model);
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(DoktorHastaneModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _doktorHastaneService.Add(model);
                if (result.Status == ResultStatus.Succes)
                {
                    var query = _doktorHastaneService.GetQuery();
                    var doktorModel = query.ToList();
                    return Ok(doktorModel);

                }
                if (result.Status == ResultStatus.Error)
                {

                    ModelState.AddModelError("", result.message);

                }
                else
                {
                    throw new Exception(result.message);

                }
            }
            return Ok();


        }

        [Route("Update")]
        [HttpPost]
        public IActionResult Update(DoktorHastaneModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _doktorHastaneService.Update(model);
                if (result.Status == ResultStatus.Succes)
                {
                    var query = _doktorHastaneService.GetQuery();
                    var doktorModel = query.ToList();
                    return Ok(doktorModel);
                }

                if (result.Status == ResultStatus.Error)
                {
                    ModelState.AddModelError("", result.message);
                    return Ok();
                }
                throw new Exception(result.message);

            }
            return Ok();


        }
        [Route("Delete")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deleteResult = _doktorHastaneService.Delete(id);
            if (deleteResult.Status == ResultStatus.Succes)
            {
                var query = _doktorHastaneService.GetQuery();
                var doktorModel = query.ToList();
                return Ok(doktorModel);
            }
            if (deleteResult.Status == ResultStatus.Error)
            {
                ModelState.AddModelError("", deleteResult.message);
            }
            return Ok();


        }
    }
}
