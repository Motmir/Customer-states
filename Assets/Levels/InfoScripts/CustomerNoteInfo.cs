using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CustomerNoteInfo : ScriptableObject
{
    [TextArea(3, 10)]
    public string CustomerNote;
}