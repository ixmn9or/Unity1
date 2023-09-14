using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    [SerializeField] GameManager manager;

    private int health = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.InitiateGameOver();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "laser")
        {
            health -= 1;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            GameManager.instance.IncreaseScore(10);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "border")
        {
            GameManager.instance.combo = 0;
            Destroy(gameObject);
        } 
    }
}
