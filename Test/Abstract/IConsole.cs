namespace Test.Abstract {
    public interface IConsole {
        /// <summary>
        /// Accept string and print
        /// </summary>
        /// <param name="stringStream"></param>
        void PrintOutput(string stringStream);

        /// <summary>
        /// It reads string and return her
        /// </summary>
        string ReadInput();

        //some scenario with exit from console
        bool IsExit();
    }
}
