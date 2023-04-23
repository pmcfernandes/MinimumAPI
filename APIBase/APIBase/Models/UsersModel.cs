namespace APIBase.Models;

public class UsersModel : InsertedUserModel
{
    public string? Username
    {
        get;
        set;
    }

    public string? Fullname
    {
        get;
        set;
    }

    public string? Email
    {
        get;
        set;
    }
}
