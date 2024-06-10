namespace program;

public interface IUserBehavior
{
    public  Task Post(string mensaje, string usuario);
    public Task Follow(string follower, string followed);
    public Task Dashboard();
}