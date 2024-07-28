using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogueInfo : ScriptableObject
{
    public string robotName;
    public bool dialogueStarted = false;

    [TextArea(3, 10)]
    public string[] sentences;
}
