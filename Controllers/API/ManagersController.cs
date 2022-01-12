using DepartmentEFMvc.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DepartmentEFMvc.Controllers.API
{
    public class ManagersController : ApiController
    {
        DepartmentContext db = new DepartmentContext();
        // GET: api/Managers
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(db.managers.ToList());
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // GET: api/Managers/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {

                Managers manger = await db.managers.FindAsync(id);
                return Ok(manger);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }

        }

        // POST: api/Managers
        public async Task<IHttpActionResult> Post([FromBody] Managers userManager)
        {
            try
            {
                db.managers.Add(userManager);
                db.SaveChanges();
                return Ok("MANAGER WAS ADDED");
            }
            catch(SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // PUT: api/Managers/5
        public async Task<IHttpActionResult> Put(int id, [FromBody] Managers value)
        {
            try
            {
                Managers managers = await db.managers.FindAsync(id);
                managers.FirstName = value.FirstName;
                managers.LastName = value.LastName;
                managers.Salary = value.Salary;
                managers.AmountOfEmployees = value.AmountOfEmployees;
                managers.Department = value.Department;
                await db.SaveChangesAsync();

                return Ok("MANAGER WAS UPDATED");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Managers/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                Managers managers = await db.managers.FindAsync(id);
                db.managers.Remove(managers);
                await db.SaveChangesAsync();
                return Ok("MANAGER WAS DELETED");
            }
            catch (SqlException ex)
            {
                return BadRequest();
            }
            catch(Exception err)
            {
                return BadRequest(err.Message);
            }
        }   
    }
}
