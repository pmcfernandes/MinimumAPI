namespace APIBase.Models;

public class UserGroupModel
{
    public int IDGroup
    {
        get;
        set;
    }

    public string Groupname
    {
        get;
        set;
    } = "";

    public bool InGroup
    {
        get;
        set;
    } = false;
}
