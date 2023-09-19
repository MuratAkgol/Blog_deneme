using BussinessLayer.Abstract;
using DataLayer.GenericRepository;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BussinessLayer.Concrate
{
    public class BlogYazilariManager : IService<BlogYazilari>
    {
        GenericRepository<BlogYazilari> _yazi = new GenericRepository<BlogYazilari>();
        public void Add(BlogYazilari entity)
        {
            _yazi.Insert(entity);
        }

        public void Delete(BlogYazilari entity)
        {
            _yazi.Delete(entity);
        }

        public BlogYazilari GetById(int id)
        {
            return _yazi.Get(x => x.Id == id);
        }

        public List<BlogYazilari> List()
        {
            return _yazi.List();
        }

        public List<BlogYazilari> List(Expression<Func<BlogYazilari, bool>> filter)
        {
            return _yazi.List();
        }

        public void Update(BlogYazilari entity)
        {
            _yazi.Update(entity);
        }
    }
}
