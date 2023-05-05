using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Controller : MonoBehaviour{
    
    [SerializeField]bool CursorIsvisble;
    
    [Header ("Movement")]
    [SerializeField]float Speed;
    [SerializeField]string Horizontal,Vertical;
    
    
    private  CharacterController _controller;
    private Vector3 moveDirection = Vector3.zero;
    private float Axis_Horizontal, Axis_Vertical;    
    private Vector3 _move;    
    private Animator _anim;
    private bool Attake;

    private void Start() {
        _anim=gameObject.GetComponent<Animator>();
        _controller=GetComponent<CharacterController>();
    }
    void Update(){
        Axis_Horizontal=Input.GetAxis(Horizontal);
        Axis_Vertical=Input.GetAxis(Vertical);
        Attake=Input.GetButton("Fire1");
        _move=new Vector3(Axis_Vertical,0,Axis_Horizontal);
        Cursor.visible = CursorIsvisble;
        Atake();
        Rotate(_move);
        Movement(_move);       
    } 

        void Movement(Vector3 Moverse){ 
        _controller.Move(Moverse * Time.deltaTime * Speed);       
          if (Axis_Horizontal!=0){           
                 _anim.SetBool("IsRunning",true);             
        }if (Axis_Horizontal==0){                 
             _anim.SetBool("IsRunning",false);             
        }if (Axis_Vertical>=0.1f){                 
             _anim.SetFloat("Speed",1.0f);             
        }if (Axis_Vertical==0){                 
             _anim.SetFloat("Speed",0.0f);             
        }if (Axis_Vertical<=-0.1f){                 
             _anim.SetFloat("Speed",1.0f);             
        }
        
    
    } 
    private void Atake() {
        if (Attake==true){             
        _anim.SetBool("Ataque",true);
        }else{             
        _anim.SetBool("Ataque",false);
        }
    } 
      

void Rotate(Vector3 move){
        Vector3 Rotation=new Vector3 (move.x,0, move.z);        
         if (Axis_Horizontal!=0 || Axis_Vertical!=0){
          transform.rotation= Quaternion.LookRotation(Rotation);
        }
    }
    
}
