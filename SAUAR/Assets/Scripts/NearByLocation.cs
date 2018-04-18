using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearByLocation {
	public string name { get; set; }
	public float km{get; set;}
    
	public NearByLocation(string isim, float uzaklik){
		this.name=isim;
		this.km=uzaklik;
	}
}
