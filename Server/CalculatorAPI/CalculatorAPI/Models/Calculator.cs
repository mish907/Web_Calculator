using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalculatorAPI.Models
{
    public class Calculator
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public decimal FirstNumber { get; set; }
        public MathOperators Operator { get; set; }
        public decimal SecondNumber { get; set; }
        public decimal Result { get; set; }
    }
}
