namespace Hrms.SharedKernel.Constants;

public static class RoleConstants
{
    public const string Admin = "Admin";
    public const string Employer = "Employer";
    public const string Employee = "Employee";
}

public static class PolicyConstants
{
    public const string AdminOnly = "AdminOnly";
    public const string EmployerOrAdmin = "EmployerOrAdmin";
    public const string AllRoles = "AllRoles";
}