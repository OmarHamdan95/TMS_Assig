using AjKpi.Application.Common;
using AjKpi.Database;
using AjKpi.Model;
using Microsoft.EntityFrameworkCore;
using Shared.Common;
using static System.Net.HttpStatusCode;
using Extensions = DotNetCore.Security.Extensions;

namespace AjKpi.Application;

public sealed record
    AutoCompleteLookupHandler : IRequestHandler<AutoCompleteLookupRequest, Result<IEnumerable<LookupValueModel>>>
{
    private readonly ILookupValueRepository _lookupRepository;
    private readonly IDepartmentRepository _departmentRepostotry;
    private readonly IRoleRepository _roleRepository;
    private readonly IWFRepositoryBase<RequestType> _wfRequestTypeRepository;
    private readonly IWFRepositoryBase<RequestStatus> _wfRequestStatusRepository;
    private readonly IRepositoryBase<Kpi> _kpiRepository;
    private readonly ICurrentUserService _currentUserService;

    public AutoCompleteLookupHandler(ILookupValueRepository lookupRepository,
        IDepartmentRepository departmentRepostotry, IRoleRepository roleRepository, IWFRepositoryBase<RequestType> wfRequestTypeRepository,
        IWFRepositoryBase<RequestStatus> wfRequestStatusRepository, IRepositoryBase<Kpi> kpiRepository, ICurrentUserService currentUserService) =>
        (_lookupRepository, _departmentRepostotry, _roleRepository, _wfRequestTypeRepository, _wfRequestStatusRepository, _kpiRepository, _currentUserService) =
        (lookupRepository, departmentRepostotry, roleRepository, wfRequestTypeRepository, wfRequestStatusRepository, kpiRepository, currentUserService);


    public async Task<Result<IEnumerable<LookupValueModel>>> Handle(AutoCompleteLookupRequest request,
        CancellationToken cancellationToken)
    {
        IEnumerable<LookupValueModel> lookup = null;


        if (request.lookupCode.ToLower() == nameof(RequestType).ToLower())
            lookup = await _wfRequestTypeRepository.AutoComplate<LookupValueModel>(request.text);

        else if (request.lookupCode.ToLower() == nameof(Department).ToLower())
            lookup = await _departmentRepostotry.AutoComplate<LookupValueModel>(request.text);

        else if (request.lookupCode.ToLower() == nameof(RequestStatus).ToLower())
        {
            lookup = await _wfRequestStatusRepository.AutoComplate<LookupValueModel>(request.text);
            lookup = lookup.DistinctBy(_ => _.Code);
        }

        else if (request.lookupCode.ToLower() == nameof(Kpi).ToLower())
        {
            var query = _kpiRepository.Queryable.Where(_ => _.Status.Code.ToLower() == Constant.Approved.ToLower());

            var curentUserDepartmentCode = _currentUserService.DepartmentCode;

            if (curentUserDepartmentCode != Constant.StrategyDepartmentCode)
                query = query.Where(x => x.OwnerDepartemnt.Code == curentUserDepartmentCode);

            lookup = await query
                .Select(_ => new LookupValueModel()
                {
                    Id = _.Id,
                    Code = _.Code,
                    NameAr = _.NameAr,
                    NameEn = _.NameEn,
                }).ToListAsync();

            //lookup = lookup.DistinctBy(_ => _.Code);
        }

        else if (request.lookupCode.ToLower() == nameof(Role).ToLower())
            lookup = await _roleRepository.AutoComplate<LookupValueModel>(request.text, request.parentId);
        else
            lookup = await _lookupRepository.AutoComplate<LookupValueModel>(request.lookupCode, request.text);

        return new Result<IEnumerable<LookupValueModel>>(lookup is null ? NotFound : OK, lookup);
    }
}
