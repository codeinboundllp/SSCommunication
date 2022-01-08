# SSCommunication Module 

## Installation

SSComminications requires [Nuget Package Manger]  to run.
Run this command in the nuget package manager.

```sh
Install-Package SSCommunicationsConfig
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

### For Email Sending Service
Add the following code under in the Startup.cs file
```csharp
public void ConfigureServices(IServiceCollection services)
{
  services.AwsEmailConfigure(Configuration);
}
```
Now you can inject `IEmailService` interface in the constructor of your class of implementation and call the following functions 

```csharp
SendEmailAsync(Uri templateUrl, EmailTemplate? data);
SendEmailAsync(string htmlTemplate, EmailTemplate? data);
```
### For Configuring and using Hosted Services

For Hosted Services and executing a task in background under ConfigureServices in the Startup.cs file
```csharp
public void ConfigureServices(IServiceCollection services)
{
  services.AddBackgroundTaskQueue(Configuration);
}
```
then, inject the hosted services in the constructor of the class to be used in 

```csharp
public XYZ(IBackgroundTaskQueue taskqueue)
{
}
```
finally 
```csharp
Func<Task<T>> fn = ()=>{ //any task to be executed};
taskqueue.QueueBackgroundWorkItem(fn);
```



