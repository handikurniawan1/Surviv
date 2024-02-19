using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotationSpeed;
    public float jumpSpeed;
    public float jumpButtonGracePeriod;

    private Animator animator;
    private CharacterController characterController;
    private float yspeed;
    private float originalStepOffset;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;
    [SerializeField]
    private Transform cameraTransform;

    [SerializeField]
    private float jumpHorizontalSpeed;

    private bool isJumping;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float inputMagnitude= Mathf.Clamp01(movementDirection.magnitude);
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)){
            inputMagnitude /= 2;
        }
        animator.SetFloat("Input Magnitude", inputMagnitude, 0.05f, Time.deltaTime);
        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize();

        yspeed += Physics.gravity.y * Time.deltaTime;

        if(characterController.isGrounded){

            lastGroundedTime = Time.time;
        }
        if(Input.GetButtonDown("Jump")){
            jumpButtonPressedTime = Time.time;
        }

        if(Time.time - lastGroundedTime <= jumpButtonGracePeriod){
            characterController.stepOffset = originalStepOffset;
            yspeed = -0.5f;
            animator.SetBool("IsGrounded", true);
            isGrounded = true;
            animator.SetBool("IsJumping", false);
            isJumping = false;
            animator.SetBool("IsFalling", false);
            if(Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod){
                yspeed =jumpSpeed;
                animator.SetBool("IsJumping", true);
                jumpButtonPressedTime = null;
                lastGroundedTime = null;
            }
        }
        else {
            characterController.stepOffset = 0;
            animator.SetBool("IsGrounded", false);
            isGrounded=false;

            if((isJumping && yspeed < 0) || yspeed <-2 ){
                animator.SetBool("IsFalling", true);
            }
        }


        if(movementDirection != Vector3.zero){

            animator.SetBool("IsMoving", true);
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else {

            animator.SetBool("IsMoving", false);
        }
        if(isGrounded== false){
            Vector3 velocity = movementDirection * inputMagnitude * jumpHorizontalSpeed;
            velocity.y = yspeed;

            characterController.Move(velocity * Time.deltaTime);
        }
    }
    private void OnAnimatorMove(){

        if(isGrounded){
            Vector3 velocity = animator.deltaPosition;
            velocity.y = yspeed * Time.deltaTime;

            characterController.Move(velocity);
        }
    }
}
