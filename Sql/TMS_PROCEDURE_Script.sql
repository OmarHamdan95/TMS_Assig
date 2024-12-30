CREATE PROCEDURE GetTasksByStatus
    @Status int,
    @UserId nvarchar(450),
    @IsAdmin bit
AS
BEGIN
    IF @IsAdmin = 1
        SELECT [ID],[TITLE],[DESCRIPTION],[STATUS],[PRIORITY],[ASSIGNED_TO_ID] as [ASSIGNEDTOID] , [DUE_DATE] as [DUEDATE] FROM [TMS].[TASKS] WHERE [STATUS] = @Status
    ELSE
        SELECT [ID],[TITLE],[DESCRIPTION],[STATUS],[PRIORITY],[ASSIGNED_TO_ID] as [ASSIGNEDTOID] , [DUE_DATE] as [DUEDATE] FROM [TMS].[TASKS] WHERE [STATUS] = @Status AND [ASSIGNED_TO_ID] = @UserId
END

---------------------------------


CREATE PROCEDURE GetTasksDueToday
    @UserId nvarchar(450),
    @IsAdmin bit
AS
BEGIN
    IF @IsAdmin = 1
         SELECT [ID],[TITLE],[DESCRIPTION],[STATUS],[PRIORITY],[ASSIGNED_TO_ID] as [ASSIGNEDTOID] , [DUE_DATE] as [DUEDATE] FROM [TMS].[TASKS]
        WHERE CAST([DUE_DATE] AS DATE) = CAST(GETUTCDATE() AS DATE)
    ELSE
        SELECT [ID],[TITLE],[DESCRIPTION],[STATUS],[PRIORITY],[ASSIGNED_TO_ID] as [ASSIGNEDTOID] , [DUE_DATE] as [DUEDATE] FROM [TMS].[TASKS] 
        WHERE CAST([DUE_DATE] AS DATE) = CAST(GETUTCDATE() AS DATE)
        AND [ASSIGNED_TO_ID] = @UserId
END

---------------------------------------------


CREATE PROCEDURE GetUserTaskCounts
AS
BEGIN
  SELECT 
        u.Id as [ASSIGNEDTOID],
        u.[USER_NAME] as [USERNAME],
        COUNT(t.Id) as TaskCount,
        SUM(CASE WHEN t.Status = 3 THEN 1 ELSE 0 END) as CompletedTasks
    FROM [TMS].[USERS] u
    LEFT JOIN [TMS].[TASKS] t ON u.Id = t.[ASSIGNED_TO_ID]
    GROUP BY u.Id, u.[USER_NAME]
END
