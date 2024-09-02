using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerJumperController : MonoBehaviour
{
    private float movementInput;
    [SerializeField] private float speed = 0f;
    [SerializeField] private float normalSpeed;
    private Rigidbody2D playerRb;

    

    //[SerializeField] private Text scoreText;
    //private float topScore = 0f;

    void Start()
    {
        speed = 0f;
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        

        /*if (playerRb.velocity.y > 0 && transform.position.y > topScore)
        {
            topScore = transform.position.y;
        }

        scoreText.text = "Score: " + Mathf.Round(topScore).ToString();*/
    }

    void FixedUpdate()
    {
        playerRb.velocity = new Vector2(speed, playerRb.velocity.y);

        


        //movementInput = Input.GetAxis("Horizontal");
        //playerRb.velocity = new Vector2(movementInput * speed, playerRb.velocity.y);
    }

    public void OnLeftButtonDown()
    {
        if (speed >= 0f)
        {
            speed = -normalSpeed;
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public void OnRightButtonDown()
    {
        if (speed <= 0f)
        {
            speed = normalSpeed;
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public void OnButtonUp()
    {
        speed = 0f;
    }

    
}