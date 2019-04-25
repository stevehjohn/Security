namespace Security.Random
{
    public interface IRng
    {
        byte[] GetBytes(int length);
    }
}