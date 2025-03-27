# Configuration Reference

Configuration can be provided as detailed in this 
[guide](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-9.0)
from Microsoft. In brief, either specify values in `appsettings.json`, or encode them
in environment variables, using double underscores (`__`) to denote nested objects.

## Example

To enable mandatory email addresses:
- In appsettings.json
```json
{
    "MandatoryFields": {
        "Email": true
    }
}
```
- As an environment variable
```bash
export MANDATORYFIELDS__EMAIL='true'
```

## Reference

In this reference, the nesting of the properties is implied by
their respective headings.

### MandatoryFields
Setting these on will require all newly created users to have
the said property.

#### Username
namespace: [MandatoryFields](#mandatoryfields) \
type: [bool](#bool)

#### Email
namespace: [MandatoryFields](#mandatoryfields) \
type: [bool](#bool)

#### PhoneNumber
namespace: [MandatoryFields](#mandatoryfields) \
type: [bool](#bool)

### DatabaseType
namespace: [MandatoryFields](#mandatoryfields) \
type: [database-type](#database-type)

The database used for credential storing.

### Mongo
If chosen `mongo` for [DatabaseType](#databasetype), you should
specify the connection settings in this namespace.

#### Url
namespace: [Mongo](#mongo) \
type: [string](#string)

#### HostName
namespace: [Mongo](#mongo) \
type: [string](#string) \
warning: this is overshadowed by [Url](#url)

#### Port
namespace: [Mongo](#mongo) \
type: [int](#int) \
warning: this is overshadowed by [Url](#url)

#### User
namespace: [Mongo](#mongo) \
type: [string](#string) \
warning: this is overshadowed by [Url](#url)

#### Password
namespace: [Mongo](#mongo) \
type: [string](#string) \
warning: this is overshadowed by [Url](#url)

#### Database
namespace: [Mongo](#mongo) \
type: [string](#string) \
warning: this is overshadowed by [Url](#url)

### UsernameValidator
type: [username-validator-type](#username-validator-type)

### AlphaNumericalUsername
If chosen `alphanumerical` for [UsernameValidator](#usernamevalidator), you should
specify the connection settings in this namespace.

#### MinimumLength
namespace: [AlphaNumericalUsername](#alphanumericalusername) \
type: [int](#int)

#### MaximumLength
namespace: [AlphaNumericalUsername](#alphanumericalusername) \
type: [int](#int)

#### AllowNumbers
namespace: [AlphaNumericalUsername](#alphanumericalusername) \
type: [bool](#bool)

#### AllowUppercase
namespace: [AlphaNumericalUsername](#alphanumericalusername) \
type: [bool](#bool)

#### AllowDotSeparator
namespace: [AlphaNumericalUsername](#alphanumericalusername) \
type: [bool](#bool)

Allows use of '.' in the middle of an username. No two such separators can
follow one another (be on consecutive positions).

#### AllowDashSeparator
namespace: [AlphaNumericalUsername](#alphanumericalusername) \
type: [bool](#bool)

Same as [AllowDotSeparator](#allow-dot-separator), but for '-'.

#### AllowUnderlineSeparator
namespace: [AlphaNumericalUsername](#alphanumericalusername) \
type: [bool](#bool)

Same as [AllowDotSeparator](#allow-dot-separator), but for '_'.

### PasswordType
type: [bool](#bool)

A choice of:
- `insecure`
    - Stored as plain-text
- `bcrypt`
    - Hashed with the bcrypt algorithm
    - Constrains the password's length and complexity

## Data Types
###### string
###### int
###### bool 
Denoted as {'true', '1', 'yes'} or {'false', '0', 'no'}; case-insensitive
###### database-type
One of: 'inmemory' or 'mongo'; case-insensitive
###### username-validator-type
One of: 'unconstrained' or 'alphanumerical'; case-insensitive
###### password-type
One of: 'insecure' or 'bcrypt'; case-insensitive
