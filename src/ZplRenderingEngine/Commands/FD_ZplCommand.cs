namespace ZplRenderingEngine.Commands
{
    public class FD_ZplCommand : ZplFieldCommand
    {
        public FD_ZplCommand(string parameterData) 
            : base("^FD", parameterData)
        {
        }
    }
}
