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
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum);
        }
        return BadRequest("Invalid Input!");
    }

    private decimal ConvertToDecimal(string strNumber)
    {
        decimal result = 0;
        if (decimal.TryParse(
            strNumber
            , System.Globalization.NumberStyles.Any
            , System.Globalization.NumberFormatInfo.InvariantInfo
            , out result)
        )
        {
            return result;
        }
        return 0;
    }

    private bool IsNumeric(string strNumber)
    {
        decimal result = 0;
        bool isNumber = (decimal.TryParse(
            strNumber
            , System.Globalization.NumberStyles.Any
            , System.Globalization.NumberFormatInfo.InvariantInfo
            , out result)
        );
        return isNumber;
    }
}
