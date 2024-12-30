using Microsoft.EntityFrameworkCore;
using TMS.Database;
using static System.Net.HttpStatusCode;

namespace TMS.Application;

public sealed record ChangePasswordHandler : IRequestHandler<ChangePasswordRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthRepository _authRepository;
    private readonly IHashService _hashService;

    public ChangePasswordHandler
    (
        IUnitOfWork unitOfWork,
        IAuthRepository authRepository,
        IHashService hashService
    )
    {
        _unitOfWork = unitOfWork;
        _authRepository = authRepository;
        _hashService = hashService;
    }

    public async Task<Result> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
    {
        var auth = await _authRepository.Queryable.Where(_=> _.User.Id == request.Id).FirstOrDefaultAsync();

        if (auth is null) return new Result(NotFound);


        if (!_hashService.Validate(auth.Password, request.OldPassword, auth.Salt.ToString())) return new Result(NotFound);;

        var password = _hashService.Create(request.NewPassword, auth.Salt.ToString());

        auth.UpdatePassword(password);


        await _authRepository.UpdateAsync(auth);

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
