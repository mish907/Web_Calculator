using CalculatorAPI.Dto;
using CalculatorAPI.Models;

namespace CalculatorAPI.Mappers
{
    public static class StoredCalcMapper
    {
        /// <summary>
        /// Return 'StoredCalcDto' obj with the required fields of stored calculations to output.
        /// </summary>
        /// <param name="calcModel">'Calculator' object</param>
        /// <returns>'StoredCalcDto' object</returns>
        public static StoredCalcDto ToStoredCalcDto(this Calculator calcModel)
        {
            return new StoredCalcDto
            {
                ID = calcModel.ID,
                FirstNumber = calcModel.FirstNumber,
                Operator = calcModel.Operator,
                SecondNumber = calcModel.SecondNumber,
                Result = calcModel.Result,
            };
        }

        /// <summary>
        /// Return 'Calculator' obj with the required fields for basic calculation to input.
        /// </summary>
        /// <param name="clacDto">'CreateCalculationDto' obj inserted from client</param>
        /// <returns>'Calculator' object </returns>
        public static Calculator ToCalcFromCreateCalcDto(this CreateCalculationDto clacDto)
        {
            return new Calculator
            {
                FirstNumber = clacDto.FirstNumber,
                Operator = clacDto.Operator,
                SecondNumber = clacDto.SecondNumber,
            };
        }
    }
}
