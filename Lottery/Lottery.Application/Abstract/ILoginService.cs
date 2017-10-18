namespace Lottery.Application.Abstract
{
    public interface ILoginService
    {
        bool LogIn(string username, string password);
    }
}
