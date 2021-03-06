﻿using ColonyManager.Domain.Models;
using FluentValidation;

namespace ColonyManager.Application.Validators
{
    public class AddConfigGenericItemDtoValidator : AbstractValidator<AddConfigGenericItemRequestDto>
    {
        public AddConfigGenericItemDtoValidator()
        {
            RuleFor(x => x.GroupId).NotNull();
            RuleFor(x => x.Code).NotNull();
        }
    }
}
