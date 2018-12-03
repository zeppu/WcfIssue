public class Service : IService
{
	public string GetData(string value)
	{
		return "Hello " + value;
	}

	public void GetNothing(string value)
	{
		
	}
}
