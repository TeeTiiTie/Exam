using Exam.Entity;
using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Service
{
    public class TmpAppRepository : ITmpAppRepository
    {
        private readonly ExamByPMhingContext context;

        public TmpAppRepository(ExamByPMhingContext context)
        {
            this.context = context;
        }

        public IEnumerable<ShowTmp> GetAll()
        {
            var data = context.TmpApplications.Where(x => x.IsActive == true).Select(x => new ShowTmp()
            {
                Id = x.Id,
                Name = x.Name,
                CreatedDate = (DateTime)x.CreatedDate,
                UpdatedDate = (DateTime)x.UpdatedDate
            }).ToList();

            return data;
        }

        public List<ShowTmp> GetById(int id)
        {
            var data = context.TmpApplications.Where(x => x.Id == id).Select(x => new ShowTmp()
            {
                Id = x.Id,
                Name = x.Name,
                CreatedDate = (DateTime)x.CreatedDate,
                UpdatedDate = (DateTime)x.UpdatedDate
            }).ToList();

            return data;
        }

        public IEnumerable<ShowTmp> GetByName(string name)
        {
            var data = context.TmpApplications.Where(x => x.Name.Contains(name)).Select(x => new ShowTmp()
            {
                Id = x.Id,
                Name = x.Name,
                CreatedDate = (DateTime)x.CreatedDate,
                UpdatedDate = (DateTime)x.UpdatedDate
            });

            return data;
        }
    }
}