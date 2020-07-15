using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ
{
	internal class Employee
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public long DeptId { get; set; }

		public Employee(long Id, string Name, long DeptId)
		{
			this.Id = Id;
			this.Name = Name;
			this.DeptId = DeptId;
		}

		public override string ToString()
		{
			return $"ID :{this.Id},	Employee Name :{this.Name},	DepartmentId : {this.DeptId}";
		}
	}
}
