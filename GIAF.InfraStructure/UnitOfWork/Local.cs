using System;
using System.Collections;

namespace GIAF.InfraStructure.UnitOfWork
{
	public static class Local
	{
		private static readonly ILocalData data = (ILocalData)new Local.LocalData();

		public static ILocalData Data
		{
			get
			{
				return Local.data;
			}
		}

		static Local()
		{
		}

		private class LocalData : ILocalData
		{
			private static readonly object LocalDataHashtableKey = new object();

			[ThreadStatic]
			private static Hashtable localData;

			public int Count
			{
				get
				{
					return Local.LocalData.LocalHashtable.Count;
				}
			}

			private static Hashtable LocalHashtable
			{
				get
				{
					if (Local.LocalData.localData == null)
						Local.LocalData.localData = new Hashtable();
					return Local.LocalData.localData;
				}
			}

			public object this[object key]
			{
				get
				{
					return Local.LocalData.LocalHashtable[key];
				}
				set
				{
					Local.LocalData.LocalHashtable[key] = value;
				}
			}

			static LocalData()
			{
			}

			public void Clear()
			{
				Local.LocalData.LocalHashtable.Clear();
			}
		}
	}
}
