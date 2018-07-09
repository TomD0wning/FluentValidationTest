using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;


namespace FluentValidationTest
{
    class StoreValidator : AbstractValidator<Store>
    {

        public StoreValidator(){
            RuleFor(store => store.StoreName).NotEmpty().Matches("(\\w\\d)").MaximumLength(10);
            RuleFor(store => store.StoreNumber).NotNull().GreaterThan(0).LessThan(9999);
            RuleFor(store => store.StoreType).LessThanOrEqualTo(4).GreaterThanOrEqualTo(0);
        }



    }
}
