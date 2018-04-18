using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPS : MonoBehaviour {

	public float latitude;
	public float longitude;
    public float degree;
	private int maxWait=20;

	public static GPS Instance { get; set;}

	// Use this for initialization
	void Update () {
      
	  Instance=this;
	  latitude=Input.location.lastData.latitude;
	  longitude=Input.location.lastData.longitude;
      degree=Input.compass.trueHeading;
      
	}
	IEnumerator Start()
    {
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield break;

        // Start service before querying location
        Input.location.Start();
        Input.compass.enabled = true;
        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
			latitude=Input.location.lastData.latitude;
			longitude=Input.location.lastData.longitude;
            degree=Input.compass.trueHeading;
            // Access granted and location value could be retrieved
        }
    }
}
