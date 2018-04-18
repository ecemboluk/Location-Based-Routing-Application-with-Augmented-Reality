using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NearbyPlace : MonoBehaviour {

    float distanceKM,lat,lon, distanceKM1,getDegre;
	int c1=0,c2=0,c3=0,c4=0;
	public Text location1,location2,location3,km1,km2;
	List<NearByLocation> liste1 = new List<NearByLocation>();
	List<NearByLocation> liste2 = new List<NearByLocation>();
	List<NearByLocation> liste3 = new List<NearByLocation>();
	List<NearByLocation> liste4 = new List<NearByLocation>();
	List<NearByLocation> liste5 = new List<NearByLocation>();
	List<NearByLocation> liste6 = new List<NearByLocation>();
	List<NearByLocation> liste7 = new List<NearByLocation>();
	List<NearByLocation> liste8 = new List<NearByLocation>();
	List<NearByLocation> liste9 = new List<NearByLocation>();
	List<NearByLocation> liste10 = new List<NearByLocation>();
	List<NearByLocation> liste11 = new List<NearByLocation>();
	List<NearByLocation> liste12 = new List<NearByLocation>();
	// Use this for initialization
	void Start () {
	   nearbyPlace();
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
           SceneManager.LoadScene(1); 
		}
	    nearbyPlace();
	}
	public void nearbyPlace(){
		var ds= new DataService("LocationSAU.db");
		var konum=ds.GetLocations();
		foreach (var item in konum)
		{
			distanceKM1=distanceInKmBetweenEarthCoordinates(40.74087f, 30.32910f,item.lat,item.lng);
			if(distanceKM1<1){
				distanceKM1=distanceKM1/0.001f;
				if(distanceKM1<300){
					getDegre=getDegrees(40.74087f, 30.32910f,item.lat,item.lng);
					if(getDegre<=30){
                       liste1.Add(new NearByLocation(item.name,distanceKM1));		   
					}
					else if(getDegre>30 && getDegre<=60){
                       liste2.Add(new NearByLocation(item.name,distanceKM1));
					}	
					else if(getDegre>60 &&getDegre<=90){
                       liste3.Add(new NearByLocation(item.name,distanceKM1));
					}
					else if(getDegre>90 && getDegre<=120){
                       liste4.Add(new NearByLocation(item.name,distanceKM1));	
					}
					else if(getDegre>120 && getDegre<=150){
                       liste5.Add(new NearByLocation(item.name,distanceKM1));	
					}
					else if(getDegre>150 && getDegre<=180){
                       liste6.Add(new NearByLocation(item.name,distanceKM1));	
					}
					else if(getDegre>180 && getDegre<=210){
                       liste7.Add(new NearByLocation(item.name,distanceKM1));	
					}
					else if(getDegre>210 && getDegre<=240){
                       liste8.Add(new NearByLocation(item.name,distanceKM1));	
					}
					else if(getDegre>240 && getDegre<=270){
                       liste9.Add(new NearByLocation(item.name,distanceKM1));	
					}
					else if(getDegre>270 && getDegre<=300){
                       liste10.Add(new NearByLocation(item.name,distanceKM1));	
					}
					else if(getDegre>300 && getDegre<=330){
                       liste11.Add(new NearByLocation(item.name,distanceKM1));	
					}
					else if(getDegre>330 && getDegre<=360){
                       liste12.Add(new NearByLocation(item.name,distanceKM1));	
					}
				}
			}
		}
		if(GPS.Instance.degree<=30){
			   location1.text=liste1[0].name;
		       km1.text=((int)liste1[0].km).ToString()+".m";
		}
		else if(GPS.Instance.degree>30 && GPS.Instance.degree<=60){
			   location1.text=liste2[0].name;
		       km1.text=((int)liste2[0].km).ToString()+".m";
		}
		else if(GPS.Instance.degree>60 &&GPS.Instance.degree<=90){
			   location1.text=liste3[0].name;
		      km1.text=((int)liste3[0].km).ToString()+".m";
		}
		else if(GPS.Instance.degree>90 && GPS.Instance.degree<=120){
			   location1.text=liste4[0].name;
		       km1.text=((int)liste4[0].km).ToString()+".m";
		}
		else if(GPS.Instance.degree>120 && GPS.Instance.degree<=150){
			   location1.text=liste5[0].name;
		       km1.text=((int)liste5[0].km).ToString()+".m";
		}
		else if(GPS.Instance.degree>150 && GPS.Instance.degree<=180){
			   location1.text=liste6[0].name;
		       km1.text=((int)liste6[0].km).ToString()+".m";
		}
		else if(GPS.Instance.degree>180 && GPS.Instance.degree<=210){
			   location1.text=liste7[0].name;
		       km1.text=((int)liste7[0].km).ToString()+".m";
		}
		else if(GPS.Instance.degree>210 && GPS.Instance.degree<=240){
			   location1.text=liste8[0].name;
		       km1.text=((int)liste8[0].km).ToString()+".m";
		}
		else if(GPS.Instance.degree>240 && GPS.Instance.degree<=270){
			   location1.text=liste9[0].name;
		       km1.text=((int)liste9[0].km).ToString()+".m";
		}
		else if(GPS.Instance.degree>270 && GPS.Instance.degree<=300){
			   location1.text=liste10[0].name;
		       km1.text=((int)liste10[0].km).ToString()+".m";
		}
		else if(GPS.Instance.degree>300 && GPS.Instance.degree<=330){
			   location1.text=liste11[0].name;
		       km1.text=((int)liste11[0].km).ToString()+".m";
		}
		else if(GPS.Instance.degree>330 && GPS.Instance.degree<=360){
			   location1.text=liste12[0].name;
		       km1.text=((int)liste12[0].km).ToString()+".m";
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