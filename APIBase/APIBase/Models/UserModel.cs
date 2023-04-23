namespace APIBase.Models;

public class UserModel : UsersModel
{
    public string? Address
    {
        get;
        set;
    }

    public string? City
    {
        get;
        set;
    }

    public string? ZipCode
    {
        get;
        set;
    }

    public string? Phone
    {
        get;
        set;
    }

    public string? Mobile
    {
        get;
        set;
    }

    public bool IsAuditable
    {
        get;
        set;
    } = false;
}