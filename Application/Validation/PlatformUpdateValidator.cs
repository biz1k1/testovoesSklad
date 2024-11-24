using Domain.Model.Models.Input;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validation
{
    public class PlatformUpdateValidator:AbstractValidator<UpdatePlatformInput>
    {
        public PlatformUpdateValidator()
        {
            RuleFor(x => x.WarehouseId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(x => x.PlatformId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.Cargo)
                .GreaterThan(0)
                .LessThan(100000);

        }
    }
}
