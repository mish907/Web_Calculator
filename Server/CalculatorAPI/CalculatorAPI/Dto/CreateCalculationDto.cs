using CalculatorAPI.Models;

namespace CalculatorAPI.Dto
{
    /// <summary>
    /// Required fields to create basic calculation,
    /// from the client.
    /// </summary>
    public class CreateCalculationDto
    {
        public decimal FirstNumber { get; set; }
        public MathOperators Operator { get; set; }
        public decimal SecondNumber { get; set; }
    }
}
