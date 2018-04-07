using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Routing : MonoBehaviour {

	private GameObject route;
	float acceleration,lat,lon;

	// Use this for initialization
	void Start () {
       Input.location.Start ();
	   Input.compass.enabled = true;
	   route=GameObject.FindWithTag("route");
	   var ds= new DataService("LocationSAU.db");
	   var konum=ds.GetLocationNamed(PlayerPrefs.GetString("Location","Konum Bulunamadı"));
	   lat=FindLocationlat(konum);
	   lon=FindLocationlon(konum);
	}
	// Update is called once per frame
	void Update () {
		float degree=Input.compass.trueHeading;
		float getdegree=getDegrees(GPS.Instance.latitude, GPS.Instance.longitude, lat, lon, degree);
		route.transform.rotation= Quaternion.Euler(new Vector3(0, getdegree, 0));
	}
	float FindLocationlat(IEnumerable<Location> loc){
		foreach (var konum in loc) {
		    lat=konum.lat;
		}
		return lat;
	}
	float FindLocationlon(IEnumerable<Location> loc){
		foreach (var konum in loc) {
		    lon=konum.lng;
		}
		return lon;
	}
	float toRad(float degrees) {
		return (float)(degrees * Mathf.PI / 180);
    }
	float getDegrees(float lat1, float lon1, float lat2, float lon2, float headX) {
       float dLat = toRad(lat2-lat1);
       float dLon = toRad(lon2-lon1);
       lat1 = toRad(lat1);
       lat2 = toRad(lat2);
       float y = Mathf.Sin(dLon) * Mathf.Cos(lat2);
       float x = Mathf.Cos(lat1)*Mathf.Sin(lat2) - Mathf.Sin(lat1)*Mathf.Cos(lat2)*Mathf.Cos(dLon);
       float brng = Mathf.Atan2(y, x)*Mathf.Rad2Deg;
       if(brng<0) {
        brng=360-Mathf.Abs(brng);
       }
       return brng - headX;
   }
}
