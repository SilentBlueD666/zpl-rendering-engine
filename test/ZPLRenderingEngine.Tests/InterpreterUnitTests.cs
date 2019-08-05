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
            Assert.Equal("^XA", startCommand.Code);
        }

        [Fact]
        public void Ensure_Last_Command_Is_XZ_Label_End_Command()
        {
            string zpl = "^XA^FO50,50^ADN,36,20^FDSample^FS^XZ";

            var zplDocument = ZplDocument.CreateAndBuild(zpl);
            var lastCommand = zplDocument.ZplCommands.LastOrDefault() as XZ_ZplCommand;

            Assert.True(lastCommand is XZ_ZplCommand);
            Assert.Equal("^XZ", lastCommand.Code);
        }
    }
}
