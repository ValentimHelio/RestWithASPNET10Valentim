using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNET10Valentim.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MathController : ControllerBase
{
    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Get(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber)+ ConvertToDecimal(secondNumber);
            return Ok(sum); 
        }
        BadRequest("Invalid Input!");
    }

    private decimal ConvertToDecimal(string secondNumber)
    {
        throw new NotImplementedException();
    }

    private bool IsNumeric(string firstNumber)
    {
        return true;
    }
}
