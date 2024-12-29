using AjKpi.Model;

namespace AjKpi.Application;

public sealed record GridWfTransactionReqeust : GridParameters , IRequest<Result<Grid<WfTransactionModel>>>;
