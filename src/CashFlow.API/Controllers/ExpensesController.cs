using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] RequestExpense request)
        {
            try
            {
                var useCase = new RegisterExpenseUseCase();

                var response = useCase.Execute(request);
                return Created(string.Empty, response);
            } catch (ErrorOnValidationException ex)
            {
                var errorMessageResponse = new ResponseError(ex.Errors);
                return BadRequest(errorMessageResponse);
            } catch
            {
                var errorMessageResponse = new ResponseError("Internal Server Error");
                return StatusCode(StatusCodes.Status500InternalServerError, errorMessageResponse);
            }

        }
    }
}
