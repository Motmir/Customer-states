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

        if (transform.position.x > 4)
        {
            transform.rotation = new Quaternion(0f, -1f, 0f, 0f);
        }
        else if (transform.position.x < -4)
        {
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject.Find("LevelMaganer").GetComponent<LevelControl>().robot.GetComponent<Robot>().Screwdriver(collision);
    }
}