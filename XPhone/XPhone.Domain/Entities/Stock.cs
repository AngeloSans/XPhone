using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using XPhone.Domain.Entities.DTO;

public class Stock
{
	[Key]
	public Guid Id {  get; set; }

	[Required]
	public string stockName { get; set; }

	public int Amount { get; set; }

	
	public virtual ICollection<SmartPhone> Phones { get; set; }

    public object Select(Func<object, StockDTO> value)
    {
        throw new NotImplementedException();
    }
}
