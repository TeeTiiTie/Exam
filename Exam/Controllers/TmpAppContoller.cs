using Exam.Entity;
using Exam.Models;
using Exam.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Controllers
{
    [Route("api/tmpAplication")]
    [ApiController]
    public class TmpAppContoller : ControllerBase
    {
        private readonly ExamByPMhingContext context;
        private readonly ITmpAppRepository repository;

        public TmpAppContoller(ExamByPMhingContext context, ITmpAppRepository repository)
        {
            this.context = context;
            this.repository = repository;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<ShowTmp>> GetAll()
        {
            return Ok(repository.GetAll());
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<ShowTmp> GetById(int id)
        {
            return Ok(repository.GetById(id));
        }

        [HttpGet("GetByName/{name}")]
        public ActionResult<ShowTmp> GetByName(string name)
        {
            return Ok(repository.GetByName(name));
        }
    }
}