using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _context;

        public ColorManager(IColorDal context)
        {
            _context = context;
        }

        public IResult AddColor(Color color)
        {
            if (color.Name != null)
            {
                _context.Add(color);
                return new SuccessResult(Message.SuccessMessage);
            }
            return new ErrorResult(Message.ErrorMessage);
        }

        public IResult DeleteColor(int id)
        {
            if (id > 0)
            {
                _context.Delete(p => p.Id == id);
                return new SuccessResult(Message.SuccessMessage);
            }
            return new ErrorResult(Message.ErrorMessage);
        }

        public IDataResult<List<Color>> GetAll()
        {
            var result = _context.GetAll();
            return new DataResult<List<Color>>(result, true);
        }

        public IDataResult<List<Color>> GetById(int id)
        {
            var result = _context.GetAll(p=>p.Id == id);
            return new DataResult<List<Color>>(result,true);
        }
    }
}
