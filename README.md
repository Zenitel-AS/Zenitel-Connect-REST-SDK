# ZenitelConnectWampSdk

This solution creates a GUI which - by means of the SDK - is able to setup up commands and monitor the Zenitel Connect Devices.
The communication with the Zenitel Connect is established using the REST API protocol.


Documentation for the WampClient can be in /DOC/Help/ Zenitel.Connect.Wamp.Sdk.chm

The solution file  ZenitelConnectWampSdk.sln will setup the solution in VS2019 for compiling the SDK.

The solution file ZenitelConnectWampSdkSetup.sln will also include a project for generating a msi package the SDK.
This poses an alternative way of dristribution of the SDK. 

The packages.zip is a packed file with all packages from the “packages”-directory. This zip file is included in the msi package.
