using Fiicode25Auth.API.Exceptions;
using Fiicode25Auth.API.Types.Value.Abstract;

namespace Fiicode25Auth.API.Types.Value;

public class AlphaNumericalUsernameValue : UsernameValue
{
    private AlphaNumericalUsernameConfiguration _config;
    private string _value;
    public override string Value
    {
        get => _value;
        protected set
        {
            if (value.Length < _config.MinimumLength)
                throw new UsernameFormatException($"Username smaller than the minimum required size of {_config.MinimumLength}");

            if (value.Length > _config.MaximumLength)
                throw new UsernameFormatException($"Username smaller than the minimum required size of {_config.MaximumLength}");

            foreach (var (idx, ch) in value.Select((ch, i) => (i, ch)))
            {
                if (!_characterSet.Contains(ch) && !_separators.Contains(ch))
                {
                    throw new UsernameFormatException($"Invalid character '{ch}' in username at position {idx}");
                }
            }

            if (Enumerable.Range('0', 10).Contains(value.First()))
                throw new UsernameFormatException("Username cannot begin with a digit");

            if (_separators.Contains(value.First()))
                throw new UsernameFormatException($"Username cannot begin with '{value.First()}'");

            if (_separators.Contains(value.Last()))
                throw new UsernameFormatException($"Username cannot end with '{value.Last()}'");

            for (var i = 0; i + 1 < value.Length; i++)
            {
                if (_separators.Contains(value[i]) && _separators.Contains(value[i + 1]))
                {
                    throw new UsernameFormatException($"Cannot have '{value[i]}' and '{value[i + 1]}' together (on consecutive positions)");
                }
            }

            _value = value;
        }
    }

    public AlphaNumericalUsernameValue(AlphaNumericalUsernameConfiguration config, string value)
    {
        _config = config;
        _value = "";
        Value = value;
    }

    private string? _characterSetCache;
    private string _characterSet
    {
        get
        {
            if (_characterSetCache != null)
                return _characterSetCache;

            var lowercaseChars = Enumerable
                .Range('a', 'z' - 'a' + 1)
                .Select(c => (char)c);

            var result = lowercaseChars;


            if (_config.AllowUppercase)
            {
                var uppercaseChars = Enumerable
                    .Range('A', 'Z' - 'A' + 1)
                    .Select(c => (char)c);

                result = result.Concat(uppercaseChars);
            }

            if (_config.AllowNumbers)
            {
                var digits = Enumerable
                    .Range('0', 10)
                    .Select(c => (char)c);

                result = result.Concat(digits);
            }

            return _characterSetCache = string.Join("", result);
        }
    }
    private string _separators
    {
        get
        {
            var separators = new List<char>();

            if (_config.AllowDashSeparator)
                separators.Add('-');

            if (_config.AllowDotSeparator)
                separators.Add('.');

            if (_config.AllowUnderlineSeparator)
                separators.Add('_');

            return string.Join("", separators);
        }
    }
}

