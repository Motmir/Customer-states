using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CustomerNoteInfo : ScriptableObject
{
    public string ownerName;

    [TextArea(3, 10)]
    public string customerNote;
}