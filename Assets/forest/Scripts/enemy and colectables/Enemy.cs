using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
    [SerializeField] string TagPlayer="Jugador";
    [SerializeField][Range(1,100)] int Value=1;
    [SerializeField]bool IsCoin;
    [SerializeField] GameObject Orco;
    [SerializeField]Animator anim;
    public EnemyGrunt_ia  ScriptIA;
    [SerializeField]bool IsDead;
    [SerializeField] CapsuleCollider ColiderEnemy;
    [SerializeField] AudioClip _Coin;
    [SerializeField] AudioClip _Dead;
    [SerializeField] Rigidbody RB;
    [SerializeField]int _Sound;


    GameManager GameManager;
    SoundFXManagerv FXManager;

    void Update(){
      if(GameManager.IsCoin==true){
       IsCoin=true;
      }else{
         IsCoin=false;
      }
    }
    void Awake(){
        IsDead=false;
        SearchManagers();
        }
      
       void SearchManagers() {      
           if(GameManager==null){
        GameManager=FindObjectOfType<GameManager>();
        if(FXManager==null){
        FXManager=FindObjectOfType<SoundFXManagerv>();
        } 
      }   
    }

    
    void OnTriggerEnter(Collider other){
		if (other.tag == TagPlayer){
			if(IsCoin==false){
	  Debug.Log("Daño: "+Value); 
      FXManager.SoundPlay(_Coin, _Sound);
      GameManager.Hearts-=Value;
      GameManager.Points-=(Value/2);
	   }
      if (IsCoin==true&& IsDead==false){
        Is_dead();
		//GameManager.Points=(Value);
        }
      }
       if(other.tag == "espada"){
         Is_dead();
        }       
  } 
   private void Is_dead() {
            IsCoin=false;
        IsDead=true;
        FXManager.SoundPlay(_Dead, _Sound);
        GameManager.Points+=Value;
		ScriptIA.isDead();
         //anim.SetBool("Dead",true);
        ColiderEnemy.isTrigger = false;
        ColiderEnemy.radius=0.1f;
        ColiderEnemy.height=0.1f;
		ScriptIA.enabled=false;
        //transform.position=new Vector3(transform.position.x,-2.0f,transform.position.z);
         RB.useGravity = true;         
         //ScriptIA.enabled=false;
         //Orco.SetActive(false);         
         Value=0;
        }
}
