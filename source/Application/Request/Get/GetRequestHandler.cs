using AjKpi.Database;
using AjKpi.Domain;
using AjKpi.Model;
using Microsoft.EntityFrameworkCore;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record GetRequestHandler : IRequestHandler<GetRequest, Result<RequestGridModel>>
{
    private readonly IRepositoryBase<Request> _requestRepository;

    public GetRequestHandler(IRepositoryBase<Request> requestRepository) => _requestRepository = requestRepository;

    public async Task<Result<RequestGridModel>> Handle(GetRequest command , CancellationToken cancellationToken)
    {
        // var reqeustData = await _requestRepository.Queryable.AsNoTracking().

        var reqeustData = await _requestRepository.Queryable
            .Where(x=> x.Id == command.Id)
            .Include(r => r.Type.Statuses)
            .Include(r => r.Status)
            .Include(r => r.Type)
            .AsNoTracking()
            .ProjectToType<RequestGridModel>()
            .FirstOrDefaultAsync();


        return new Result<RequestGridModel>(reqeustData is null ? NotFound : OK, reqeustData);
    }
}
