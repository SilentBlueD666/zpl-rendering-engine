namespace ZplRenderingEngine.Commands
{
    public abstract class ZplCommand
    {
        #region Fields

        private readonly string _commandString;
        private readonly string _code;
        private readonly string _parameterData;

        #endregion

        public ZplCommand(string code, string parameterData)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new System.ArgumentNullException(nameof(code));

            _code = code;
            _parameterData = parameterData;
            _commandString = $"{code}{parameterData}";
        }


        #region Public Properties

        public virtual string Code => _code;

        public virtual string ParameterData => _parameterData;

        #endregion

        #region ToString Methods

        public override string ToString() => _commandString;

        #endregion
    }
}
