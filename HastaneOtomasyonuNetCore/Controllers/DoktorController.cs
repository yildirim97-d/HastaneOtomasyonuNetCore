using AppCore.Business.Models.Results;
using Business.Models;
using Business.Services.Bases;
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
    public class DoktorController : ControllerBase
    {
        private readonly IDoktorService _doktorService;
        public DoktorController(IDoktorService doktorService)
        {
            _doktorService = doktorService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var query = _doktorService.GetQuery();
            var model = query.ToList();
            return Ok(model);
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(DoktorModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _doktorService.Add(model);
                if (result.Status == ResultStatus.Succes)
                {
                    var query = _doktorService.GetQuery();
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
        public IActionResult Update(DoktorModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _doktorService.Update(model);
                if (result.Status == ResultStatus.Succes)
                {
                    var query = _doktorService.GetQuery();
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
            var deleteResult = _doktorService.Delete(id);
            if (deleteResult.Status == ResultStatus.Succes)
            {
                var query = _doktorService.GetQuery();
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