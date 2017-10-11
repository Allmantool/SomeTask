namespace Test.Abstract {
    /// <summary>
    /// Abstract factory
    /// </summary>
    public interface ICreator {
        ICmd Build(string[] args);
    }
}