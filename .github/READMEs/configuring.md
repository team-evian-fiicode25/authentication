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

## ⚠️ Important Caveat
In order to specify a type with no children properties, or, in another 
case, to leave all its properties as default, set its respective property
to a primitive, such as "1". Setting it to an empty JSON object will not 
work.

## Root Properties Index
- [MandatoryFields](#mandatoryfields)
- [Database](#database)
- [UsernameValidator](#usernamevalidator)
- [Password](#password)

## Reference

### MandatoryFields
Setting these on will require all newly created users to have
the said property.

| Property    | Type | Default | Description                                    |
|-------------|------|---------|------------------------------------------------|
| Username    | bool | false   | Whether to require the username credential     |
| Email       | bool | false   | Whether to require the email credential        |
| PhoneNumber | bool | false   | Whether to require the phone number credential |

### Database
This must have exactly one child property, that being the
configuration for a database used to store all the login
credentials.

Unless this property is specified, the default in-memory
provider will be used.

| Property | Type                                                                                                      | Description                                                                             |
|----------|-----------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------|
| InMemory | [InMemoryConfiguration](#inmemoryconfiguration)                                                           | Data is stored in arrays, no persistance exists, data being lost after the process ends |
| Mongo    | [MongoIndividualVariables](#mongoindividualvariables)  \| [MongoConnectionString](#mongoconnectionstring) | MongoDB provider                                                                        |

#### InMemoryConfiguration
This type has no child properties.

#### MongoIndividualVariables
Settings for a MongoDB connection.

| Property | Type   | Default          | Description                                   |
|----------|--------|------------------|-----------------------------------------------|
| HostName | string | -                | The hostname portion of the connection string |
| Port     | int    | 27017            | The port portion of the connection string     |
| User     | string | "admin"          | The user portion of the connection string     |
| Password | string | -                | The password portion of the connection string |
| Database | string | "authentication" | The database portion of the connection string |

#### MongoConnectionString
Specifies a MongoDB connection by its respective connection string.

| Property | Type   | Description           |
|----------|--------|-----------------------|
| Url      | string | The connection string |

### UsernameValidator
This must have exactly one child property, that being the
validator used for usernames.

Unless this property is specified, the default AlphaNumerical
validator will be used.

| Property       | Type                                                                | Description                                                            |
|----------------|---------------------------------------------------------------------|------------------------------------------------------------------------|
| Unconstrained  | [UnconstrainedUsernameValidator](#unconstrainedusernamevalidator)   | No username validation whatsoever                                      |
| AlphaNumerical | [AlphaNumericalUsernameValidator](#alphanumericalusernamevalidator) | Configurable username validator. More details in the type's reference. |

#### UnconstrainedUsernameValidator
This type has no child properties.

#### AlphaNumericalUsernameValidator
Configuration for a kind of username validator that
places the following constraints.
- A minimum and maximum length
- The character set used
- Usernames must start with a letter
- Optionally, special separator characters can be 
used (such as '_', '-', '.'), but they must no
be neither in the beginning, nor the end of the
username; nor can two of these caracters be on
consecutive positions in the username.

| Property                | Type | Default | Description                                    |
|-------------------------|------|---------|------------------------------------------------|
| MinimumLength           | int  | 3       | The minimum allowed username length            |
| MaximumLength           | int  | 15      | The maximum allowed username length            |
| AllowUppercase          | bool | false   | Whether to allow [A-Z] characters              |
| AllowNumbers            | bool | true    | Whether to allow [0-9] characters              |
| AllowUnderlineSeparator | bool | true    | Whether to allow the use of '_' as a separator |
| AllowDashSeparator      | bool | false   | Whether to allow the use of '-' as a separator |
| AllowDotSeparator       | bool | false   | Whether to allow the use of '.' as a separotor |

### Password
This must have exactly one child property, that being the
configuration for a password manager.

Unless this property is specified, the default Bcrypt
password manager will be used.

| Property | Type                                          | Description                                                     |
|----------|-----------------------------------------------|-----------------------------------------------------------------|
| Insecure | [InsecurePassword](#insecurepassword)         | All passwords are allowed and stored in plain-text              |
| Bcrypt   | [BcryptHashedPassword](#bcrypthashedpassword) | Bcrypt hashed passwords with length and complexity requirements |

#### InsecurePassword
This type has no child properties.

#### BcryptHashedPassword
This type has no child properties.
