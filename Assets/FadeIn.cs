using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// gameObject.GetComponent.<Animation>().Play("name of animation");

public class FadeIn : MonoBehaviour
{
    Text title;
    [SerializeField] float duration = 5f;    

	// Use this for initialization
	void Start ()
    {
        title = GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        Color myColor = title.color;
        float ratio = Time.time / duration;
        myColor.a = Mathf.Lerp(0, 1, ratio);
        title.color = myColor;
    }

}
