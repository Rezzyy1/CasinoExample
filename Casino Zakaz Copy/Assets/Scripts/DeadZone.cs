using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject boostPlatform;
    private GameObject myPlatform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.StartsWith("Platform"))
        {
            if (Random.Range(1, 7) == 1) 
            {

                Destroy(collision.gameObject);
                Instantiate(boostPlatform, new Vector2(Random.Range(-5f, 5f), player.transform.position.y + (12 + Random.Range(0.2f, 1.0f))), Quaternion.identity);
            }
            else
            {

                collision.gameObject.transform.position = new Vector2(Random.Range(-5f, 5f), player.transform.position.y + (12 + Random.Range(0.2f, 1.0f)));
            }
        }
        else if (collision.gameObject.name.StartsWith("Boost"))
        {
            if (Random.Range(1, 7) == 1)
            {

                collision.gameObject.transform.position = new Vector2(Random.Range(-5f, 5f), player.transform.position.y + (12 + Random.Range(0.2f, 1.0f)));
            }
            else
            {

                Destroy(collision.gameObject);
                Instantiate(platform, new Vector2(Random.Range(-5f, 5f), player.transform.position.y + (12 + Random.Range(0.2f, 1.0f))), Quaternion.identity);
            }
        }
        
    }




        /*if (Random.Range(1, 6) > 1)
        {
            myPlatform = (GameObject) Instantiate(platform, new Vector2(Random.Range(-5f, 5f), player.transform.position.y + (14 + Random.Range(0.5f, 1f))), Quaternion.identity);
        }
        else
        {
            myPlatform = (GameObject)Instantiate(boostPlatform, new Vector2(Random.Range(-5f, 5f), player.transform.position.y + (14 + Random.Range(0.5f, 1f))), Quaternion.identity);
        }

        Destroy(collision.gameObject);*/
}
