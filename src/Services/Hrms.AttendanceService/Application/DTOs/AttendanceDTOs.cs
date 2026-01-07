namespace Hrms.AttendanceService.Application.DTOs;

public record AttendanceCreateDto(
    int EmployeeId,
    DateTime CheckInTime,
    string? Notes);

public record AttendanceUpdateDto(
    DateTime? CheckOutTime,
    string Status,
    string? Notes);

public record AttendanceResponseDto(
    int Id,
    int EmployeeId,
    DateTime CheckInTime,
    DateTime? CheckOutTime,
    TimeSpan? WorkingHours,
    string Status,
    string? Notes,
    DateTime CreatedAt);