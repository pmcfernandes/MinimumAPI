namespace APIBase.Models;

public class ModuleModel
{
    public int IDModule 
    { 
        get;
        set; 
    }

    public string ModuleCaption0
    {
        get;
        set;
    } = "";

    public int ItemOrder
    {
        get;
        set;
    } = 0;

    public List<ContextModel> Contexts
    {
        get;
        private set;
    } = new List<ContextModel>();
}
