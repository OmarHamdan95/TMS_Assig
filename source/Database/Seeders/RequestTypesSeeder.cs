using AjKpi.Database.Common;
using AjKpi.Database.Seeders.Dtos;
using Microsoft.Extensions.Configuration;

namespace AjKpi.Database.Seeders;

public class RequestTypesSeeder :ISeeder
{
    public async Task SeedAsync(Context context, IConfiguration configuration)
    {
        var requestTypes = JsonFileReader.ReadJsonFile<List<RequestTypeSetup>>(configuration["Seeders:RequestTypes"]);
        var requestTypesSet = context.Set<RequestType>();
        var statusesSet = context.Set<RequestStatus>();

         foreach (var requestType in requestTypes)
            {
                var existingRequestType = await requestTypesSet
                    .Include(e => e.Statuses)
                    .FirstOrDefaultAsync(r => r.Code == requestType.Code);

                // Add or update request type.
                if (existingRequestType == null)
                {
                    existingRequestType = new RequestType()
                    {
                        Code = requestType.Code,
                        NameAr= requestType.NameAr,
                        NameEn= requestType.NameEn,
                        CompositeKeyTemplate = requestType.CompositeKeyTemplate,
                        ConcurrencyPreventedTypeCodes = requestType.ConcurrencyPreventedTypeCodes,
                        EventQueueName = requestType.EventQueueName,
                        GlobalCompositeKeyTemplate = requestType.GlobalCompositeKeyTemplate,
                        MaxAllowedRequests = requestType.MaxAllowedRequests,
                        PreventConcurrentRequests = requestType.PreventConcurrentRequests,
                        RequestNumberTemplate = requestType.RequestNumberTemplate,
                        SearchEntries = requestType.SearchEntries,
                    };

                    await requestTypesSet.AddAsync(existingRequestType);
                    await context.SaveChangesAsync();
                }
                else
                {
                    existingRequestType.NameAr = requestType.NameAr;
                    existingRequestType.NameEn = requestType.NameEn;
                    existingRequestType.CompositeKeyTemplate = requestType.CompositeKeyTemplate;
                    existingRequestType.ConcurrencyPreventedTypeCodes = requestType.ConcurrencyPreventedTypeCodes;
                    existingRequestType.EventQueueName = requestType.EventQueueName;
                    existingRequestType.GlobalCompositeKeyTemplate = requestType.GlobalCompositeKeyTemplate;
                    existingRequestType.MaxAllowedRequests = requestType.MaxAllowedRequests;
                    existingRequestType.PreventConcurrentRequests = requestType.PreventConcurrentRequests;
                    existingRequestType.RequestNumberTemplate = requestType.RequestNumberTemplate;
                    existingRequestType.SearchEntries = requestType.SearchEntries;

                    requestTypesSet.Update(existingRequestType);
                    await context.SaveChangesAsync();
                }

                // Delete, add or update request type statuses.
                var newStatusCodes = requestType.Statuses.Select(s => s.Code).ToHashSet();
                var deletedStatuses = existingRequestType.Statuses?.Where(s => !newStatusCodes.Contains(s.Code));
                if (deletedStatuses != null)
                {
                    statusesSet.RemoveRange(deletedStatuses);
                    await context.SaveChangesAsync();
                }

                foreach (var status in requestType.Statuses)
                {
                    var existingStatus = existingRequestType.Statuses?.FirstOrDefault(s => s.Code == status.Code);

                    if (existingStatus == null)
                    {
                        existingStatus = new RequestStatus()
                        {
                            ActionNameAr = status.ActionNameAr,
                            ActionNameEn = status.ActionNameEn,
                            Code = status.Code,
                            DescriptionAr = status.DescriptionAr,
                            DescriptionEn = status.DescriptionEn,
                            IsStartingState = status.IsStartingState,
                            IsEndState = status.IsEndState,
                            NextStatusCodes = status.NextStatusCodes,
                            PreviousStatusCodes = status.PreviousStatusCodes,
                            Roles = status.Roles,
                            RequestTypeId = existingRequestType.Id,
                            CssClass = status.CssClass,
                            Color = status.Color,
                            Icon = status.Icon,
                            IsEditable = status.IsEditable,
                            IsAction = status.IsAction,
                            IsDeletable = status.IsDeletable,
                            DepartmentCode = status.DepartmentCode
                        };

                        await statusesSet.AddAsync(existingStatus);
                        await context.SaveChangesAsync();
                    }
                    else
                    {
                        existingStatus.ActionNameAr = status.ActionNameAr;
                        existingStatus.ActionNameEn = status.ActionNameEn;
                        existingStatus.DescriptionAr = status.DescriptionAr;
                        existingStatus.DescriptionEn = status.DescriptionEn;
                        existingStatus.IsStartingState = status.IsStartingState;
                        existingStatus.IsEndState = status.IsEndState;
                        existingStatus.NextStatusCodes = status.NextStatusCodes;
                        existingStatus.PreviousStatusCodes = status.PreviousStatusCodes;
                        existingStatus.Roles = status.Roles;
                        existingStatus.Icon = status.Icon;
                        existingStatus.Color = status.Color;
                        existingStatus.CssClass = status.CssClass;
                        existingStatus.IsEditable = status.IsEditable;
                        existingStatus.IsDeletable = status.IsDeletable;
                        existingStatus.IsAction = status.IsAction;
                        existingStatus.DepartmentCode = status.DepartmentCode;

                        statusesSet.Update(existingStatus);
                        await context.SaveChangesAsync();
                    }
                }
            }
    }
}
