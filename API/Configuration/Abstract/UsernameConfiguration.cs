public interface IUsernameConfiguration {}

public class UnconstrainedUsernameConfiguration : IUsernameConfiguration {}

public class AlphaNumericalUsernameConfiguration : IUsernameConfiguration
{
    public bool AllowUnderlineSeparator {get; set;}
    public bool AllowDotSeparator {get; set;}
    public bool AllowDashSeparator {get; set;}

    public bool AllowUppercase {get; set;}
    public bool AllowNumbers {get; set;}

    public int MaximumLength {get; set;}
    public int MinimumLength {get; set;}
}
