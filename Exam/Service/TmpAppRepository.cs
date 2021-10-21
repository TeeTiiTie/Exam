using Exam.Entity;
using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Exam.Service.ResponseCodeBase;

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

        public Response Insert(Insert data)
        {
            var resp = new Response();
            var insert = new tmpApplication();
            var respCode = (int)ResponseCode.Successful;

            if(string.IsNullOrWhiteSpace(data.Name))
            {
                respCode = (int)ResponseCode.RequireFieldOrParametersIsNull;
                resp.respCode = respCode;
                resp.respMsg = GetResponseMessage(respCode);
                return resp;
            }
            
            var check = context.TmpApplications.Where(x => x.Name == data.Name).FirstOrDefault();
            if(check != null)
            {
                respCode = (int)ResponseCode.MethodNotAllowed;
                resp.respCode = respCode;
                resp.respMsg = GetResponseMessage(respCode);

                return resp;
            }

            insert.Name = data.Name;
            insert.CreatedDate = DateTime.Now;
            insert.UpdatedDate = DateTime.Now;
            insert.IsActive = true;

            context.Add(insert);
            context.SaveChanges();

            var qry = context.TmpApplications.OrderByDescending(x => x.Id).FirstOrDefault();

            resp.Id = qry.Id;
            resp.Name = qry.Name;
            resp.CreatedDate = qry.CreatedDate;
            resp.UpdatedDate = qry.UpdatedDate;
            resp.IsActive = qry.IsActive;
            resp.respCode = respCode;
            resp.respMsg= GetResponseMessage(respCode);

            return resp;
        }
    }
}