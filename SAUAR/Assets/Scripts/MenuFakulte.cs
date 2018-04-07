using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuFakulte : MonoBehaviour,IPointerClickHandler {

   public RectTransform container;
   public bool isOpen=false, isClick;
   public GameObject Ortak;

   void Start(){
       container=transform.Find("Container").GetComponent<RectTransform>();
       Ortak=GameObject.Find("Dropdown3");
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
           Ortak.SetActive(false);
       }
       else{
          isOpen=false;
          isClick=true;
          Ortak.SetActive(true);
       }
    }
}
