using Domain.Model.Models.Output.Picket;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validation
{
    public class PicketMergeValidator:AbstractValidator<MergePicketOutput>
    {
        public PicketMergeValidator()
        {
            RuleFor(x => x.WarehouseId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.picketIds)
                .NotEmpty()
                .NotNull();
        }
    }
}
