using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBackground : MonoBehaviour {

    private bool moveForward = false;
    private const float FadeSpeed = 7;

	IEnumerator Start () 
    {
        yield return new WaitForSeconds(6f);

        float t = 0f;
        Image image = GetComponent<Image>();
        float a = 1f;

        while(true)
        {
            t = (Mathf.Sin(Time.time * FadeSpeed) + 1) / 2;

            a = Mathf.Lerp(0f, 1f, t);

            Color color = image.color;
            color.a = a;

            image.color = color;

            yield return null;
        }
	}
	
}
