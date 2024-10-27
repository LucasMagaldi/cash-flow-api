using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseUseCase
    {
        public ResponseRegisterExpense Execute(RequestExpense request)
        {
            RequestDataValidation(request);
            return new ResponseRegisterExpense();
        }

        private void RequestDataValidation(RequestExpense request)
        {
            var isTitleValid = string.IsNullOrWhiteSpace(request.Title);
            if(isTitleValid)
            {
                throw new ArgumentException("Title is rquired");
            }

            if(request.Amount < 0)
            {
                throw new ArgumentException("The amount must be grater then zero");
            }

            var isDateValid = DateTime.Compare(request.Date, DateTime.UtcNow);
            if (isDateValid > 0)
            {
                throw new ArgumentException("The expenses cannot be for the future");
            }

            var isPaymentValid = Enum.IsDefined(typeof(PaymentType), request.PayementType);
            if (!isPaymentValid)
            {
                throw new ArgumentException("Payment type is not valid");
            }
        }
    }
}
