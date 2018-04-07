using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuEnstitu : MonoBehaviour, IPointerClickHandler{
   public RectTransform container;
   public bool isOpen=false, isClick;
   public GameObject Fakulte,Ortak;

   void Start(){
       container=transform.Find("Container").GetComponent<RectTransform>();
       Fakulte=GameObject.Find("Dropdown2");
       Ortak=GameObject.Find("Dropdown3");
       isOpen=false;
       isClick=true;
   }
   void Update(){
       if(isOpen){
           Vector3 scale=container.localScale;
           scale.y=Mathf.Lerp(scale.y,1,Time.deltaTime*12);
           container.localScale=scale;
       }
       else{
          Vector3 scale=container.localScale;
          scale.y=Mathf.Lerp(scale.y,0,Time.deltaTime*12);
          container.localScale=scale; 
       }
   }
   public void OnPointerClick(PointerEventData eventData){
       if(isClick){
           isClick=false;
           isOpen=true;
           Fakulte.SetActive(false);
           Ortak.SetActive(false);
       }
       else{
          isOpen=false;
          isClick=true;
          Fakulte.SetActive(true);
          Ortak.SetActive(true);
       }
    }
}