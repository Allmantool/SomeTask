namespace Test.DesignPatterns.UnitTets.Structural_Patterns.Facade.Implementation
{
    public class VisualStudioFacade
    {
        private readonly TextEditor _textEditor;
        private readonly Compiller _compiller;
        private readonly CLR _clr;
        public VisualStudioFacade(TextEditor te, Compiller compil, CLR clr)
        {
            this._textEditor = te;
            this._compiller = compil;
            this._clr = clr;
        }
        public void Start()
        {
            _textEditor.CreateCode();
            _textEditor.Save();
            _compiller.Compile();
            _clr.Execute();
        }
        public void Stop()
        {
            _clr.Finish();
        }
    }
}
