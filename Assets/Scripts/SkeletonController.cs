using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkeletonController : MonoBehaviour
{
    public float jumpForce = 250;
    private bool onGround = true;//Used in flip logic
    private Rigidbody2D body; // This and jump force used to make skele jump
    private int direction = 1; //facing right
    private SpriteRenderer rend;
    private AudioSource audioSource;//for jump sound
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine("SkeleJump");
    }


    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);
        Debug.DrawRay(transform.position, new Vector2(0, -3), Color.red, 0.5f);
        //Debug.Log(hit);
        if (hit.collider == null && onGround == true) //no hit with raycasting also added the onGround variable so the skele soesn't flip while in the air
        {
            direction = direction * -1;
            rend.flipX = !rend.flipX;  //make dragon face direction of destination
        }

        transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x - 1 * direction, transform.position.y), Time.deltaTime);

        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.CompareTag("fire"))
            Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player")) //Used to make it so that the player can only shoot the skele to kill it and can't touch it or they die
        {
            GameManager.instance.DecreaseLives();
            GameManager.instance.pickups = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collision.gameObject.CompareTag("ground")) //Used for making sure it doesn't flip while in the air.
        {
            onGround = true;
        }
    }

    IEnumerator SkeleJump() //Used to make skele jump on an interval.
    {
        while (true)
        {
            Debug.Log("Skele");
            audioSource.PlayOneShot(audioSource.clip, 1.2f);
            body.AddForce(Vector2.up * jumpForce);
            onGround = false;
            yield return new WaitForSeconds(3f);
        }
    }
}
