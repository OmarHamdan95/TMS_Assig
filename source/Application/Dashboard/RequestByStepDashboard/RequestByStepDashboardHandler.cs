using AjKpi.Application.Common;
using AjKpi.Model.Dashboard;
using Microsoft.EntityFrameworkCore;
using Shared.Common;
namespace AjKpi.Application;

using static System.Net.HttpStatusCode;

public sealed record RequestByStepDashboardHandler : IRequestHandler<RequestByStepDashboardRequest, Result<List<DashbordRequestByStepModel>>>
{
    private readonly IWFRepositoryBase<Request> _wfReqeustRepository;
    private readonly IWFRepositoryBase<RequestStatus> _wfReqeustStatusRepository;
    private readonly ICurrentUserService _currentUserService;
    public RequestByStepDashboardHandler(IWFRepositoryBase<Request> wfReqeustRepository, ICurrentUserService currentUserService , IWFRepositoryBase<RequestStatus> wfReqeustStatusRepository)
    {
        _wfReqeustRepository = wfReqeustRepository;
        _currentUserService = currentUserService;
        _wfReqeustStatusRepository = wfReqeustStatusRepository;
    }


    public async Task<Result<List<DashbordRequestByStepModel>>> Handle(RequestByStepDashboardRequest request, CancellationToken cancellationToken)
    {
        var query = _wfReqeustRepository.Queryable.AsNoTracking();

        var requestStatusDate = await _wfReqeustStatusRepository.Queryable.AsNoTracking().ToListAsync();

        var data = await query.GroupBy(_=> _.Status.DescriptionAr)
            .Select(k => new DashbordRequestByStepModel()
        {
           StepName = k.Key,
           Count = k.Count(),
        }).ToListAsync();


        foreach (var status in requestStatusDate)
        {
            if(!data.Any(_=> _.StepName == status.DescriptionAr))
                data.Add(new DashbordRequestByStepModel(){StepName = status.DescriptionAr , Count = 0});
        }


        return new Result<List<DashbordRequestByStepModel>>(OK, data);
    }
}
