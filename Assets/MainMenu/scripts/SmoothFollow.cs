using UnityEngine;

	public class SmoothFollow : MonoBehaviour{

		
		[Range(0.0f, 10.0f)]public float distance = 10.0f;
		[Range(0.0f, 10.0f)]public float height = 5.0f;
		[Range(0.0f, 10.0f)]public float rotationDamping;
		[Range(0.0f, 10.0f)]public float heightDamping;
		public string TagFollowTarget="Player";

		private Transform target;		

		void Update (){
		Buscar ();
	}

	void Buscar(){
		if(target==null){
		target = GameObject.FindWithTag (TagFollowTarget).transform;
		} 
	}
			void LateUpdate(){
			if (!target)
				return;
			var wantedRotationAngle = target.eulerAngles.y;
			var wantedHeight = target.position.y + height;
			var currentRotationAngle = transform.eulerAngles.y;
			var currentHeight = transform.position.y;
			currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
			currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
			var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
			transform.position = target.position;
			transform.position -= currentRotation * Vector3.forward * distance;
			transform.position = new Vector3(transform.position.x ,currentHeight , transform.position.z);
			transform.LookAt(target);
	}

}
