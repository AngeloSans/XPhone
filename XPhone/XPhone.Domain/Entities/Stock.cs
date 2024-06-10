using System;
using System.ComponentModel.DataAnnotations;

public class Stock
{
	[Key]
	public Guid Id {  get; set; }

	[Required]
	public int Amount { get; set; }

	public virtual ICollection<SmartPhone> Phones { get; set; }
}
