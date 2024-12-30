namespace TMS.Domain;

public enum Status
{
    None = 0,
    Active = 1,
    Inactive = 2
}


public enum TaskStatus
{
    Pending = 1,
    InProgress = 2,
    Completed = 3,
    Canceled = 4,
}


public enum TaskPriority
{
    Low =1 ,
    Medium =2 ,
    High =3 ,
}


public enum UserRole
{
    Admin = 1,
    User = 2,
}
