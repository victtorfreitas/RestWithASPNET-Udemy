using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        // GET api/values/5/2
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public ActionResult<string> SumEvolution(decimal? firstNumber, decimal? secondNumber) => Ok(firstNumber + secondNumber);

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public ActionResult<string> SubEvolution(decimal? firstNumber, decimal? secondNumber) => Ok(firstNumber - secondNumber);

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public ActionResult<string> DivEvolution(decimal? firstNumber, decimal? secondNumber) => Ok(firstNumber / secondNumber);

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public ActionResult<string> MultEvolution(decimal? firstNumber, decimal? secondNumber) => Ok(firstNumber * secondNumber);


        [HttpGet("media/{firstNumber}/{secondNumber}")]
        public ActionResult<string> MediaEvolution(decimal? firstNumber, decimal? secondNumber) => Ok((firstNumber + secondNumber) / 2);

        [HttpGet("raiz/{number}")]
        public ActionResult<string> RaizEvolution(double? number) => Ok(Math.Sqrt(Convert.ToDouble(number)));

        // GET api/values/5/2
        [HttpGet("{firstNumber}/{secondNumber}")]
        public ActionResult<string> Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum);
            }
            return BadRequest("Invalid input");
        }

        private decimal ConvertToDecimal(string number)
        {
            return decimal.TryParse(number, out decimal numberDecimal) ? numberDecimal : 0;
        }

        private bool IsNumeric(string number)
        {
            return decimal.TryParse(number, out var isNumeric) ? true : false;
        }
    }
}

