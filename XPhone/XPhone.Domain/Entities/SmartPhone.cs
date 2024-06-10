using System;
using System.ComponentModel.DataAnnotations;
using XPhone.Domain.Entities;

public class SmartPhone
{
	[Key]
	public Guid Id { get; set; }

    [Required]
	[StringLength(200)]
	public string Model { get; set; }

	[Required]
	public double Price { get; set; }

	[Required]
	public bool Avaiable { get; set; }

	[Required]
	public string OperationalSystem { get; set; }

	[Required]
	[Range (1,8)]
	public int Memory { get; set; }

	[Required]
	[Range (2, 6)]
	public double Core { get; set; }

	public int StockId { get; set; }
	public virtual Stock Stock { get; set; }

	public virtual ICollection<Rent> Rents { get; set; }

	

}
