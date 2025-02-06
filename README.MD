To create an e-SIM (electronic SIM) with C# .NET Core typically involves integrating with specific APIs or services provided by telecom companies, e-SIM technology vendors, or other communication platforms. We need important to understand that e-SIM is primarily a hardware feature for modern devices and involves specialized systems for provisioning, managing, and authenticating SIM profiles.

In C# .NET Core, you might not be directly handling the creation of e-SIM profiles at a low level, but you could interact with relevant APIs for e-SIM activation and management. This may include backend services to facilitate the provisioning and activation process.

Most e-SIM services like GSMA’s e-SIM specifications, they offer APIs for activating, managing, and provisioning e-SIM profiles. 

These typically include:
- Provisioning profiles
    - Load SIM profiles onto devices.
- Activation
    - Activate an e-SIM on a device.
- Authentication
    - Ensure the e-SIM is authentic and secure.

You’ll need to find a service provider offering an API to handle e-SIM provisioning and management, such as mobile network operators, e-SIM management platforms, or cloud services like AWS IoT.

e-SIM profile show the e-SIM details that you are currently working. This might include data like ICCID (Integrated Circuit Card Identifier), IMSI (International Mobile Subscriber Identity), and other telecom-related information.

### Prerequisites
 
We need a few nuget packages.<br />
```
dotnet add package Microsoft.AspNetCore.OpenApi
dotnet add package Microsoft.Newtonsoft.Json
dotnet add package RestSharp
dotnet add package Swashbuckle.AspNetCore
```

### Running Locally

Navigate to the project. 
<br />

Run the web api
<br />
```
dotnet run
```

Check if the web api is running by hitting Health API Endpoint.
<br />
```
curl -X 'GET' \
  'http://localhost:5000/eSim/Health' \
  -H 'accept: */*'
```

Provision an e-Sim Endpoint.
curl -X 'POST' \
  'http://localhost:5000/eSim/provision' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "activationCode": "test 133"
}'
```

Activate an e-Sims API Endpoint.
<br />
```
curl -X 'PUT' \
  'http://localhost:5000/eSim/testEsimID' \
  -H 'accept: */*'
```
