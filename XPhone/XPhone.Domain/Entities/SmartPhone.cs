using System;
using System.ComponentModel.DataAnnotations;

public class SmartPhone
{
	[Key]
	private Guid _Id { get; set; }

    [Required]
	[StringLength(200)]
	private string _Model { get; set; }

	[Required]
	private double _Price { get; set; }

	[Required]
	private bool _Avaiable { get; set; }

	[Required]
	private string _OperationalSystem { get; set; }

	[Required]
	[Range (1,8)]
	private int _Memory { get; set; }

	[Required]
	[Range (2, 6)]
	private double _Core { get; set; }

	public int StockId { get; set; }
	public virtual Stock Stock { get; set; }

	

}
