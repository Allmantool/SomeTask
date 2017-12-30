namespace Test.DesignPatterns.UnitTets.Structural_Patterns.Facade.Implementation
{
    public class Programmer
    {
        public void CreateApplication(VisualStudioFacade facade)
        {
            facade.Start();
            facade.Stop();
        }
    }
}
