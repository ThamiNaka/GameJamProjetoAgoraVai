using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed;
    public float JumpForce;

    public bool isJumping;
    public bool doubleJump;

    public GameObject projetil;         // vai ser o projetil da arma
    public Transform weapon;           // vai ser a posição de onde vai sairo nosso tiro
    private bool fire;                // vai ser o nosso input de disparo da arma
    public float fireStrong;         // vai ser a velocidade do tiro
    private bool flipx = false;    // vai ser a mudança de direção

    private Rigidbody2D rig;
    private Animator anim;

    private SoundManager SoundManager;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        SoundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Fire();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
        
        if (Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("run", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        
        if (Input.GetAxis("Horizontal") > 0f)
        {
            anim.SetBool("run", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if (Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("run", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                anim.SetBool("jump", true);

            //     doubleJump = false;// mudando para false, pula apenas uma vez.

            // }
            // else
            // {
            //     if (doubleJump)
            //     {
            //          rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            //          doubleJump = false;
            //     }
            }
            
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }
    

        if(collision.gameObject.layer == 9)
        {
            //GameController.instance.ShowGameOver();
            //anim.SetTrigger("die");
            Destroy(gameObject, 0.6f);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }  
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            SoundManager.coinsource.PlayOneShot(SoundManager.coinSound);
            Destroy(other.gameObject);
        }
    }

    private void Fire()
    {
        if (fire = Input.GetButtonDown("Fire1"))
        {
            GameObject temp = Instantiate(projetil);
            temp.transform.position = weapon.position;
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(fireStrong, 0);
            Destroy(temp.gameObject, 3f);
        }
    }

    private void Flip()
    {
        flipx = !flipx;
        float x = transform.localScale.x;
        x *= -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
        fireStrong *= -1; 
    }
}
    
