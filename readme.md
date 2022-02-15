This project aims to create a more simple IBM Client for .NET Core applications/libraries and .NET standard libraries by wrapping the existing .NET standard MQ library from IBM. 

The main aims for this project are:

* Testabilty

* Supply an modern approach for programming client applications for MQ

* Simplyfing the massive set of options for IBM MQ.

### Testability

To improve testability for applications which use IBM MQ, a set of key classes will be wrapped and an interface will be provided to improve overall testability.

### Adapting to the .NET core eco-system

* Options are being passed through `Action<T>` delegates
* The .NET core dependency injection patterns are being implemented
* Using enumerations for the MQC constants to make it more clear what set of options is meant for which purpose.
* Suppling native .NET classes as an alternative (for example using `System.Encoding`  for message encoding and `System.TimeSpan` for passing time spans)

### Readability and documentation

* Options are being documented and made human readible.
* Mutually exclusive options are really mutually exclusive
* Options which are not allowed in conjunction with other related settings are being checked before the call to MQ is being made
* Exceptions will be subclassed and more readable.
