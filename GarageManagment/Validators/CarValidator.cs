using FluentValidation;
using GarageManagment.Models;
namespace GarageManagment.Validators


{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()

        {
            RuleFor(car => car.Brand)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50)
                .MinimumLength(2);

            RuleFor(car => car.Model)
                .NotEmpty().WithMessage("Model is required")
                .NotNull()
                .MaximumLength(100)
                .MinimumLength(1);
            RuleFor(car => car.HorsePower)
                .GreaterThan(20)
                .NotEmpty();
            RuleFor(car => car.YearOfProduction)
                .NotEmpty()
                .GreaterThan(1960).WithMessage("Year must be greater than 1960");
            
                
               
                
        }
    }
}
