using System.Data.Entity;

namespace GIAF.InfraStructure.UnitOfWork
{
	public class UnitOfWorkFactory : IUnitOfWorkFactory
	{
		private DbContext context;

		public UnitOfWorkFactory(DbContext dataContext)
		{
			this.context = dataContext;
		}

		public IUnitOfWork Create(string factoryKey = "EFContext.Key")
		{
			if (string.IsNullOrEmpty(factoryKey))
				factoryKey = "EFContext.Key";

			IUnitOfWork uow = this.GetCurrentUnitofWork(factoryKey);
			if (uow == null)
			{
				uow = (IUnitOfWork)new UnitOfWork(this.context);
				this.SetCurrentUnitofWork(factoryKey, uow);
			}
			return uow;
		}

		public IUnitOfWork GetCurrentUnitofWork(string factoryKey = "EFContext.Key")
		{
			if (string.IsNullOrEmpty(factoryKey))
				factoryKey = "EFContext.Key";
			return Local.Data[(object)(factoryKey + "UnitOfWork.Key")] as IUnitOfWork;
		}

		private IUnitOfWork SetCurrentUnitofWork(string factoryKey, IUnitOfWork uow)
		{
			Local.Data[(object)(factoryKey + "UnitOfWork.Key")] = (object)uow;
			return uow;
		}
	}
}
