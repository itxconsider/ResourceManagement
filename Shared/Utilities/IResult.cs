namespace Shared.Utilities
{
    public interface IResult
    {
        List<string> Messages { get; }
        bool IsSuccess { get; set; }
    }
    public interface IResult<out T> : IResult
    {
        T Data { get; }
    }
}
