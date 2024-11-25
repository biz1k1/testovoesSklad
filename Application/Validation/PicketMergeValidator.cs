using Domain.Model.Models.Output.Picket;
using FluentValidation;
using System;
using System.Linq;

namespace Application.Validation
{
    public class PicketMergeValidator : AbstractValidator<MergePicketOutput>
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
