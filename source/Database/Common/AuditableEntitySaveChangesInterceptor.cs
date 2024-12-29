// using Microsoft.EntityFrameworkCore.Diagnostics;
//
// namespace AjKpi.Database.Common;
//
// public class AuditableEntitySaveChangesInterceptor :  ISaveChangesInterceptor
// {
//     private readonly string _currentUser;
//     public AuditableEntitySaveChangesInterceptor(string currentUser)
//     {
//         _currentUser = currentUser;
//     }
//
//     public async ValueTask<InterceptionResult<int>> SavingChangesAsync(
//         DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken)
//     {
//         if (eventData.Context is not null)
//         {
//             UpdateAuditableEntities(eventData.Context);
//         }
//
//         return await base.SavingChangesAsync(eventData, result, cancellationToken);
//     }
//
// }
