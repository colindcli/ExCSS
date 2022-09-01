namespace ExCSS
{
    internal sealed class NumberToken : Token
    {
        private static readonly char[] FloatIndicators = { '.', 'e', 'E' };

        public NumberToken(string number, TextPosition position)
            : base(TokenType.Number, number, position)
        {
        }

        public bool IsInteger => Data.IndexOfAny(FloatIndicators) == -1;

        public long IntegerValue => long.TryParse(Data, out var v) ? v : 9999999999;

        public float Value => float.TryParse(Data, out var val) ? val : 9999999999;
    }
}