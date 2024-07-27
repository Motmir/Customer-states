using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Screwdriver : MonoBehaviour
{
    public Vector2 screenPosition;
    private Rigidbody2D rb;

   private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        screenPosition = Input.mousePosition;
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPosition);
        Vector2 mouseDir = worldPos - (new Vector2 (transform.position.x, transform.position.y));
        rb.velocity = mouseDir * 2;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with " + collision);
    }
    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    Debug.Log("Obj stays in trigger");
    //}
    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    Debug.Log("Obj exits trigger");
    //}
}