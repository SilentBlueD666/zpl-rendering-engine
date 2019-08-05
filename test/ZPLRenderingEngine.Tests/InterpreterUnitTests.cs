using System.Linq;
using Xunit;
using ZplRenderingEngine.Commands;

namespace ZplRenderingEngine.Tests
{
    public class InterpreterUnitTests
    {
        [Fact]
        public void Ensure_First_Command_Is_XA_Label_Start_Command()
        {
            string zpl = "^XA^FO50,50^ADN,36,20^FDSample^FS^XZ";
            var zplDocument = ZplDocument.CreateAndBuild(zpl);

            var startCommand = zplDocument.ZplCommands.FirstOrDefault() as XA_ZplCommand;

            Assert.True(startCommand is XA_ZplCommand);
        }
    }
}
