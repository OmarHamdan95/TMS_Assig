using TMS.Database;
using TMS.Domain;
using static System.Net.HttpStatusCode;

namespace TMS.Application;

public sealed record AddUserHandler : IRequestHandler<AddUserRequest, Result<long>>
{
    private readonly IAuthRepository _authRepository;
    private readonly IHashService _hashService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public AddUserHandler
    (
        IAuthRepository authRepository,
        IHashService hashService,
        IUnitOfWork unitOfWork,
        IUserRepository userRepository
    )
    {
        _authRepository = authRepository;
        _hashService = hashService;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<Result<long>> Handle(AddUserRequest request , CancellationToken cancellationToken)
    {
        var user = new User(request.NameEn, request.NameEn, request.Login, request.MobileNumber, request.Email , request?.Role);


        var auth = new Auth(request.Login, request.Password, user );

        var password = _hashService.Create(auth.Password, auth.Salt.ToString());

        auth.UpdatePassword(password);

        await _userRepository.AddAsync(user);

        await _authRepository.AddAsync(auth);

        await _unitOfWork.SaveChangesAsync();

        return new Result<long>(Created, user.Id);
    }
}
