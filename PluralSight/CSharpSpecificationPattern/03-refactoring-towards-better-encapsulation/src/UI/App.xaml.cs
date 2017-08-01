using Logic.Utils;

namespace UI
{
    public partial class App
    {
        public App()
        {
            Initer.Init(@"Server=.\Sql;Database=SpecPatternRefactored;Trusted_Connection=true;");
        }
    }
}
