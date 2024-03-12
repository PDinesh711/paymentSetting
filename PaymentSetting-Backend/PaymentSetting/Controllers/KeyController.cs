using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentSetting.Database;
using PaymentSetting.Models;

namespace PaymentSetting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyController : ControllerBase
    {
        public readonly DatabaseDbContext dbcontext;
        public KeyController(DatabaseDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpPost("save")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Key>> create([FromBody] Key key)
        {
            dbcontext.Keys.Add(key);
            dbcontext.SaveChanges();   
            return Ok(" Successfully Added !");
        }

    }
}

