//####################################################################
// Project:         10Pearls
// Author:          Jonathan Dávila A.
// DATA:            08/10/2019
// Comment:         Class Client validator with fluent validations
//####################################################################
namespace InfoClient.DT.Utilities.FluentValidators
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FluentValidation;
    using InfoClient.DT.Client;

    public class DTClientValidator: AbstractValidator<DTClient>
    {
        public DTClientValidator() {
            RuleFor(DTClient => DTClient.Nit).NotEmpty().WithMessage("Nit is requeired");
            RuleFor(DTClient => DTClient.Nit).NotNull().WithMessage("Nit is requeired");
            RuleFor(DTClient => DTClient.FullName).NotEmpty().WithMessage("Full Name is requeired");
            RuleFor(DTClient => DTClient.FullName).NotNull().WithMessage("Full Name is requeired");
            RuleFor(DTClient => DTClient.Address).NotEmpty().WithMessage("Address is requeired");
            RuleFor(DTClient => DTClient.Address).NotNull().WithMessage("Address is requeired");
            RuleFor(DTClient => DTClient.Phone).NotEmpty().WithMessage("Phone is requeired");
            RuleFor(DTClient => DTClient.Phone).NotNull().WithMessage("Phone is requeired");
            RuleFor(DTClient => DTClient.CreditLimit).NotEmpty().WithMessage("Credit Limit is requeired");
            RuleFor(DTClient => DTClient.CreditLimit).NotNull().WithMessage("Credit Limit is requeired");
            RuleFor(DTClient => DTClient.CreditLimit).NotEqual(0).WithMessage("Credit Limit is requeired");
            RuleFor(DTClient => DTClient.IdCity).NotEqual(0).WithMessage("City  is requeired");
            RuleFor(DTClient => DTClient.IdCity).NotNull().WithMessage("City  is requeired");
        }

    }
}
