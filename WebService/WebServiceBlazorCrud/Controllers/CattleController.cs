using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServiceBlazorCrud.Models.Response;
using WebServiceBlazorCrud.Models;
using WebServiceBlazorCrud.Models.Request;

namespace WebServiceBlazorCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CattleController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Response<List<Cattle>> oResponse = new Response<List<Cattle>>();

            try
            {
                using (blazorcrudContext db = new blazorcrudContext())
                {
                    var lst = db.Cattle.ToList();
                    oResponse.Success = 1;
                    oResponse.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
                throw;
            }

            return Ok(oResponse);
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            Response<Cattle> oResponse = new Response<Cattle>();

            try
            {
                using (blazorcrudContext db = new blazorcrudContext())
                {
                    var lst = db.Cattle.Find(Id);
                    oResponse.Success = 1;
                    oResponse.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
                throw;
            }

            return Ok(oResponse);
        }

        [HttpPost]
        public IActionResult Add(CattleRequest model)
        {
            Response<object> oResponse = new Response<object>();

            try
            {
                using (blazorcrudContext db = new blazorcrudContext())
                {
                    Cattle oCattle = new Cattle();
                    oCattle.Breed = model.Breed;
                    oCattle.Name = model.Name;

                    db.Cattle.Add(oCattle);
                    db.SaveChanges();
                    oResponse.Success = 1;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
                throw;
            }
            return Ok(oResponse);
        }
        [HttpPut]
        public IActionResult Edit(CattleRequest model)
        {
            Response<object> oResponse = new Response<object>();

            try
            {
                using (blazorcrudContext db = new blazorcrudContext())
                {
                    Cattle oCattle = db.Cattle.Find(model.Id);
                    oCattle.Breed = model.Breed;
                    oCattle.Name = model.Name;

                    db.Entry(oCattle).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oResponse.Success = 1;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
                throw;
            }
            return Ok(oResponse);
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Response<object> oResponse = new Response<object>();

            try
            {
                using (blazorcrudContext db = new blazorcrudContext())
                {
                    Cattle oCattle = db.Cattle.Find(Id);

                    db.Remove(oCattle);
                    db.SaveChanges();
                    oResponse.Success = 1;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
                throw;
            }
            return Ok(oResponse);
        }
    }
}
