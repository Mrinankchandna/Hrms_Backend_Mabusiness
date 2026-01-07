using Hrms.AttendanceService.Application.DTOs;
using Hrms.SharedKernel.Responses;

namespace Hrms.AttendanceService.Application.Interfaces;

public interface IAttendanceService
{
    Task<ApiResponse<AttendanceResponseDto>> CreateAttendanceAsync(AttendanceCreateDto dto);
    Task<ApiResponse<AttendanceResponseDto>> UpdateAttendanceAsync(int id, AttendanceUpdateDto dto);
    Task<ApiResponse<AttendanceResponseDto>> GetAttendanceByIdAsync(int id);
    Task<ApiResponse<List<AttendanceResponseDto>>> GetAttendanceByEmployeeAsync(int employeeId);
    Task<ApiResponse<bool>> DeleteAttendanceAsync(int id);
}