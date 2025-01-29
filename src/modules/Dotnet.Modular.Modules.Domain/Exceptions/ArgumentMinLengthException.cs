namespace Dotnet.Modular.Modules.Domain.Exceptions
{
    public class ArgumentMinLengthException : Exception
    {

        public ArgumentMinLengthException(string name, int length) : base($"Invalid Length of {name}. Min is {length}")
        {
        }
    }
}
