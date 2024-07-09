using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour{
	
	[Range(0.1f, 10.0f)]public float distanceAway;			
	[Range(0.1f, 10.0f)]public float distanceUp;
	[Range(0.1f, 4.0f)]public float smooth;	
	public string TagFollowTarget="Player";

	private Transform target;		
	private Vector3 targetPosition;

	void Update (){
		Buscar ();
	}
	void LateUpdate (){
		targetPosition = target.position + Vector3.up * distanceUp - target.forward * distanceAway;
		transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);
		transform.LookAt(target);
	}
	
	void Buscar(){
		if(target==null){
		target = GameObject.FindWithTag (TagFollowTarget).transform;
		} 
	}
}
