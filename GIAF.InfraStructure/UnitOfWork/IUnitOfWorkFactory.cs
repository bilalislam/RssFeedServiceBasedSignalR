namespace GIAF.InfraStructure.UnitOfWork
{
	public interface IUnitOfWorkFactory
	{
		IUnitOfWork Create(string factoryKey = null);
		IUnitOfWork GetCurrentUnitofWork(string factoryKey);
	}
}
