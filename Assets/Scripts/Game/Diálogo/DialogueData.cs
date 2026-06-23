using NUnit.Framework;
using System;
using UnityEngine;

[Serializable]
public struct Dialogue
{
    public string name;
    [TextArea(5, 10)]
    public string text;
}

[CreateAssetMenu(fileName = "DialogueData", menuName = "Scriptable Objects/TalkScript", order = 1)]

public class DialogueData : ScriptableObject
{
}
