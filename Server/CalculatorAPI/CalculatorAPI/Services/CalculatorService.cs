using System.Collections.Generic;
using CalculatorAPI.Data;
using CalculatorAPI.Dto;
using CalculatorAPI.Mappers;
using CalculatorAPI.Models;
using CalculatorAPI.ServicesInterfaces;

namespace CalculatorAPI.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly AppDBContext _context;

        public CalculatorService(AppDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create, calculte and save new 'Calculator' object.
        /// </summary>
        /// <param name="calcDto">'CreateCalculationDto' obj with required fields</param>
        /// <returns>'Calculator' obj</returns>
        public Calculator CreateCalculation(CreateCalculationDto calcDto)
        {
            try
            {
                var calcModel = calcDto.ToCalcFromCreateCalcDto();

                calcModel.Result = Calulate(calcModel);

                _context.storedCalculation.Add(calcModel);
                _context.SaveChanges();

                return calcModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Return list of all history calculations.
        /// </summary>
        /// <returns>List of all history calculations</returns>
        /// <exception cref="Exception">Returns if list is empty</exception>
        public IEnumerator<StoredCalcDto> GetAllCalculationHistory()
        {
            var storedCalculation = _context.storedCalculation.ToList()
                 .Select(s => s.ToStoredCalcDto());

            if (!storedCalculation.Any())
                throw new Exception("There is no stored calculation yet...");

            return (IEnumerator<StoredCalcDto>)storedCalculation;
        }

        private decimal Calulate(Calculator calc)
        {
            return Calulate(calc.FirstNumber, calc.SecondNumber, calc.Operator);
        }

        /// <summary>
        /// Calculate first input and the second input by givein math operator.
        /// </summary>
        /// <param name="first">First input number</param>
        /// <param name="second">Second input number</param>
        /// <param name="op">Operator type</param>
        /// <returns>Result after calculation</returns>
        private decimal Calulate(decimal first, decimal second,MathOperators op)
        {
            decimal toReturn = 0;

            switch (op)
            {
                case MathOperators.Addition:
                    toReturn = first + second; 
                    break;
                case MathOperators.Subtraction:
                    toReturn = first - second;
                    break;
                case MathOperators.Division:
                    toReturn = first / second;
                    break;
                case MathOperators.Multiplication:
                    toReturn = first * second;
                    break;
                default:
                    throw new Exception("Illegal math operations...");
            }

            return toReturn;
        }
    }
}
