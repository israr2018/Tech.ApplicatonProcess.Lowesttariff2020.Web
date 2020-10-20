using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tech.ApplicatonProcess.Lowesttariff2020.Web.Dto;
using Tech.ApplicatonProcess.Lowesttariff2020.Web.Model;
using Tech.ApplicatonProcess.Lowesttariff2020.Web.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Cors;

namespace Tech.ApplicatonProcess.Lowesttariff2020.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ApplicationController : ControllerBase
    {

       

        private  IApplicationRepo _repo;

        public ApplicationController(IApplicationRepo repo)
        {
            this._repo = repo;
        }

        
       // GET api/application
        [HttpGet]
        public ActionResult<IEnumerable<Application>> Get()
        {
            try
            {
                var list = this._repo.GetAllApplications();

                return Ok(list);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        // GET api/application/5
        [HttpGet("{id}",Name ="GetByID")]
        public ActionResult<Application> GetByID(int id)
        {
            
            try
            {
                
               Application retrieved= this._repo.GetApplicationByID(id);
                if (retrieved != null)
                    return Ok(retrieved);
                else
                    return NotFound();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/application
        [HttpPost]
        public ActionResult Post([FromBody] ApplicationDto applicationDto)
        {
            if (ModelState.IsValid)
            {
                Application application = new Application()
                {
                    Name = applicationDto.Name,
                    FamilyName = applicationDto.FamilyName,
                    Address = applicationDto.Address,
                    CountryOfOrigin = applicationDto.CountryOfOrigin,
                    EmailAddress = applicationDto.EmailAddress,
                    Age = applicationDto.Age,
                    Hired = applicationDto.Hired

                };
                try
                {
                    Application createdApplication = this._repo.AddApplication(application);
                    return CreatedAtRoute(nameof(GetByID), new { id = createdApplication.ID }, createdApplication);
                    //return Ok(result);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }




            }
            else
            {
                return BadRequest(ModelState);
            }




        }

        // PUT api/application/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Application toUpdate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   return Ok( this._repo.UpdateApplicationID(id, toUpdate));
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        // DELETE api/application/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
              return Ok(  this._repo.DeleteApplicationByID(id));
            }
            catch(Exception ex)
            {
                return Ok("Internal Server Error");
            }
        }
    }
}