using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator playerAnimator;
    private GameController _GameController;

    public float speedX;
    public float jumpForce;

    public bool isLookLeft;

    public Transform groundCheck;
    private bool isGrounded;
    private bool isAttack;

    public GameObject hitboxPreFab;
    public Transform hand;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent <Animator>();
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
        _GameController.playerTransform = this.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if(isAttack == true && isGrounded == true)
        {
            h = 0;
        }

        if(h > 0 && isLookLeft == true)
        {
            Flip();
        }
        else if(h < 0 && isLookLeft == false)
        {
            Flip();
        }


        float speedY = playerRb.velocity.y;

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            playerRb.AddForce(new Vector2(0, jumpForce));
            
        }

        if (Input.GetButtonDown("Fire1"))
        {
            
            playerAnimator.SetTrigger("attack");
            isAttack = true;
        }


        playerRb.velocity = new Vector2(h * speedX, speedY );
        playerAnimator.SetInteger("h", (int)h);
        playerAnimator.SetBool("isGrounded", isGrounded);
        playerAnimator.SetFloat("speedY", speedY);
        playerAnimator.SetBool("isAttack", isAttack);


        
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.02f);
    }

    void Flip()
    {
        isLookLeft = !isLookLeft;
        float x = transform.localScale.x * -1; //Inverte o sinal do X
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);

    }

    void onEndAttack()
    {
        isAttack = false; 
    }

    void hitboxAttack()
    {
        GameObject hitboxTemp = Instantiate(hitboxPreFab, hand.position, transform.localRotation);
        Destroy(hitboxTemp, 0.02f);
    }

    
}
