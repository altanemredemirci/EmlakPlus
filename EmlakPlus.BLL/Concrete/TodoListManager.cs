using EmlakPlus.BLL.Abstract;
using EmlakPlus.DAL.Abstract;
using EmlakPlus.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.BLL.Concrete
{
    public class TodoListManager : ITodoListService
    {
        private readonly ITodoListDal _todoListDal;

        public TodoListManager(ITodoListDal todoListDal)
        {
            _todoListDal = todoListDal;
        }

        public void Create(ToDoList entity)
        {
            _todoListDal.Create(entity);
        }

        public void Delete(ToDoList entity)
        {
            _todoListDal.Delete(entity);
        }

        public List<ToDoList> GetAll(Expression<Func<ToDoList, bool>> filter = null)
        {
            return _todoListDal.GetAll(filter);
        }

        public ToDoList GetById(int id)
        {
            return _todoListDal.GetById(id);
        }

        public ToDoList GetOne(Expression<Func<ToDoList, bool>> filter = null)
        {
            return _todoListDal.GetOne(filter);
        }

        public void Update(ToDoList entity)
        {
            _todoListDal.Update(entity);
        }
    }
}
