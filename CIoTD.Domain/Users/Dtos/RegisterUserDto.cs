namespace CIoTD.Domain.Users.Dtos;

public sealed record RegisterUserDto(
    string Username,
    string Email,
    string Password
    );