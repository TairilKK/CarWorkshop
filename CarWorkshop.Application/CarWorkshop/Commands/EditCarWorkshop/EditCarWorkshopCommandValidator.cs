using CarWorkshop.Application.CarWorkshop.Commands.UpdateCarWorkshop;
using CarWorkshop.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop
{
    public class EditCarWorkshopCommandValidator : AbstractValidator<EditCarWorkshopCommand>

    {
        public EditCarWorkshopCommandValidator(ICarWorkshopRepository repository)
        {
            RuleFor(e => e.Description)
                .NotEmpty();

            RuleFor(e => e.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);
        }
    }
}
