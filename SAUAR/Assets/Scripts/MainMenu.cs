using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
   public Text choose;
   public Text location;

   void Start(){
       Screen.orientation = ScreenOrientation.Portrait;
   }
   void Update(){
      Screen.orientation = ScreenOrientation.Portrait;
   }
   public void onClick(){
	   if(choose.text=="Enstitüler"){
          SceneManager.LoadScene(2);
	   }
	   else if(choose.text=="Fakülteler"){
          SceneManager.LoadScene(3);
	   }
   }

   public void onClickReturn(){
       SceneManager.LoadScene(1);
   }

   public void onClickCamera(){
      PlayerPrefs.SetString("Location",location.text);
      SceneManager.LoadScene(8);
   }

   public void onClickFen(){
       SceneManager.LoadScene(4);
   }
   public void onClickM(){
       SceneManager.LoadScene(5);
   }
   public void onClickT(){
       SceneManager.LoadScene(6);
   }
   public void onClick1(){
       SceneManager.LoadScene(7);
   }
   public void onClick2(){
       SceneManager.LoadScene(9);
   }
}
