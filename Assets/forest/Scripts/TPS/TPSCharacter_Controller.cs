using UnityEngine;

public class TPSCharacter_Controller : MonoBehaviour {
    public AnimationCharacter a_Character;
    [Header("Movement")]
    public CharacterController controller;
    [Range(0.5f, 20)] public float walkSpeed,strafeSpeed;
    public string Horizontal,Vertical;
    private Vector3 velocity = Vector3.zero;

    void Update() {
        Movement();
    }
    private void Movement() {
        float _InputZ=Input.GetAxis(Vertical);
        float _InputX=Input.GetAxis(Horizontal);
        bool IsWalk;
        velocity.z =_InputZ * walkSpeed;
        velocity.x =-_InputX* strafeSpeed;
        velocity = transform.TransformDirection(velocity);
        velocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
         if (_InputX!=0 || _InputZ!=0){
            IsWalk=true;
        }else {
            IsWalk=false;
        }

        a_Character.Animate( IsWalk);
    }
}
