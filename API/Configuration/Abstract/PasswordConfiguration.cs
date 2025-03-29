public interface IPasswordConfiguration {}

public class InsecurePasswordConfiguration : IPasswordConfiguration
{}

public class BcryptHashedPasswordConfiguration : IPasswordConfiguration
{}
