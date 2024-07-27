using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class claw : MonoBehaviour
{
    [SerializeField] private Sprite openClaw;
    [SerializeField] private Sprite closedClaw;
    [SerializeField] private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    public void Open()
    {
        spriteRenderer.sprite = openClaw;
    }

    public void Close()
    {
        spriteRenderer.sprite = closedClaw;
    }
}
