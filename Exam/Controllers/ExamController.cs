using Exam.Entity;
using Exam.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IRepository repository;
        private readonly ILogger<ExamController> logger;
        private readonly Item _item;

        public ExamController(IRepository repository, ILogger<ExamController> logger)
        {
            this.repository = repository;
            this.logger = logger;
    
        }

        [HttpGet("get1")]
        public List<Item> Get()
        {
            return repository.GetAllItem();
        }

        [HttpGet("getbyId/{id}")]
        public Item Get(int id)
        {
            var item = repository.GetbyId(id);

            return item;
        }

        [HttpGet("getbyPara")]
        public ActionResult<List<Item>> GetbyPara(string str)
        {
            var item = repository.GetbyName(str);
            var countItem = item.Count();

            if (countItem == 0)
            {
                return NotFound();
            }

            return item;
            
        }

        [HttpPost]
        public ActionResult Insert(string str)
        {
            var checkItem = repository.CheckName(str);
            
            if(checkItem != null)
            {
                return NotFound("Item have in List");
            }

            var item = repository.AddItem(str);

            return Ok(item);
        }
        
        [HttpPut("{id}")]
        public ActionResult<Item> Update(int id, ItemUpdate item)
        {
            
            var checkId = repository.CheckId(id);

            if(checkId == null)
            {
                return NotFound("Item not found");
            }

            var updateItem = repository.UpdateItem(id, item);
            return Ok(updateItem);
        }
    }
}
