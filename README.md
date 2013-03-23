# ChargeBee .Net Client Library

The .Net library for integrating with ChargeBee Recurring Billing and Subscription Management solution.

## Installation

Install the latest version of the library with the following commands:

	Use NuGet: [NuGet](https://nuget.org) is a package manager for Visual Studio.

	To install the ChargeBee .Net Client Library, run the following command in the Package Manager Console:  
    $ Install-Package ChargeBee

	If you would prefer to build it from source:
  
    $ git clone git@github.com:chargebee/chargebee-dotnet.git
  
## Documentation

See our [.Net API Reference](http://apidocs.chargebee.com/docs/api?lang=dotnet "API Reference").

## Usage

To create a new subscription:
  
    using Chargebee.Api;
	using Chargebee.Models;
	ApiConfig.Configure("site","api_key");
	EntityResult result = Subscription.Create()
                  .PlanId("basic")
				  .Request();
	Subscription subscription = result.Subscription;
	Customer customer = result.Customer;

## License

See the LICENSE file.