using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadLimit : MonoBehaviour{
    
    [SerializeField]string TagJugador;
   [SerializeField]GameManager GameManager;
    public GameObject Player;
    public Vector3 Destino;
    public float waitTime=3;
    public Text levelText;

    void Awake(){
      if(GameManager==null){
        GameManager=FindObjectOfType<GameManager>();
        Player=GameObject.FindGameObjectWithTag(TagJugador); 
        //
        }
      }
      void OnTriggerEnter(Collider other){
		if (other.tag == TagJugador){
        GameManager.lives--;
        Invoke("DeadL", waitTime);
        levelText.text="lives: 0" + GameManager.lives.ToString();        
        //Debug.Log(GameManager.lives);
        Player.SetActive(false);

        }
    } 
    private void DeadL() {
      levelText.text="";
      Player.transform.position=Destino;
      Player.SetActive(true);
    }
  } 
