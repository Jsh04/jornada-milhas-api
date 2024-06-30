using JornadaMilhas.Application.Querys.Dtos.LoginResponseDto;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using MediatR;

namespace JornadaMilhas.Application.Querys.LoginQuerys.LoginUserQuerys;

public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, Result<LoginResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public LoginUserQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
    

    public async Task<Result<LoginResponseDto>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        var loginResult = await _unitOfWork.UserLimitedRepository.GetUserByEmail(request.Email, cancellationToken);

        LoginResponseDto loginResponse = new ();
        loginResponse.Token = string.Empty;
        loginResponse.User = default;


        return Result<LoginResponseDto>.Ok(loginResponse);
    }
}
