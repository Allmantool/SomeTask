namespace Test.Abstract {
    /// <summary>
    /// Some command that spider can execude
    /// </summary>
    public interface ICmd {
        /// <summary>
        /// Proccess the command and return result
        /// </summary>
        /// <returns></returns>
        string Run();
    }
}