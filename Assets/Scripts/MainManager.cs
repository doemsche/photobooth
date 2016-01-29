using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;
using System;

public class MainManager : MonoBehaviour {

	public InputField inputfield;
	public PlayVideoTextureOnUI videoinput;
	public CountDown countdown;
	public Keyboard keyboard;

	void Start(){

	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Space)){
			StartCoroutine(CountDown());
		}
	}

	private IEnumerator CountDown(){
		WaitForSeconds wait = new WaitForSeconds(1.0f);

		for(int i = 0; i <= 3; i++){
			yield return wait;
			if(i <= 2){
				countdown.ShowItem(i);
			}
				
			if(i == 3){
				countdown.FakeShutter();
				videoinput.Record();
			}
				
		}
	}

	public void WriteChar(string character){
		if(character == "d"){
			inputfield.text = inputfield.text.Remove(inputfield.text.Length-1);
			return;
		}
		inputfield.text += character;
		if(IsValidEmail(inputfield.text)){
			Debug.Log ("valid email");
		} else {
			Debug.Log("invalid email");
		}
	}

	public bool IsValidEmail(string emailaddress){
		Regex rgx = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,10})+)$");
		if(rgx.IsMatch(emailaddress)){
			return true;
		} else {
			return false;
		}
	}
}
