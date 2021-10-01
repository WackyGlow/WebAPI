using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.Filtering;
using PetShop.Core.IServices;
using PetShop.Core.Models;

namespace PetShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceService _insuranceService;

        public InsuranceController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }
        
        [HttpGet("{id}")]
        public ActionResult<Insurance> GetById(int id)
        {
            try
            {
                return Ok(_insuranceService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, "You fucked up son");
            }
        }

        [HttpPost]
        public ActionResult<Insurance> Create([FromBody] Insurance insurance)
        {
            try
            {
                return Ok(_insuranceService.CreateInsurance(insurance));
            }
            catch (Exception e)
            {
                return StatusCode(500, "You fucked up son");
            }
        }

        [HttpGet]
        public ActionResult<List<Insurance>> ReadAllInsurance([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_insuranceService.ReadAll(filter));
            }
            catch (Exception e)
            {
                return StatusCode(500, "You fucked up son");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteInsurance(int id)
        {
            try
            {
                return Ok(_insuranceService.DeleteInsuranceById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, "You Fucked up Son");
            }
        }
        
        [HttpPut("{id}")]

        public ActionResult<Insurance> PutInsurance(int id, [FromBody] Insurance insurance)
        {
            try
            {
                if (id != insurance.Id)
                {
                    return BadRequest("ID must match param id");
                }

                return Ok(_insuranceService.PutInsurance(insurance));
            }
            catch (Exception e)
            {
                return StatusCode(500, "You Fucked up Son");
            }
        }

    }
}