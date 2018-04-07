using SQLite4Unity3d;

public class Location {

	[PrimaryKey, AutoIncrement]
	public int id { get; set; }
	public string name { get; set; }
	public float lat{get;set;}
	public float lng{get;set;}
	
}
