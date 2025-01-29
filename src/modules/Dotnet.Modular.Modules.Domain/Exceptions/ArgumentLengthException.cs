namespace Dotnet.Modular.Modules.Domain.Exceptions
{
    public class ArgumentLengthException : Exception
    {

        public ArgumentLengthException(string name, int length) : base($"Invalid Length of {name}. MaxLength is {length}")
        {
            Name = name;
            Length = length;
        }

        public string Name { get; private set; }

        public int Length { get; private set; }


    }
}
