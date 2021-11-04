using Dapper;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Tarteeb.Time.Core.Data;
using Tarteeb.Time.Core.Model;

namespace Tarteeb.Time.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimesController : RESTFulController
    {
        private readonly IDbConnectionFactory factory;

        public TimesController(IDbConnectionFactory factory)
        {
            this.factory = factory;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            using (var connection = factory.GetConnection())
            {

                connection.Open();
                var data = await connection.GetListAsync<Model.Time>();
                connection.Close();
                return Ok(data.ToList());
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            using (var connection = factory.GetConnection())
            {

                connection.Open();
                var data = await connection.GetAsync<Model.Time>(id);
                connection.Close();
                if (data is null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] Model.Time time)
        {
            using (var connection = factory.GetConnection())
            {

                connection.Open();
                int? newId = await connection.InsertAsync(time);
                connection.Close();

                if (!newId.HasValue)
                {
                    return Problem("Unable to create time record.");
                }
                return Created(newId);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] Model.Time time)
        {
            using (var connection = factory.GetConnection())
            {
                connection.Open();
                int affectedRows = await connection.DeleteAsync(time);
                connection.Close();

                if (affectedRows == 0)
                {
                    return Problem("Unable to delete time record.");
                }
                return Ok(affectedRows);
            }
        }
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Model.Time time)
        {
            using (var connection = factory.GetConnection())
            {
                connection.Open();
                int affectedRows = await connection.UpdateAsync(time);
                connection.Close();

                if (affectedRows == 0)
                {
                    return Problem("Unable to update time record.");
                }
                return Ok(affectedRows);
            }
           
        }
    }
}
