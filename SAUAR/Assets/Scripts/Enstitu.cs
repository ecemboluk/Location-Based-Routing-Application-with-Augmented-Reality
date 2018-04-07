using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enstitu : MonoBehaviour {
   
   public void onLoadFenBilimler(){
	   PlayerPrefs.SetString("Location","Fen Bilimleri Enstitüsü");
	   SceneManager.LoadScene(2);		
   }
   public void onLoadSosyalBilimler(){
	   PlayerPrefs.SetString("Location","Sosyal Bilimler Enstitüsü");
	   SceneManager.LoadScene(2);		
   }
   public void onLoadYabancıDiller(){
	   PlayerPrefs.SetString("Location","Yabancı Diller Bölümü");
	   SceneManager.LoadScene(2);		
   }
}
