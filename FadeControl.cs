/************************************************************
************************************************************/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/************************************************************
************************************************************/

public class FadeControl : MonoBehaviour {
	/****************************************
	****************************************/
	float fadePerSec = 1.0f;
	float red, green, blue, alpha;
	
	bool b_Fading = false;
 
	Image fadeImage;
	
	/****************************************
	****************************************/
	
	/******************************
	******************************/
	void Awake () {
		fadeImage = GetComponent<Image>();
		
		fadeImage.enabled = false;
		
		red = fadeImage.color.r;
		green = fadeImage.color.g;
		blue = fadeImage.color.b;
		// alpha = fadeImage.color.a;
		alpha = 0;
		
		SetImageColor();
	}
	
	/******************************
	******************************/
	void Start () {
	
	}
	
	/******************************
	******************************/
	void Update () {
	
	}
	
	/******************************
	******************************/
	public void Start_FadeIn(float duration){
		if(b_Fading) return;
		
		fadeImage.enabled = true;
		b_Fading = true;
		alpha = 0.0f;
		fadePerSec = 1.0f / duration;
		
		StartCoroutine(FadeIn());
	}
	
	/******************************
	******************************/
	IEnumerator FadeIn(){
		while(alpha < 1){
			alpha += Time.deltaTime * fadePerSec;
			if(1 < alpha) alpha = 1;
			SetImageColor();
			
			yield return new WaitForEndOfFrame();
		}
		
		b_Fading = false;
	}
	
	/******************************
	******************************/
	public void Start_FadeOut(float duration){
		if(b_Fading) return;
		
		fadeImage.enabled = true;
		b_Fading = true;
		alpha = 1.0f;
		fadePerSec = 1.0f / duration;
		
		StartCoroutine(FadeOut());
	}
	
	/******************************
	******************************/
	IEnumerator FadeOut(){
		while(0 < alpha){
			alpha -= Time.deltaTime * fadePerSec;
			if(alpha < 0) alpha = 0;
			SetImageColor();
			
			yield return new WaitForEndOfFrame();
		}
		
		b_Fading = false;
		fadeImage.enabled = false;
	}
	
	/******************************
	******************************/
	public void ImageEnabled(bool _b_enabled){
		fadeImage.enabled = _b_enabled;
	}
	/******************************
	******************************/
	void SetImageColor(){
		fadeImage.color = new Color(red, green, blue, alpha);
	}
	
	/******************************
	******************************/
	public bool IsFading(){
		return b_Fading;
	}
}
