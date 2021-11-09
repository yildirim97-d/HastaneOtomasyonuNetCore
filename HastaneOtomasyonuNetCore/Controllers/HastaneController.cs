using AppCore.Business.Models.Results;
using Business.Models;
using Business.Services.Bases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HastaneOtomasyonuNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HastaneController : ControllerBase
    {
        private readonly IHastaneService _hastaneService;
        public HastaneController(IHastaneService hastaneService)
        {
            _hastaneService = hastaneService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var query = _hastaneService.GetQuery();
            var model = query.ToList();
            return Ok(model);
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(HastaneModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _hastaneService.Add(model);
                if (result.Status == ResultStatus.Succes)
                {
                    var query = _hastaneService.GetQuery();
                    var doktorModel = query.ToList();
                    return Ok(doktorModel);

                }
                if (result.Status == ResultStatus.Error)
                {

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
        public IActionResult Update(HastaneModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _hastaneService.Update(model);
                if (result.Status == ResultStatus.Succes)
                {
                    var query = _hastaneService.GetQuery();
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
            var deleteResult = _hastaneService.Delete(id);
            if (deleteResult.Status == ResultStatus.Succes)
            {
                var query = _hastaneService.GetQuery();
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
