using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Letter : MonoBehaviour,IPointerClickHandler {

	private string myValue;

	public string value
	{
		get { return myValue; }
		set { myValue = value; }
	}


	public void OnPointerClick(PointerEventData eventData){
		Debug.Log (myValue);
	}
}
