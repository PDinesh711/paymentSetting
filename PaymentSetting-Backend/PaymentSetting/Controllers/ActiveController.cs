using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentSetting.Database;
using PaymentSetting.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PaymentSetting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActiveController : ControllerBase
    {
        public readonly DatabaseDbContext dbcontext;
        public ActiveController(DatabaseDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpPost("save")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Active>> create([FromBody] Active active)
        {
            dbcontext.Actives.Add(active);
            dbcontext.SaveChanges();
            return Ok(" Successfully Added !");
        }
    }
}
