﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName = "IService")]
public interface IService
{

	[System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/GetData", ReplyAction = "http://tempuri.org/IService/GetDataResponse")]
	string GetData(string value);

	[System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/GetData", ReplyAction = "http://tempuri.org/IService/GetDataResponse")]
	System.Threading.Tasks.Task<string> GetDataAsync(string value);

	[System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/GetNothing", ReplyAction = "http://tempuri.org/IService/GetNothingResponse")]
	void GetNothing(string value);

	[System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/GetNothing", ReplyAction = "http://tempuri.org/IService/GetNothingResponse")]
	System.Threading.Tasks.Task GetNothingAsync(string value);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IServiceChannel : IService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class MyServiceClient : System.ServiceModel.ClientBase<IService>, IService
{

	public MyServiceClient()
	{
	}

	public MyServiceClient(string endpointConfigurationName) :
			base(endpointConfigurationName)
	{
	}

	public MyServiceClient(string endpointConfigurationName, string remoteAddress) :
			base(endpointConfigurationName, remoteAddress)
	{
	}

	public MyServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
			base(endpointConfigurationName, remoteAddress)
	{
	}

	public MyServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
			base(binding, remoteAddress)
	{
	}

	public string GetData(string value)
	{
		return base.Channel.GetData(value);
	}

	public System.Threading.Tasks.Task<string> GetDataAsync(string value)
	{
		return base.Channel.GetDataAsync(value);
	}

	public void GetNothing(string value)
	{
		base.Channel.GetNothing(value);
	}

	public System.Threading.Tasks.Task GetNothingAsync(string value)
	{
		return base.Channel.GetNothingAsync(value);
	}
}