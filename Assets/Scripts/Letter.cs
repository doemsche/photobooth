using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Letter : MonoBehaviour,IPointerClickHandler {

	private string myValue;
//	public 
	public string value
	{
		get { return myValue; }
		set { myValue = value; }
	}

	public void OnPointerClick(PointerEventData eventData){
		string outvalue;
		if(gameObject.GetComponentInParent<Keyboard>().shift){
			outvalue = myValue.ToUpper();
		} else{
			outvalue = myValue;
		}
		gameObject.GetComponentInParent<Keyboard>().mainmanager.WriteChar(outvalue);
	}
}
