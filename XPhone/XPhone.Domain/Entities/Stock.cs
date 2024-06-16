using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Stock
{
	[Key]
	public Guid Id {  get; set; }

	[Required]
	public string stockName { get; set; }

	public int Amount { get; set; }

	[JsonIgnore]
	public virtual ICollection<SmartPhone> Phones { get; set; }
}
