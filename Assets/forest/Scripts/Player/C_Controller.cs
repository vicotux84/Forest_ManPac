using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Controller : MonoBehaviour{
    private Vector3 moveDirection = Vector3.zero;
   [SerializeField]bool CursorIsvisble=false;
    [SerializeField]string Horizontal, Vertical;
    public float Speed;
    
    
    float Axis_Horizontal, Axis_Vertical;
    Animator _anim;
    private void Start() {
        _anim=gameObject.GetComponent<Animator>();
    }
    void Update(){
        Axis_Horizontal=Input.GetAxis(Horizontal);
        Axis_Vertical=Input.GetAxis(Vertical);
        Movement(Axis_Horizontal,Axis_Vertical);
        Cursor.visible = CursorIsvisble;
        
    } 

        void Movement(float vertical, float horizontal){ 
        Vector3 Move=new Vector3(horizontal,0,vertical);
        Move.Normalize();
        transform.Translate(Move * Time.deltaTime * Speed);       
          if (Axis_Horizontal!=0 || Axis_Vertical!=0){           
                 _anim.SetBool("IsRunning",true);             
        }else{           
                 _anim.SetBool("IsRunning",false);             
        }
              
    } 
}
