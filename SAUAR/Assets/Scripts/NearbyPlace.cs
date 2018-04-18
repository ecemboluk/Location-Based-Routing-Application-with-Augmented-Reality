using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NearbyPlace : MonoBehaviour {

    float distanceKM,lat,lon, distanceKM1,getDegre;
	public RawImage image1;
	public Text location1,location2,km1,km2;
	List<NearByLocation> liste1 = new List<NearByLocation>();
	List<NearByLocation> liste2 = new List<NearByLocation>();
	List<NearByLocation> liste3 = new List<NearByLocation>();
	List<NearByLocation> liste4 = new List<NearByLocation>();
	// Use this for initialization
	void Start () {
	   nearbyPlace();
	}
	// Update is called once per frame
	void Update () {
	    nearbyPlace();
	}
	public void nearbyPlace(){
		image1.enabled=false;
		location1.enabled=false;
		km1.enabled=false;	
		var ds= new DataService("LocationSAU.db");
		var konum=ds.GetLocations();
		foreach (var item in konum)
		{
			distanceKM1=distanceInKmBetweenEarthCoordinates(40.74239f, 30.32516f,item.lat,item.lng);
			if(distanceKM1<1){
				distanceKM1=distanceKM1/0.001f;
				if(distanceKM1<300){
					getDegre=getDegrees(40.74239f, 30.32516f,item.lat,item.lng);
					if(getDegre<=90){
                       liste1.Add(new NearByLocation(item.name,((int)distanceKM1).ToString()));				   
					}
					else if(getDegre>90 && getDegre<=180){
                       liste2.Add(new NearByLocation(item.name,((int)distanceKM1).ToString()));	
					}
					else if(getDegre>180 &&getDegre<=270){
                       liste3.Add(new NearByLocation(item.name,((int)distanceKM1).ToString()));
					}
					else if(getDegre>270 && getDegre<=360){
                       liste4.Add(new NearByLocation(item.name,((int)distanceKM1).ToString()));	
					}
				}
			}
		}
		
		if(GPS.Instance.degree<=90){
			   location1.text=liste1[0].name;
		       km1.text=liste1[0].km+".m";
			   location2.text=liste1[1].name;
		       km2.text=liste1[1].km+".m";
		}
		else if(GPS.Instance.degree>90 && GPS.Instance.degree<=180){
			   location1.text=liste2[0].name;
		       km1.text=liste2[0].km+".m";
			   location2.text=liste2[1].name;
		       km2.text=liste2[1].km+".m";
		}
		else if(GPS.Instance.degree>180 &&GPS.Instance.degree<=270){
			   location1.text=liste3[0].name;
		       km1.text=liste3[0].km+".m";
			   location2.text=liste3[1].name;
		       km2.text=liste3[1].km+".m";
		}
		else if(GPS.Instance.degree>270 && GPS.Instance.degree<=360){
			   location1.text=liste4[0].name;
		       km1.text=liste4[0].km+".m";
			   location2.text=liste4[1].name;
		       km2.text=liste4[1].km+".m";
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
	float toRad(float degrees) {
		return (float)(degrees * Mathf.PI / 180);
    }
	float getDegrees(float lat1, float lon1, float lat2, float lon2) {
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
       return brng;
   }
}