namespace ServiceScope
{
	public class Operation : IOperationTransient, IOperationScoped, IOperationSingleton
	{
		#region Properties
		public string OperationId { get; }
		#endregion

		#region Constructors
		public Operation()
		{
			this.OperationId = Guid.NewGuid().ToString()[^4..];
		}
		#endregion
	}
}