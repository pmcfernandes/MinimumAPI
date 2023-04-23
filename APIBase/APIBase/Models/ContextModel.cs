namespace APIBase.Models;

public class ContextModel
{
    public int IDContext
    {
        get;
        set;
    }

    internal int IDModule
    {
        get;
        set;
    }

    public string ContextCaption0
    {
        get;
        set;
    } = "";

    public string ContextUrl
    {
        get;
        set;
    } = "#";

    public string ContextImageUrl
    {
        get;
        set;
    } = "";

    public string ContextTarget
    {
        get;
        set;
    } = "_top";

    public int ItemOrder
    {
        get;
        set;
    } = 0;
}