using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearByLocation {
	public string name { get; set; }
	public string km{get; set;}
    
	public NearByLocation(string isim, string uzaklik){
		this.name=isim;
		this.km=uzaklik;
	}
}
