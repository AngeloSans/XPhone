using System;

public class SmartPhone
{
	[key]
	private int Id { get; set; }

	[required]
	private string Model { get; set; }

	[required]
	private double Price { get; set; }

	[required]
	private bool Avaiable { get; set; }

	[required]
	private string OperationalSystem { get; set; }

	[required]
	private int Memory { get; set; }

	[required]
	private double Core { get; set; }

	

}
