namespace AjKpi.Application;

using static System.Net.HttpStatusCode;

public class AddWfTransactionHandler :IRequestHandler<AddWfTransactionRequest, Result<long?>>
{
    private readonly IUnitOfWork _unitOfWork;
    private IWFRepositoryBase<WfTransaction> _wfTransactionRepository;

    public AddWfTransactionHandler(IWFRepositoryBase<WfTransaction> wfTransactionRepository , IUnitOfWork unitOfWork) =>
        (_wfTransactionRepository , _unitOfWork) = (wfTransactionRepository , unitOfWork);


    public async Task<Result<long?>> Handle(AddWfTransactionRequest request, CancellationToken cancellationToken)
    {
        WfTransaction txn = new WfTransaction(request.RequestId, request.Comment, request.Action,
            request.OldStatusCode , request.OldStatusDescriptionAr , request.OldStatusDescriptionEn , request.NewStatusCode , request.NewStatusDescriptionAr,
            request.NewStatusDescriptionEn, request.DepartmentCode, request.RoleCode);

        await _wfTransactionRepository.AddAsync(txn);

        await _unitOfWork.SaveChangesAsync();

        return new Result<long?>(Created, txn.Id);
    }
}
