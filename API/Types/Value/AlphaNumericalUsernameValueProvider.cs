using Fiicode25Auth.API.Types.Value.Abstract;

namespace Fiicode25Auth.API.Types.Value;

public class AlphaNumericalUsernameValueProvider : IUsernameValueProvider
{
    public UsernameValue Create(string value)
    {
        return new AlphaNumericalUsernameValue(_config, value);
    }

    public AlphaNumericalUsernameValueProvider(AlphaNumericalUsernameConfiguration config)
    {
        _config = config;
    }

    private AlphaNumericalUsernameConfiguration _config;
}

