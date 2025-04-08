using CalculatorAPI.Dto;
using CalculatorAPI.Models;

namespace CalculatorAPI.ServicesInterfaces
{
    public interface ICalculatorService
    {
        IEnumerator<StoredCalcDto> GetAllCalculationHistory();

        Calculator CreateCalculation(CreateCalculationDto calcDto);
    }
}
