# SSComminications Module

## Installation

SSComminications requires [Nuget Package Manger]  to run.
Run this command in the nuget package manager.

```sh
Install-Package SSCommunications
```
## Configuration
Add the following in the AppSettings.json file.

```sh
"SSCommunications":{
    "AwsConfiguration":{
        "AccessKey":"Your Access Key",
        "SecretKey":"Your Secret Key",
        "Region":"Aws Region"
    }
}
```
## Usage

Add the following code under in the Startup.cs file
```sh
public void ConfigureServices(IServiceCollection services)
{
  services.AwsEmailConfigure(Configuration);
}
```
Now you can inject `IEmailService` interface in the constructor of your class of implementation and call the following functions 

```sh
SendEmailAsync(Uri templateUrl, EmailTemplate? data);
SendEmailAsync(string htmlTemplate, EmailTemplate? data);
```

