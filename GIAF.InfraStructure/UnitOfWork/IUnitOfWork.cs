using System;

namespace GIAF.InfraStructure.UnitOfWork
{
	public interface IUnitOfWork : IDisposable
	{
		void Commit();
	}
}
