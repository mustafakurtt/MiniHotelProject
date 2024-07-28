using Core.Entities;

namespace Entities.DTOs.AuthDTOs;

public class UserForLoginDto
{
    public string UserCode { get; set; }
    public string Password { get; set; }
}