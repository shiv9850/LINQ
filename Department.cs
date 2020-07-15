using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ
{
	public class Department
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public Department(long Id, string Name)
		{
			this.Id = Id;
			this.Name = Name;
		}

		public override string ToString()
		{
			return $"ID :{this.Id},	Department Name :{this.Name}";
		}
	}
}
