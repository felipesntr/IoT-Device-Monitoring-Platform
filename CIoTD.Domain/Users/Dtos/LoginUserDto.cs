namespace CIoTD.Domain.Users.Dtos;

public sealed record LoginUserDto(
    string Username,
    string Password
    );