# .NET Client Library for Chargebee API
***

[![NuGet](https://img.shields.io/nuget/v/chargebee.svg?maxAge=3592000)](https://www.nuget.org/packages/ChargeBee/)
and
[![NuGet](https://img.shields.io/nuget/v/chargebee.svg?maxAge=2592000)](https://www.nuget.org/packages/ChargeBee/)

This is the source code for the .NET client library for [Chargebee APIs](https://apidocs.chargebee.com/docs/api?lang=dotnet). The latest version (v3) of the library supports the following:

- .NET Standard 1.2+
- .NET Core 1.0+
- .NET Framework 4.5+

## Library versions
***

The versioning scheme of this library is inspired by [SemVer](https://semver.org/) and the format is `v{MAJOR}.{MINOR}.{PATCH}`. For example, `v3.0.0` and `v2.5.1` are valid library versions.

The following table provides some details for each major version:

| Library major version | Status   | Compatible API versions                                                                                         | **Branch**        |
|----------------------------|----------|-----------------------------------------------------------------------------------------------------------------|---------------|
| v3                         | Active   | [v2](https://apidocs.chargebee.com/docs/api/v2?lang=dotnet) and [v1](https://apidocs.chargebee.com/docs/api/v1?lang=dotnet) | `master`      |
| v2                         | Active   | [v2](https://apidocs.chargebee.com/docs/api/v2?lang=dotnet) and [v1](https://apidocs.chargebee.com/docs/api/v1?lang=dotnet)             | `chargebee-v2`|
| v1                         | Inactive | [v1](https://apidocs.chargebee.com/docs/api/v1?lang=dotnet)                                                                 | `chargebee-v1`|

A couple of terms used in the above table are explained below:
- **Status**: The current development status for the library version. An **Active** major version is currently being maintained and continues to get backward-compatible changes. **Inactive** versions no longer receive any updates.
- **Branch**: The branch in this repository containing the source code for the latest release of the library version. Every version of the library has been [tagged](https://github.com/chargebee/chargebee-dotnet/tags). You can check out the source code for any version using its tag.

🔴 **Attention**: The support for v2 will eventually be discontinued on **December 31st 2023** and will no longer receive any further updates. We strongly recommend [upgrading to v3](https://github.com/chargebee/chargebee-dotnet/wiki/Migration-guide-for-v3) as soon as possible.


**Note:** See the [changelog](CHANGELOG.md) for a history of changes.

## Install the library
***

You can install any release of an **active** library version using [NuGet](https://nuget.org)—a package manager for Visual Studio—by running the following command in the NuGet Package Manager Console:

```shell
$ Install-Package ChargeBee -Version {MAJOR}.{MINOR}.{PATCH}
```
For example, the following commands are valid:

- Install the latest version:
```shell
$ Install-Package ChargeBee -Version 3.0.0
```

- Install an earlier version, say v2.5.1:
```shell
$ Install-Package ChargeBee -Version 2.5.1
```

## Use the library
***
Some examples for using the library are listed below.

### [Create a new subscription](https://apidocs.chargebee.com/docs/api/subscriptions?prod_cat_ver=2&lang=dotnet#create_subscription_for_items)

```cs
using ChargeBee.Api;
using ChargeBee.Models;
ApiConfig.Configure("site","api_key");
EntityResult result = Subscription.Create()
              .PlanId("basic")
              .Request();
Subscription subscription = result.Subscription;
Customer customer = result.Customer;
```

### Serialize an object

```cs
ApiConfig.SerializeObject(obj);
```


### Deserialize an object

```cs
ApiConfig.DeserializeObject<T>(jsonString);
```


## Contribution
***
You may contribute patches to any of the **Active** versions of this library. To do so, raise a PR against the [respective branch](#library-versions).

If you find something amiss, you are welcome to create an [issue](https://github.com/chargebee/chargebee-dotnet/issues).

## API documentation
***

The API documentation for the .NET library can be found in our [API reference](https://apidocs.chargebee.com/docs/api?lang=dotnet).

## License
***
See the [LICENSE](LICENSE).
***

