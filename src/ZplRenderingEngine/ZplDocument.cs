using System;
using System.Collections.Generic;
using ZplRenderingEngine.Commands;

namespace ZplRenderingEngine
{
    public class ZplDocument
    {
        #region Private Fields

        private readonly string _zplCode;
        private CommandBuilder _builder = new CommandBuilder();

        #endregion

        #region Public Properties

        public IReadOnlyCollection<string> Errors => _builder.BuildErrors;
        public IReadOnlyCollection<ZplCommand> ZplCommands => _builder.Commands;

        public LabelDpi Dpi { get; set; } = LabelDpi.Dpi203;

        #endregion

        #region Constructors

        public ZplDocument(string zplCode)
        {
            if (string.IsNullOrWhiteSpace(zplCode))
                throw new ArgumentNullException(nameof(zplCode));

            _zplCode = zplCode;
        }

        #endregion

        #region Factory Methods

        public static ZplDocument CreateAndBuild(string zplCode)
        {
            var document = new ZplDocument(zplCode);
            document.Build();

            return document;
        }

        public static ZplDocument CreateAndRender(string zplCode, LabelDpi dpi = LabelDpi.Dpi203)
        {
            var document = CreateAndBuild(zplCode);
            document.Dpi = dpi;

            document.Render();

            return document;
        }

        #endregion

        #region Zpl Methods

        private void Render()
        {
            throw new NotImplementedException();
        }

        public void Build() => _builder.LoadCommands(_zplCode);

        #endregion
    }
}
