using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult AddColor(Color color)
        {
            //ValidationTool.Validate(new ColorValidator(), color);

            _colorDal.Add(color);
            return new SuccessResult(Message.SuccessMessage);
        }

        public IResult DeleteColor(int id)
        {
            if (id > 0)
            {
                _colorDal.Delete(p => p.Id == id);
                return new SuccessResult(Message.SuccessMessage);
            }
            return new ErrorResult(Message.ErrorMessage);
        }

        public IDataResult<List<Color>> GetAll()
        {
            var result = _colorDal.GetAll();
            return new DataResult<List<Color>>(result, true);
        }

        public IDataResult<Color> GetById(int id)
        {
            var result = _colorDal.Get(p => p.Id == id);
            if (result.Name.Length > 0)
            {
                return new DataResult<Color>(result, true);
            }
            return new ErrorDataResult<Color>(Message.DataErrorMessage);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult UpdateColor(Color color)
        {
            var oldColor = _colorDal.Get(p => p.Id == color.Id);
            if (oldColor != null)
            {
                _colorDal.Update(color);
                return new SuccessDataResult<Color>(color, Message.SuccessUpdate);
            }
            return new ErrorDataResult<Color>("Brand Cant Find");
        }
    }
}
