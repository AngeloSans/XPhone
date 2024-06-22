using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using XPhone.Domain.Entities;
using XPhone.Domain.Entities.DTO;

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

	public Guid StockId { get; set; }

	[ForeignKey("StockId")]
	public virtual Stock Stock { get; set; }

    public List<SmartPhoneDTO> Select(Func<object, SmartPhoneDTO> value)
    {
        throw new NotImplementedException();
    }
}
