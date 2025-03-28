public interface IUsernameConfiguration {}

public class UnconstrainedUsernameConfiguration : IUsernameConfiguration {}

public class AlphaNumericalUsernameConfiguration : IUsernameConfiguration
{
    public bool AllowUnderlineSeparator {get; set;} = true;
    public bool AllowDotSeparator {get; set;} = false;
    public bool AllowDashSeparator {get; set;} = false;

    public bool AllowUppercase {get; set;} = false;
    public bool AllowNumbers {get; set;} = true;

    public int MaximumLength {get; set;} = 15;
    public int MinimumLength {get; set;} = 3;
}
