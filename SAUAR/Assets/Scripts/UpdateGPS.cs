using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpdateGPS : MonoBehaviour {

    public Text coordinates,kmdata;
    public RawImage image;
	float distanceKM,lat,lon;
	void Start(){
		Screen.orientation = ScreenOrientation.Portrait;
        var ds= new DataService("LocationSAU.db");
		var konum=ds.GetLocationNamed(PlayerPrefs.GetString("Location","Konum Bulunamadı"));
		lat=FindLocationlat(konum);
		lon=FindLocationlon(konum);
		float acceleration = Mathf.Abs(Input.acceleration.y);
		coordinates.enabled=false;
		image.enabled=false;
		kmdata.enabled=false;
		if(acceleration>=0.5){
			showKM();
		}
	    else if(acceleration<0.5){
			coordinates.enabled=false;
		    image.enabled=false;
		    kmdata.enabled=false;
		}
	}
	void Update () {
		Screen.orientation = ScreenOrientation.Portrait;
		float acceleration = Mathf.Abs(Input.acceleration.y);
		if(Input.GetKeyDown(KeyCode.Escape)){
           SceneManager.LoadScene(1); 
		}
		if(acceleration>=0.5){
			showKM();
		}
	    else if(acceleration<0.5){
			coordinates.enabled=false;
		    image.enabled=false;
		    kmdata.enabled=false;
		}
	}
	float degreesToRadians(float degrees) {
		return (float)(degrees * Mathf.PI / 180);
    }
	float distanceInKmBetweenEarthCoordinates(float lat1, float lon1, float lat2, float lon2) {
         float earthRadiusKm = 6371;
         float dLat = degreesToRadians(lat2-lat1);
         float dLon = degreesToRadians(lon2-lon1);
         lat1 = degreesToRadians(lat1);
		 lat2 = degreesToRadians(lat2);
		 float a = Mathf.Sin(dLat/2) * Mathf.Sin(dLat/2) + Mathf.Sin(dLon/2) * Mathf.Sin(dLon/2) * Mathf.Cos(lat1) * Mathf.Cos(lat2); 
         float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1-a)); 
         return earthRadiusKm * c; 
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
	void showKM(){
		distanceKM=distanceInKmBetweenEarthCoordinates(GPS.Instance.latitude, GPS.Instance.longitude, lat, lon);
		coordinates.enabled=true;
		kmdata.enabled=true;
		image.enabled=true;
		coordinates.text =PlayerPrefs.GetString("Location","Konum Bulunamadı");
		if(distanceKM<1){
			distanceKM=distanceKM*1000;
		    kmdata.text =((int)distanceKM).ToString()+" m.";
		}
		else{
           kmdata.text =distanceKM.ToString("0.##")+" km.";
		}
	}
}