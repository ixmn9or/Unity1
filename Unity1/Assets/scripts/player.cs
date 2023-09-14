using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class player : MonoBehaviour
{
    float yPosition;
    [SerializeField] GameObject laser;

    bool power;
    // Start is called before the first frame update
    void Start()
    {
        yPosition = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 convertedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(convertedPosition.x, yPosition, 0);

        if (Input.GetButtonDown("FireLaser"))
        {
            Instantiate(laser, transform.position, Quaternion.identity);
            if (power)
            {
                StartCoroutine(powerUpWork());
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "power")
        {
            power = true;
            Destroy(collision.gameObject);
        }
    }

    IEnumerator powerUpWork()
    {
        yield return new WaitForSeconds(0.3f);
        Instantiate(laser, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(10f);
        power = false;
    }
}