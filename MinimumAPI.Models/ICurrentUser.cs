namespace APIBase;

public interface ICurrentUser
{
    string Token { get; set; }

    int GetUser(string token, out string Username);
}