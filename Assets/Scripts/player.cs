using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
   private float horizontal;
   private float speed = 5f;
   private float jump = 6f;
   private bool facingright = true;
   private Vector3 respawn;
  
   public GameObject fallDetector;




   [SerializeField] private Rigidbody2D rgby;
   [SerializeField] private LayerMask groundLayer;
   [SerializeField] private Transform groundCheck;


    void Start()
    {
        respawn = transform.position;
    }
    
    void Update() {
        horizontal= Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && IsGrounded()){
            rgby.linearVelocity = new Vector2(rgby.linearVelocity.x, jump);
        }

        if(Input.GetButtonUp("Jump") && rgby.linearVelocity.y > 0f){
            rgby.linearVelocity = new Vector2(rgby.linearVelocity.y, rgby.linearVelocity.y * 0.5f) ;
        }

        Flip();
        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y) ;
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag ==  "FallDetector"){
            transform.position = respawn;
        }
        else if (collision.tag == "CheckPoint"){
            respawn = transform.position;
        }
        else if (collision.tag == "NextLevel"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            respawn = transform.position;
        }
        else if(collision.tag == "PreviousLevel"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            respawn = transform.position;
        }

        else if(collision.tag == "CollectableItem"){
            Scoring.CollectableScore += 1;
            collision.gameObject.SetActive(false);
        }  
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
