namespace Hackbart_EF_Split.Entities
{
	public class Customer
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
	}

	public class Order
	{
		public int Id { get; set; }
		public DateTime OrderDate { get; set; }
		public int CustomerId { get; set; }

		public virtual Customer Customer { get; set; } = null!;
		public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
	}

	public class OrderItem
	{
		public int Id { get; set; }
		public int OrderId { get; set; }
		public int ProductId { get; set; }
		public int Quantity { get; set; }
		
		public virtual Order Order { get; set; } = null!;
		public virtual Product Product { get; set; } = null!;
	}

	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public decimal Price { get; set; }

		public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
	}
}
