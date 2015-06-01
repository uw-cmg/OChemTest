﻿using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	[HideInInspector]public Camera camera;
	public static PlayerControl self;
	public static Vector3 center;
	public float horizontalSpeed = 2.0f;
	public float verticalSpeed = 2.0f; 
	public int state;
	public enum State{
		HoldingAtom,
		UsingControl,
		Default
	};
	void Awake(){
		self = this;
		center = Vector3.zero;
		camera = GetComponent<Camera>();
		state = (int)State.Default;
	}
	// Use this for initialization
	void Start () {
	
	}
	void RotateCameraAroundCenter(){
		float yRotation = Input.GetAxis("Mouse X") * horizontalSpeed;
		float rightRotation = Input.GetAxis("Mouse Y") * verticalSpeed;
		yRotation *= Time.deltaTime;
		rightRotation *= Time.deltaTime;

		transform.RotateAround(center, transform.rotation*Vector3.up, yRotation * Mathf.Rad2Deg);
		transform.RotateAround(center, transform.rotation*Vector3.left, rightRotation * Mathf.Rad2Deg);
	}
	// Update is called once per frame
	void Update () {
		if(state == (int)State.Default){
			state = (int)State.UsingControl;
			if(Input.GetMouseButton(0)){
				RotateCameraAroundCenter();
			}	
		}else if(state == (int)State.UsingControl){
			if(Input.GetMouseButton(0)){
				RotateCameraAroundCenter();
			}
		}else if(state == (int)State.HoldingAtom){

		} 
		
	}
}
