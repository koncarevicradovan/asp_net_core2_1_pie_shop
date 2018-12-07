using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Debts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Debts.WebAPI
{
    /// <summary>
    /// Creates a TodoItem.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Todo
    ///     {
    ///        "id": 1,
    ///        "name": "Item1",
    ///        "isComplete": true
    ///     }
    ///
    /// </remarks>
    /// <param name="item"></param>
    /// <returns>A newly created TodoItem</returns>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>  
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PieController : ControllerBase
    {

        private IPieRepository _pieRepository;

        public PieController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        [HttpGet, Route("")]
        public IActionResult Get()
        {
            IEnumerable<Pie> pies = _pieRepository.GetAllPies().OrderBy(x => x.Name).ToList();
            return Ok(pies);
        }

        [HttpGet, Route("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_pieRepository.GetPieById(id));
        }

        [HttpPost, Route("add")]
        public IActionResult AddAsync([FromBody] Pie pie)
        {
            var pieId = _pieRepository.Insert(pie);
            return Ok(pieId);
        }

        [HttpPost, Route("update")]
        public IActionResult Update([FromBody] Pie pie)
        {
            _pieRepository.Update(pie);
            return Ok();
        }

        [HttpPost, Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            var pieId = _pieRepository.Delete(pie);
            return Ok(pieId);
        }
    }
}
