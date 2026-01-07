using Microsoft.AspNetCore.Mvc;
using Hrms.AttendanceService.Application.Interfaces;
using Hrms.AttendanceService.Application.DTOs;
using Hrms.SharedKernel.Responses;

namespace Hrms.AttendanceService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AttendanceController : ControllerBase
{
    private readonly IAttendanceService _attendanceService;

    public AttendanceController(IAttendanceService attendanceService)
    {
        _attendanceService = attendanceService;
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<AttendanceResponseDto>>> CreateAttendance(AttendanceCreateDto dto)
    {
        var result = await _attendanceService.CreateAttendanceAsync(dto);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<AttendanceResponseDto>>> UpdateAttendance(int id, AttendanceUpdateDto dto)
    {
        var result = await _attendanceService.UpdateAttendanceAsync(id, dto);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<AttendanceResponseDto>>> GetAttendance(int id)
    {
        var result = await _attendanceService.GetAttendanceByIdAsync(id);
        return result.Success ? Ok(result) : NotFound(result);
    }

    [HttpGet("employee/{employeeId}")]
    public async Task<ActionResult<ApiResponse<List<AttendanceResponseDto>>>> GetAttendanceByEmployee(int employeeId)
    {
        var result = await _attendanceService.GetAttendanceByEmployeeAsync(employeeId);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> DeleteAttendance(int id)
    {
        var result = await _attendanceService.DeleteAttendanceAsync(id);
        return result.Success ? Ok(result) : NotFound(result);
    }
}