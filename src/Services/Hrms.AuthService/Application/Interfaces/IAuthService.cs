using Hrms.AuthService.Application.DTOs;
using Hrms.SharedKernel.Responses;

namespace Hrms.AuthService.Application.Interfaces;

public interface IAuthService
{
    Task<ApiResponse<AuthResponse>> LoginAsync(LoginRequest request);
    Task<ApiResponse<AuthResponse>> RegisterAsync(RegisterRequest request);
    Task<ApiResponse<bool>> ValidateTokenAsync(string token);
}