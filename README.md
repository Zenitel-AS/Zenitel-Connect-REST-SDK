# ZenitelConnectRestSdk

This solution creates a GUI which - by means of the SDK - is able to setup up commands and monitor the Zenitel Connect Devices.
The communication with the Zenitel Connect is established using the REST API protocol.


Documentation for the RestApiClient can be in /DOC/Help/ Zenitel.Connect.RestApi.Sdk.chm

The solution file  ZenitelConnectRestApiSdk.sln will setup the solution in VS2019 for compiling the SDK.

The solution file ZenitelConnectRestApiSdkSetup.sln will also include a project for generating a msi package the SDK.
This poses an alternative way of distribution of the SDK. 

The packages.zip is a packed file with all packages from the “packages”-directory. This zip file is included in the msi package.
