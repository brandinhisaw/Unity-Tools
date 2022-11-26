using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Prompt", menuName = "ScriptableObjects/PromptSO", order = 1)]
public class Prompt : ScriptableObject
{
    [SerializeField]
    public string text;
}
