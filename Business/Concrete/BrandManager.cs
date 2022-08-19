using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
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
            ValidationTool.Validate(new BrandValidator(), brand);
            _context.Add(brand);
            return new SuccessResult(Message.SuccessMessage);
            //return new ErrorResult(Message.ErrorMessage);
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

        public IDataResult<Brand> GetById(int id)
        {
            var result = _context.Get(p=>p.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<Brand>(result, Message.DataSuccessMessage);
            }
            return new ErrorDataResult<Brand>(Message.DataErrorMessage);
        }
    }
}
