# Chargebee .Net Client Library - API V1

The .Net library for integrating with Chargebee Recurring Billing and Subscription Management solution.

Chargebee now supports two API versions - [V1](https://apidocs.chargebee.com/docs/api/v1) and [V2](https://apidocs.chargebee.com/docs/api). This library is for our <b>older API version V1</b>. The library for V2 can be found in the [master branch](https://github.com/chargebee/chargebee-dotnet). 

You'd want to upgrade to V2 to benefit from the new functionality. Click here for the [API V2 Upgradation Guide](https://apidocs.chargebee.com/docs/api/v1#api-v2-upgradation-guide).

## Installation

Install the latest version of the 1.x.x library with the following commands:

Use NuGet: [NuGet](https://nuget.org) is a package manager for Visual Studio.

To install the ChargeBee .Net Client Library, run the following command in the Package Manager Console:
	
	$ Install-Package ChargeBee -Vesrion 1.x.x

If you would prefer to build it from source, checkout latest version of 1.x.x release tag:
  
    $ git checkout [latest 1.x.x release tag]
  
## Documentation

See our [.Net API Reference](https://apidocs.chargebee.com/docs/api/v1/?lang=dotnet "API Reference").

## Usage

To create a new subscription:
  
    using ChargeBee.Api;
	using ChargeBee.Models;
	ApiConfig.Configure("site","api_key");
	EntityResult result = Subscription.Create()
                  .PlanId("basic")
				  .Request();
	Subscription subscription = result.Subscription;
	Customer customer = result.Customer;

## License

See the LICENSE file.
