using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("This is not a Validation Class this is just for type of validation rules");
            }

            _validatorType = validatorType;
        }

        //invocation means method.
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //this is the use of Reflection, example on run time newing a validator class.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //get the basetype of the validator class and gets the parameters type of it. 
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //gets the parameters of the method enters here and use foreach parameter with its own validation rules.
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
