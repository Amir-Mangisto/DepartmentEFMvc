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
    public class EmployeesController : ApiController
    {
        DepartmentContext DepartmentDB = new DepartmentContext();

        // GET: api/Employees
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(new { Mess = DepartmentDB.Employees.ToList() });
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

        // GET: api/Employees/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                Employees employee=await DepartmentDB.Employees.FindAsync(id);
                return Ok(employee);
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

        // POST: api/Employees
        public async Task<IHttpActionResult> Post([FromBody] Employees userEmp)
        {
            try
            {
                DepartmentDB.Employees.Add(userEmp);
                DepartmentDB.SaveChanges();
                return Ok(new {MESSAGE = "EMPLOYEE WAS ADDED"});
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

        // PUT: api/Employees/5
        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, [FromBody] Employees value)
        {
            try
            {
                Employees updateEmployee =await DepartmentDB.Employees.FindAsync(id);
                updateEmployee.FirstName = value.FirstName;
                updateEmployee.LastName = value.LastName;
                updateEmployee.Salary = value.Salary;
                updateEmployee.Seniority = value.Seniority;
                updateEmployee.Department = value.Department;
                await DepartmentDB.SaveChangesAsync();
                return Ok("USER HAS BEEN UPDATED");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // DELETE: api/Employees/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                Employees updateEmployee = await DepartmentDB.Employees.FindAsync(id);
                DepartmentDB.Employees.Remove(updateEmployee);
                await DepartmentDB.SaveChangesAsync();
                return Ok("USER HAS BEEN DELETED");
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
    }
}
