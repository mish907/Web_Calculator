using CalculatorAPI.Models;

namespace CalculatorAPI.Dto
{
    /// <summary>
    /// Required fields to return stored calculation,
    /// to the client.
    /// </summary>
    public class StoredCalcDto
    {
        public int ID { get; set; }
        public decimal FirstNumber { get; set; }
        public MathOperators Operator { get; set; }
        public decimal SecondNumber { get; set; }
        public decimal Result { get; set; }
    }
}
