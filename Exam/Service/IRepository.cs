using Exam.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Service
{
    public interface IRepository
    {
        Item AddItem(string str);
        Item CheckId(int id);
        Item CheckName(string str);
        List<Item> GetAllItem();
        Item GetbyId(int Id);
        List<Item> GetbyName(string str);
        Item UpdateItem(int id, ItemUpdate item);
    }
}
