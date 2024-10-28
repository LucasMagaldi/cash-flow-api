using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterRequestDataValidation : AbstractValidator<RequestExpense>
    {
        public RegisterRequestDataValidation() 
        {
            RuleFor(expense => expense.Title).NotEmpty().WithMessage("Title is rquired");
            RuleFor(expense => expense.Amount).GreaterThanOrEqualTo(0).WithMessage("The amount must be grater then zero");
            RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("The expenses cannot be for the future");
            RuleFor(expense => expense.PayementType).IsInEnum().WithMessage("Payment type is not valid");
        }
    }
}
