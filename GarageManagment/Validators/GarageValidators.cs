using FluentValidation;
using GarageManagment.Models;

namespace GarageManagment.Validators
{
    public class GarageValidators : AbstractValidator<Garage>
    {
        public GarageValidators() 
        {
            RuleFor(garage => garage.Location)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100)
                .MinimumLength(1);
        }

    }
}
