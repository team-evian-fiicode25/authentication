# v0.1.0
Boilerplate-full proof of concept implementation featuring:
- Database access layer and a mock in memory implementation
- Sample GraphQL API
- Configuration class
- Minimal types for querying and modifying the login collection
    - this includes hashing of passwords

# v0.2.0-test1
This is a test for the automatic publishing to the Docker registry

# v0.2.0
* Added automatic publishing to the Docker registry

# v0.3.0
#### Functionally:
- Added minimal support for phone numbers and email addresses
- Added errors for missing arguments, duplicate fields
- Added support for configuring required fields 

Also refactored all API layer classes to use composition and
allow for easy DI. This will permit to conditionally DI some
different implementations depending on the app's configuration.

# v0.4.0
Functionalities:
- Added authentication sessions
- Added login sessions
- Added option to query Logins by many other means other than id

Fixes:
- Fixed typo in docstring
- Fixed issue when updating Logins (it no longer tries to
create instead of update when commiting an existing object)
- Fixed 2FA email/phone object being created with unverified 
email/phone

Refactors:
- Refactorerd struct DBObject types into ref type classes
- Refactored all logic in Query/Mutation object into separate
service
- Other small refactors

# v0.4.1
* Refactor DI into extension methods
* Update IRepositories to enable different types for reading/writing
    * This simplifies the updated mock in-memory implementation
    * This also makes said implementation less 'hackish' and work
    more similar to the proper one

# v0.5.0
Added a MongoDB implementation

# v0.6.0
- Added phone number verification
- Added Docker entrypoint to simplify schema retrieval

# v0.7.0
- Updated README
- Added validation for the email field
- Overhauled configuration options
    - Also added a reference file for the configuration
- Added configurable username validator
- Added option to configure insecure plain-text passwords
    - Updated the default hashed password to also enforce
    its length and complexity
- Now using CSPRNG instead of insecure Random class

# v0.7.1
- Fixed an issue where insecure passwords were used regardless 
of the specified configuration
- Reduce the minimum size of a bcrypt hashed password to 8
characters

# v0.8.0-msg-integration-test2
Add a more refined verification support

