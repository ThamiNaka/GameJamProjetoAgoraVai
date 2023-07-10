using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Rigidbody2D enemyRb;
    private bool faceFlip = false; //vai ser usada para mudar de direção quando colidir com algo
    bool inGround = false;
    Transform groundCheck;

    private SoundManager SoundManager;


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = gameObject.GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("EnemyGroundCheck");

        SoundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        inGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("ground"));
        if (!inGround)
        {
            speed *= -1;
        }
    }

    void FixedUpdate()
    {
        enemyRb.velocity = new Vector2(speed, enemyRb.velocity.y);

        if (speed > 0 && !faceFlip)
        {
            Flip();
        }
        else if (speed < 0 && faceFlip)
        {
            Flip();
        }
    }

    void Flip()
    {
        faceFlip = !faceFlip;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("ammo"))
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
            SoundManager.audiosource.volume = 1f; 
            SoundManager.audiosource.PlayOneShot(SoundManager.mobdieSound);
        }
    }

}
