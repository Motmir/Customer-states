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
        Vector2 sqMouseDir = new Vector2(mouseDir.x * (Mathf.Abs(mouseDir.x) + 5), mouseDir.y * (Mathf.Abs(mouseDir.y) + 5));
        rb.velocity = sqMouseDir;

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
        RobotPart part = collision.transform.GetComponent<RobotPart>();
        if(part != null){
		    part.Screwdriver();
	    }
        transform.GetChild(0).gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Vector2 loc = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(loc.x, loc.y);
    }
}