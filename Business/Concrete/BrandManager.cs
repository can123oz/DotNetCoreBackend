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
    public class BrandManager : IBrandService
    {
        IBrandDal _context;
        public BrandManager(IBrandDal context)
        {
            _context = context;
        }

        public IResult AddBrand(Brand brand)
        {
            if (brand != null)
            {
                _context.Add(brand);
                return new SuccessResult(Message.SuccessMessage);
            }
            return new ErrorResult(Message.ErrorMessage);
        }

        public IResult DeleteBrand(int id)
        {
            if (id > 0)
            {
                _context.Delete(p=>p.Id == id);
                return new SuccessResult(Message.SuccessMessage);
            }
            return new ErrorResult(Message.ErrorMessage);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            var result = _context.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<Brand>>(result, Message.DataSuccessMessage);
            }
            return new ErrorDataResult<List<Brand>>(Message.DataErrorMessage);
        }

        public IDataResult<List<Brand>> GetById(int id)
        {
            var result = _context.GetAll(p=>p.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<List<Brand>>(result, Message.DataSuccessMessage);
            }
            return new ErrorDataResult<List<Brand>>(Message.DataErrorMessage);
        }
    }
}
