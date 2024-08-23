namespace JornadaMilhas.Application.Querys.Dtos.UsersDto
{
    public record UserAdminDto : UserDto
    {
        public string CodeEmployee { get; set; }
    }
}
