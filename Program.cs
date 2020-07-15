using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
		static Employee[] employees = {
						new Employee(1,"Shiv",11),
						new Employee(2,"Amol",11),
						new Employee(3,"Deepak",11),
						new Employee(4,"Rashid",11),
						new Employee(5,"Vaibhav",22),
						new Employee(6,"Ganesh",22)
					  };

		static Department[] departments = {
							new Department(11,"Development"),
							new Department(22,"HR")
							};



		static IEnumerable<Employee> query = Enumerable.Empty<Employee>();
		static string headerMessage = "LINQ";
		static void Print<T>(IEnumerable<T> collection) => Print(collection, headerMessage);

		static void Print<T>(IEnumerable<T> collection, string message = "LINQ")
		{

			Console.WriteLine($"------------------{message}----------------");
			if (typeof(T).IsValueType)
			{
				foreach (var item in collection)
					Console.WriteLine(item);
			}
			else
			{
				foreach (var item in collection)
					Console.WriteLine(item.ToString());
			}


		}
		static void Main(string[] args)
        {
			headerMessage = "Where";
			query = employees.Where(item => item.DeptId == 11);
			Program.Print(query);


			//-----------------OfType---------------------
			ArrayList arrayList = new ArrayList() ;
			arrayList.AddRange(employees);
			arrayList.Add("Test Element");
			headerMessage = "OfType ";
			var stringValues = arrayList.OfType<string>();
            Print(stringValues);

			//-----------------oderBy---------------------
			headerMessage = "OderBy ";
			query = employees.OrderBy(item => item.Name);
			Print(query);

			headerMessage = "OrderByDescending";
			query = employees.OrderByDescending(item => item.Name);
			Print(query);


			//---------GropBy-------

			var employeesByDepartment = employees.GroupBy(item => item.DeptId);
			foreach (var group in employeesByDepartment)
			{
				headerMessage = $"GroupBy for Department : {group.Key}";
				Print(group);
			}

			//---------ToLookUp--------
			var employeesByDepartment1 = employees.ToLookup(item => item.DeptId);
			foreach (var group in employeesByDepartment1)
			{
				headerMessage = $"Lookup for Department : {group.Key}";
				Print(group);
			}

			//-----------Join---------

			var deparmentNames = employees.Join(departments, emp => emp.DeptId, dept => dept.Id, (emp, dept) => dept.Name);
			headerMessage = "Join";
			Print(deparmentNames);

			//---Distinct
			var distinctDepartment = deparmentNames.Distinct();
			headerMessage = "Distinct";
			Print(distinctDepartment);


			//-------Select-----
			var employeeNames = employees.Select(item => item.Name);
			headerMessage = "Select";
			Print(employeeNames);

			//------Any----
			bool employeeExist = employees.Any(item => item.Name == "Shiv");
			Console.WriteLine("Any check where predigate matches or not");


			//--------------------------------------------------------------------------------------------------------------------------------------------
			int[] collection1 = { 1, 2, 3, 4, 5 };
			int[] collection2 = { 4, 5, 6, 7, 8 };

			//-----------Except---------
			var exceptResult = collection1.Except(collection2);
			headerMessage = "Except";
			Print(exceptResult);

			//-----------Intersect---------
			var intersectResult = collection1.Intersect(collection2);
			headerMessage = "Intersect";
			Print(intersectResult);

			//-----------Union---------
			var unionResult = collection1.Union(collection2);
			headerMessage = "Union";
			Print(unionResult);

			//------Skip-------
			var skipResult = collection1.Skip(2);
			headerMessage = "Skip";
			Print(skipResult);


			//------SkipWhile-------
			var skipWhileResult = collection1.SkipWhile(item => item < 3);
			headerMessage = "SkipWhile";
			Print(skipWhileResult);


			//------Take-------
			var takeResult = collection1.Take(2);
			headerMessage = "Take";
			Print(takeResult);


			//------takeWhile-------
			var takeWhileResult = collection1.TakeWhile(item => item <= 3);
			headerMessage = "TakeWhile";
			Print(takeWhileResult);

			//--------Average-----
			var avg = collection1.Average();
			Console.WriteLine($"Average : {avg}");

			//------Count----
			var count = collection1.Count(item => item > 2);
			Console.WriteLine($"Count : {count}");

			//--------Max------------
			var maxValue = collection1.Max();
			Console.WriteLine($"maxValue : {maxValue}");

			//-----------Sum---------
			var sum = collection1.Sum();
			Console.WriteLine($"Summation : {sum}");

			//--------END------
			Console.ReadLine();
		}
	}
}
