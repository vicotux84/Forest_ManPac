using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour {
	
	public Transform MeshPlayer;
	[Range(0.001f, 20.0f)]
	public float Speed=0.1f,SpeedRun=0.1f;
	[Range(0.001f, 20.0f)]
	public float gravity = 20.0F;
	public bool CursorIsvisble=false;
	public string Horizontal="Horizontal", Vertical="Vertical", Run="Fire2";

	private  CharacterController _controller;
	private  float Axis_Horizontal=0, Axis_Vertical=0;
	private Vector3 GravityDirection = Vector3.zero;    
	private  Animator _anim;

	private void Awake(){
		_controller=GetComponent<CharacterController>();
		_anim=gameObject.GetComponent<Animator>();
		Cursor.visible =CursorIsvisble;

	}

	void Update(){
		Axis_Horizontal=Input.GetAxis(Horizontal); 
		Axis_Vertical=Input.GetAxis(Vertical);
		Movement(Axis_Horizontal,Axis_Vertical);
		Gravity ();
	} 

	void Gravity(){
			if(_controller.isGrounded==false){
			GravityDirection.y -= gravity * Time.deltaTime;
			_controller.Move(GravityDirection * Time.deltaTime);
			Debug.Log ("no estas en el suelo");
		}else {
			Debug.Log ("estas en el suelo");	
		}
	}

	void Movement(float vertical, float horizontal){ 
		Vector3 Move=new Vector3(horizontal,0,vertical);
		Move.Normalize();            
		if(Input.GetButton(Run)){               
			_anim.SetBool("IsRun", true); 
			_anim.SetFloat("IsRunV",Mathf.Abs(Axis_Vertical));
			_anim.SetFloat("IsRunH",Mathf.Abs(Axis_Horizontal)); 
			_controller.Move(Move * Time.deltaTime * SpeedRun); 
		}
		else{ 
			_anim.SetBool("IsRun",false); 
			_anim.SetFloat("SpeedV",Mathf.Abs(Axis_Vertical));
			_anim.SetFloat("SpeedH",Mathf.Abs(Axis_Horizontal));
			_controller.Move(Move * Time.deltaTime * Speed);  
		}

		Rotate(Move);      
	}


	void Rotate(Vector3 move){
		Vector3 Rotation=new Vector3 (move.x,0, move.z);        
		if (Axis_Horizontal!=0 || Axis_Vertical!=0){
		
			MeshPlayer.rotation= Quaternion.LookRotation(Rotation);
		}
	}
}
