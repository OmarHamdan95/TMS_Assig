//using AjKpi.Database;
//using AjKpi.Model;
//using static System.Net.HttpStatusCode;

//namespace AjKpi.Application;

//public sealed record
//    AutoCompleteLookupHandler : IRequestHandler<AutoCompleteLookupRequest, Result<IEnumerable<LookupValueModel>>>
//{
//    private readonly ILookupValueRepository _lookupRepository;
//    private readonly IDepartmentRepository _departmentRepostotry;
//    private readonly IRoleRepository _roleRepository;

//    public AutoCompleteLookupHandler(ILookupValueRepository lookupRepository,
//        IDepartmentRepository departmentRepostotry, IRoleRepository roleRepository) =>
//        (_lookupRepository, _departmentRepostotry, _roleRepository) =
//        (lookupRepository, departmentRepostotry, roleRepository);


//    public async Task<Result<IEnumerable<LookupValueModel>>> Handle(AutoCompleteLookupRequest request,
//        CancellationToken cancellationToken)
//    {
//        IEnumerable<LookupValueModel> lookup = null;

//        if (request.lookupCode.ToLower() == nameof(Department).ToLower())
//            lookup = await _departmentRepostotry.AutoComplate<LookupValueModel>(request.text);
//        else if (request.lookupCode.ToLower() == nameof(Role).ToLower())
//            lookup = await _roleRepository.AutoComplate<LookupValueModel>(request.text);
//        else
//            lookup = await _lookupRepository.AutoComplate<LookupValueModel>(request.lookupCode, request.text);

//        return new Result<IEnumerable<LookupValueModel>>(lookup is null ? NotFound : OK, lookup);
//    }
//}
