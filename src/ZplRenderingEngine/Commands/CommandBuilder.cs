using System.Collections.Generic;

namespace ZplRenderingEngine.Commands
{
    public class CommandBuilder
    {
        #region Fields

        private readonly static char[] _cmdPrefix = new char[] { '^', '~' };
        private List<ZplCommand> _zplCommands = new List<ZplCommand>(100);
        private List<string> _buildErrors = new List<string>(10);

        #endregion

        #region Public Properties

        public IReadOnlyCollection<string> BuildErrors => _buildErrors;
        public IReadOnlyCollection<ZplCommand> Commands => _zplCommands;

        #endregion

        #region Command Builder Methods

        public void LoadCommands(string zplCode)
        {
            _zplCommands.Clear();
            _buildErrors.Clear();

            int index = -1;

            while (zplCode.Length >= index + 1 && (index = zplCode.IndexOfAny(_cmdPrefix, index + 1)) >= 0)
            {
                int end = zplCode.IndexOfAny(_cmdPrefix, index + 1);
                if (end == -1) end = zplCode.Length;

                string command;
                string parameters;
                string commandToken = zplCode.Substring(index, end - index);

                if (commandToken.Length <= 1)
                    continue;

                if (commandToken[0] == '^' && (commandToken[1] == 'a' || commandToken[1] == 'A') && commandToken.Length > 2 && (commandToken[2] != '@'))
                {
                    command = commandToken.Substring(0, 2);
                    parameters = commandToken.Substring(2);
                }
                else
                {
                    if (commandToken.Length >= 3)
                    {
                        command = commandToken.Substring(0, 3);
                        parameters = commandToken.Substring(3);
                    }
                    else
                    {
                        command = commandToken;
                        parameters = string.Empty;
                    }
                }
                CreateCommand(command, parameters);
            }
        }

        private void CreateCommand(string command, string parameters)
        {
            switch (command)
            {
                case "^FD": _zplCommands.Add(new FD_ZplCommand(parameters)); break; // Field Data (Field)
                case "^XA": _zplCommands.Add(new XA_ZplCommand()); break; // Start Format (Others)
                case "^XZ": _zplCommands.Add(new XZ_ZplCommand()); break;// End Format (Others)
                default:
                    _buildErrors.Add($"Skipped {command}:{parameters} as not supported");
                    break;
            }
        }

        #endregion
    }
}
