using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    public float speed;
    private Rigidbody rb;
    public static float score;
    public Text Scoretxt;
    public GameManager Game;    
    

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //transform.position = new Vector3(0, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("flap");
            rb.velocity = Vector2.up * speed;
            thisAnimation.Play();
        }

        if (transform.position.y >= 3.5f)
        {
            print("danger");
            transform.position = new Vector3(0, 3.5f, 0);
        }

        Scoretxt.text = "Score: " + score;
            
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacles")
        {
            SceneManager.LoadScene("GameLose");
            print("print");
            Game.GameOver();
            //GameManager.GameOver();
        }
    }
}
