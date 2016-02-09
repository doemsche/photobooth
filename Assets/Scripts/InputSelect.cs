using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class InputSelect : MonoBehaviour, ISelectHandler// required interface when using the OnSelect method.
{
	public MainManager manager;
	//Do this when the selectable UI object is selected.
	public void OnSelect (BaseEventData eventData) 
	{
		manager.SetActiveInputField(gameObject.GetComponent<InputField>());
	}
}