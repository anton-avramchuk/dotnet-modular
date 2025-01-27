namespace Dotnet.Modular.Modules.UI
{
    /// <summary>
    /// Interface for transforming framework-agnostic icon names to framework-specific ones
    /// </summary>
    public interface IIconTransformer
    {
        /// <summary>
        /// Transforms a framework-agnostic icon name to a framework-specific one
        /// </summary>
        /// <param name="iconName">Framework-agnostic icon name from FontIcons class</param>
        /// <returns>Framework-specific icon name</returns>
        string Transform(string iconName);
    }
}
