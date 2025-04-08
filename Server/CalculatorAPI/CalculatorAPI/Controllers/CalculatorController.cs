using CalculatorAPI.Data;
using CalculatorAPI.Dto;
using CalculatorAPI.Mappers;
using CalculatorAPI.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorAPI.Controllers
{
    [Route("api/calculator")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;

        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        ///
        /// <summary>
        /// Return list with all history of stored calculations.
        /// </summary>
        /// <returns>List of 'storedCalculation' or message if list is empty.</returns>
        /// <exception cref="Exception">Returns if list is empty</exception>
        [HttpGet]
        public IActionResult GetAllHistory()
        {
            try
            {
                var storedCalculation = _calculatorService.GetAllCalculationHistory();


                return Ok(storedCalculation);
            }
            catch (Exception ex) {
                return Content(ex.Message);
            }
        }

        /// <summary>
        /// Create, calculte and save new 'Calculator' object.
        /// </summary>
        /// <param name="calcDto">'CreateCalculationDto' obj with required fields</param>
        /// <returns>'Calculator' obj</returns>
        [HttpPost]
        public IActionResult Create([FromBody] CreateCalculationDto calcDto)
        {
            try
            {
                var calcModel = _calculatorService.CreateCalculation(calcDto);

                return Ok(calcModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
