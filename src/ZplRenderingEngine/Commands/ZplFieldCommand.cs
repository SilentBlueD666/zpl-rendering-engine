namespace ZplRenderingEngine.Commands
{
    public abstract class ZplFieldCommand : ZplCommand
    {
        public ZplFieldCommand(string code, string parameterData) 
            : base(code, parameterData)
        {
        }
    }
}
