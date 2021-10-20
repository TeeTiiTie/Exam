using Exam.Entity;
using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Service
{
    public interface ITmpAppRepository
    {
        IEnumerable<ShowTmp> GetAll();

        List<ShowTmp> GetById(int id);

        IEnumerable<ShowTmp> GetByName(string name);
    }
}