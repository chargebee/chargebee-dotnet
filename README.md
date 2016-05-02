# Chargebee .Net Client Library - API V2

[![NuGet](https://img.shields.io/nuget/v/chargebee.svg?maxAge=2592000)](https://www.nuget.org/packages/ChargeBee/)

This is the .NET Library for integrating with Chargebee. Sign up for a Chargebee account [here](https://www.chargebee.com).

Chargebee now supports two API versions - [V1](https://apidocs.chargebee.com/docs/api/v1) and [V2](https://apidocs.chargebee.com/docs/api), of which V2 is the latest release and all future developments will happen in V2. This library is for <b>API version V2</b>. If you’re looking for V1, head to [chargebee-v1 branch](https://github.com/chargebee/chargebee-dotnet/tree/chargebee-v1).

## Installation

Install the latest version of the 2.x.x library with the following commands:

Use NuGet: [NuGet](https://nuget.org) is a package manager for Visual Studio.

To install the ChargeBee .Net Client Library, run the following command in the Package Manager Console:
	
	$ Install-Package ChargeBee -Vesrion 2.x.x

If you would prefer to build it from source, checkout latest version of 2.x.x release tag:
  
    $ git checkout [latest 2.x.x release tag]
  
## Documentation

See our [.Net API Reference](https://apidocs.chargebee.com/docs/api?lang=dotnet "API Reference").

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
