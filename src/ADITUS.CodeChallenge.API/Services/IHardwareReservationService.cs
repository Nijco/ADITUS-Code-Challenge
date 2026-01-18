using ADITUS.CodeChallenge.API.Domain;
using ADITUS.CodeChallenge.API.Dtos;

namespace ADITUS.CodeChallenge.API.Services;

public interface IHardwareReservationService
{
    Task<HardwareReservationDto?> GetHardwareReservation(Guid id);
    Task<HardwareReservationResultDto> CreateHardwareReservation(HardwareReservationDto dto);
    Task<bool?> CancelHardwareReservation(Guid id);
}