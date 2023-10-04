using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Imventory_API.Models.Requests;
using Microsoft.AspNetCore.Authorization;
//using Imventory_API.Models.DBMapping;

namespace Imventory_API.Controllers
{
    [Route("api/items")]
    [ApiController]
    [Authorize]
    public class ItemController : ControllerBase
    {
        private readonly Models.DatabaseMappings.inventory_schemaContext _context;
        private readonly ILogger<ItemController> _logger;
        public ItemController(
          ILogger<ItemController> logger,
         Models.DatabaseMappings.inventory_schemaContext context
        )
            {
                _logger = logger;
                _context = context;

            }
        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Items" })]
        public IActionResult GetItem()
        {
            var itemsList = _context.U01Items.Where(x=>x.Status==1).ToList();
            return Ok(itemsList);
           
        }

        [HttpPost]
        public IActionResult AddItem(
        [FromBody] ItemAdd itemadd
        )
        {
            var transaction = _context.Database.BeginTransaction();
            var AddItem = new Models.DatabaseMappings.U01Item
            {
                Uuid = Guid.NewGuid().ToString(),
                Name = itemadd.name,
                Quantity = itemadd.quantity,
                Amount = itemadd.amount,
                Status = 1,
                AddedOn = DateTime.UtcNow,
                Category = itemadd.category,
            };

            _context.Add(AddItem);
            try
            {
                _context.SaveChanges();
                transaction.Commit();
                return Ok(itemadd);
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, new Models.Respons.Generic<Dictionary<string, string>>
                {
                    success = false,
                    error = "Error in saving Items" + e.Message,
                    data = new Dictionary<string, string>(),
                });
            }

        }

        [HttpGet]
        [Route("{id:}")]
        public IActionResult ViewProduct([FromRoute] int id)
        {
            var item=_context.U01Items.FirstOrDefault(x => x.Id == id); 
            if (item == null)
            {
                    return NotFound();
            }
            return Ok(item);
        }

        [HttpPut]
        [Route("{id:}")]
        public IActionResult UpdateItem(
        [FromRoute] int id, 
        ItemAdd updateItem
        )
        {
            var transaction = _context.Database.BeginTransaction();
            var itemupdate=_context.U01Items.Find(id);
            if (itemupdate == null)
            {
                return NotFound();
            }
            itemupdate.Name=updateItem.name.ToLower();
            itemupdate.Amount = updateItem.amount;
            itemupdate.Quantity = updateItem.quantity;
            itemupdate.Category = updateItem.category.ToLower();
            itemupdate.UpdatedOn = DateTime.UtcNow;
            try
            {
                _context.SaveChanges();
                transaction.Commit();
                return Ok(updateItem);
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, new Models.Respons.Generic<Dictionary<string, string>>
                {
                    success = false,
                    error = "Error in Update Items" + e.Message,
                    data = new Dictionary<string, string>(),
                });
            }
        }
        [HttpDelete]
        [Route(("{id:}"))]
        public IActionResult DeleteItem(
         [FromRoute] int id
         )
        {
            var transaction = _context.Database.BeginTransaction();
            
            Models.DatabaseMappings.U01Item item;
            try
            {
                item = _context.U01Items.Find(id);
            }
            catch (Exception _)
            {
                return new NotFoundObjectResult(new Models.Respons.Generic<Dictionary<string, string>>
                {
                    success = false,
                    error = "Not Found",
                    data = new Dictionary<string, string>()
                });
            }
            if (item.Status == 1)
            {
                item.Status = 0;
            }
            _context.Update(item);
            _context.SaveChanges();
            transaction.Commit();
            return Ok(new Models.Respons.Generic<Dictionary<string, string>>
            {
                success = true,
                error = "",
                data = new Dictionary<string, string>()
            });
        }
    }
}
