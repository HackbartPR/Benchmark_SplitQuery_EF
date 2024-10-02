using BenchmarkDotNet.Attributes;
using Hackbart_EF_Split.Database;
using Microsoft.EntityFrameworkCore;

namespace Hackbart_EF_Split
{
	[MemoryDiagnoser]
	public class EFQueryBenchmark
	{
		private EFContext _context;

		[GlobalSetup]
		public void Setup()
		{
			_context = new EFContext();
		}

		[Benchmark]
		public void QueryWithSplit()
		{
			var customers = _context.Customers
				.Include(c => c.Orders)
				.ThenInclude(o => o.OrderItems)
				.ThenInclude(oi => oi.Product)
				.Take(10)
				.AsSplitQuery()
				.ToList();
		}

		[Benchmark]
		public void QueryWithoutSplit()
		{
			var customers = _context.Customers
				.Include(c => c.Orders)
				.ThenInclude(o => o.OrderItems)
				.ThenInclude(oi => oi.Product)
				.Take(10)
				.ToList();
		}

		[GlobalCleanup]
		public void Cleanup()
		{
			_context.Dispose();
		}
	}
}
