using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIAF.InfraStructure.UnitOfWork
{
	public interface IAuditableEntity
	{
		Nullable<int> FKCreatedBy { get; set; }
		DateTime CreatedOn { get; set; }
		Nullable<int> FKModifiedBy { get; set; }
		DateTime ModifiedOn { get; set; }
	}
}
