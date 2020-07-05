using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace restUdemy.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {


        // GET api/<controller>/5
        [HttpGet("{firtNumber}/{secondNumber}")]
        public IActionResult Sum(string firtNumber, string secondNumber)
        {
            if (IsNumeric(firtNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firtNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private decimal ConvertToDecimal(string number)
        {
            decimal dec;
            if (decimal.TryParse(number,out dec))
            { return dec; }
            return 0;
        }

        private bool IsNumeric(string numberP)
        {
            double number;
            bool isNumber = double.TryParse(numberP, 
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out number);
            return isNumber;
        }
    }
}
