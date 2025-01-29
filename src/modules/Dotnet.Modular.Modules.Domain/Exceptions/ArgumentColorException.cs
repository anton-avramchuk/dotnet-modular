namespace Dotnet.Modular.Modules.Domain.Exceptions
{
    public class ArgumentColorException : Exception
    {
        public ArgumentColorException(string parameterName) : base($"\"Color must be a valid hex value.\", {parameterName}")
        {

        }
    }
}
