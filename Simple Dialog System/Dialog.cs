using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Dialog : MonoBehaviour
{
    [SerializeField]
    protected Prompt[] prompts;

    protected int promptsIndex = 0;

    protected bool canSkipDialog;
    protected bool waitingForInput;

    [SerializeField]
    protected float typingEffectTime = 0.5f;

    [SerializeField]
    protected GameObject messageDisplayCanvas;
    [SerializeField]
    protected GameObject inputReadyImage;

    protected TextMeshProUGUI textMesh;

    void Start()
    {
        canSkipDialog = false;
        waitingForInput = false;

        textMesh = messageDisplayCanvas.GetComponentInChildren<TextMeshProUGUI>();

        RunDialog();
    }

    public abstract void RunDialog();
}
