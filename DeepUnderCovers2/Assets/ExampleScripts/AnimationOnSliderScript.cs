using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationOnSliderScript : MonoBehaviour {

    public Slider slider;
    public string animationName;

    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        animator.speed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        animator.Play(animationName, 0, slider.value);
	}
}
