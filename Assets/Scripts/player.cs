using UnityEngine;

public class player : MonoBehaviour
{
   private float horizontal;
   private float speed = 6f;
   private float jump = 8f;
   private bool facingright = true;

   [SerializeField] private Rigidbody2D rgby;
   [SerializeField] private LayerMask groundLayer;
   [SerializeField] private Transform groundCheck;

    void Update() {
        horizontal= Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && IsGrounded()){
            rgby.linearVelocity = new Vector2(rgby.linearVelocity.x, jump);
        }
        if(Input.GetButtonUp("Jump") && rgby.linearVelocity.y > 0f)
        {
            rgby.linearVelocity = new Vector2(rgby.linearVelocity.y, rgby.linearVelocity.y * 0.5f) ;
        }
        Flip();
    }
    private void FixedUpdate()
    {
        rgby.linearVelocity = new Vector2(horizontal * speed, rgby.linearVelocity.y);
    }
        private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    } 
      private void Flip()
    {
        if(facingright && horizontal < 0f || !facingright && horizontal > 0f){
            facingright = !facingright;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale= localScale;


        }
    }
}
