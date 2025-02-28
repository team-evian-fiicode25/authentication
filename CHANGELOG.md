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
Functionally:
    - Added minimal support for phone numbers and email addresses
    - Added errors for missing arguments, duplicate fields
    - Added support for configuring required fields 

Also refactored all API layer classes to use composition and
allow for easy DI. This will permit to conditionally DI some
different implementations depending on the app's configuration.
