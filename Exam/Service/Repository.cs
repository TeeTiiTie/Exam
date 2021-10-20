using Exam.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Service
{
    public class Repository:IRepository
    {
        private List<Item> _items;

        public Repository()
        {
            _items = new List<Item>()
            {
                new Item(){Id = 1, Name = "Hello World"},
                new Item(){Id = 2, Name = "C#"},
                new Item(){Id = 3, Name = "Java"},
                new Item(){Id = 4, Name = "C++"}

            };
        }
        
        public List<Item> GetAllItem()
        {
            return _items;
        }

        public Item GetbyId(int Id)
        {
            return _items.FirstOrDefault(x => x.Id == Id);
        }
        public List<Item> GetbyName(string str) 
        {
            //var listItem = (from a in _items
            //                where a.Name.Contains(str)
            //                select a).ToList();
            //return listItem;
            return _items.Where(x => x.Name.Contains(str)).ToList();
        }

        public Item AddItem(string str)
        {

            _items.Add(new Item() { Id = _items.Max(x => x.Id) + 1, Name = str });

            return _items.OrderByDescending(x => x.Id).FirstOrDefault();

        }

        public Item UpdateItem(int id, ItemUpdate item)
        {
            var updateItem =_items.FirstOrDefault(x => x.Id == id);
            updateItem.Name = item.Name;

            return _items.Where(x => x.Id == updateItem.Id).FirstOrDefault();
        }

        public Item CheckName(string str)
        {
            return _items.Where(x => x.Name == str).FirstOrDefault();
        }
        
        public Item CheckId(int id)
        {
            return _items.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}

