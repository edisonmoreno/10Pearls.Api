//####################################################################
// Project:         10Pearls
// Author:          Jonathan Dávila A.
// DATA:            08/10/2019
// Comment:         Class visits validator with fluent validations
//####################################################################
namespace InfoClient.DT.Utilities.FluentValidators
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FluentValidation;
    using InfoClient.DT.Client;


    public class DTVisitValidator : AbstractValidator<DTVisit>
    {
        public DTVisitValidator()
        {
            RuleFor(DTVisit => DTVisit.IdClient).NotEmpty().WithMessage("Client is requeired");
            RuleFor(DTVisit => DTVisit.IdClient).NotEqual(0).WithMessage("Client is requeired");
            RuleFor(DTVisit => DTVisit.VisitDate).NotEmpty().WithMessage("Visit Date  is requeired");
            RuleFor(DTVisit => DTVisit.VisitDate).NotNull().WithMessage("Visit Date  is requeired");
            RuleFor(DTVisit => DTVisit.IdSrepresentative).NotEmpty().WithMessage("Sale representative is requeired");
            RuleFor(DTVisit => DTVisit.IdSrepresentative).NotEqual(0).WithMessage("Sale representative is requeired");
            RuleFor(DTVisit => DTVisit.Net).NotEmpty().WithMessage("Net is requeired");
            RuleFor(DTVisit => DTVisit.Net).NotNull().WithMessage("Net is requeired");
        }

    }
}
