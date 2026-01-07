using Hrms.SharedKernel.Base;

namespace Hrms.AttendanceService.Domain;

public class Attendance : BaseEntity
{
    public int EmployeeId { get; set; }
    public DateTime CheckInTime { get; set; }
    public DateTime? CheckOutTime { get; set; }
    public TimeSpan? WorkingHours { get; set; }
    public string Status { get; set; } = "Present"; // Present, Absent, Late
    public string? Notes { get; set; }
}