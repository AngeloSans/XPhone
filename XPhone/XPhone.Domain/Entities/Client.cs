Clusing System;
using System.ComponentModel.DataAnnotations;


public class Client
{
	[key]
	private int Id { get; set; }

	[Required]
	private string Name { get; set; }

	[Required]
	private string Email { get; set; }

	[Required]
	private bool Fine {  get; set; }

	[Required]
	private double FineAmount { get; set; }

}
