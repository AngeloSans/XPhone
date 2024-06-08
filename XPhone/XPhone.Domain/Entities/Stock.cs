using System;
using System.ComponentModel.DataAnnotations;

public class Stock
{
	[Key]
	public int Id {  get; set; }

	[Required]
	public int Amount { get; set; }

	public virtual ICollection<SmartPhone> Phones { get; set; }
}
