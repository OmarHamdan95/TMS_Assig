﻿using AjKpi.Application.Common;
using Microsoft.EntityFrameworkCore;
using Shared.Common;
namespace AjKpi.Application;

using static System.Net.HttpStatusCode;

public sealed record CountDraftDashboardHandler : IRequestHandler<CountDraftDashboardRequest, Result<long>>
{
    private readonly IRepositoryBase<Kpi> _kpiRepository;
    private readonly ICurrentUserService _currentUserService;
    public CountDraftDashboardHandler(IRepositoryBase<Kpi> kpiRepository, ICurrentUserService currentUserService)
    {
        _kpiRepository = kpiRepository;
        _currentUserService = currentUserService;
    }


    public async Task<Result<long>> Handle(CountDraftDashboardRequest request, CancellationToken cancellationToken)
    {
        string currentUserDepartmentIdString = _currentUserService?.DepartmentId;
        long departmentId = 0;
        long.TryParse(currentUserDepartmentIdString, out departmentId);

        var data = await _kpiRepository.Queryable.Where(
            x =>
                x.Status.Code.ToLower() == Constant.Draft.ToLower()
                && x.OwnerDepartemntId == departmentId
        ).AsNoTracking().CountAsync();


        return new Result<long>(OK, data);
    }
}
