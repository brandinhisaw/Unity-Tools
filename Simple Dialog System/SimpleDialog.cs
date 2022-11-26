using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDialog : Dialog
{

    public override void RunDialog()
    {
        // Disable Player inputs during dialogs, display screen canvas, and kick off the dialog coroutines.
        PlayerDisable.Instance.DisablePlayer();
        messageDisplayCanvas.SetActive(true);
        StartCoroutine("ReadPrompts", promptsIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (promptsIndex < prompts.Length)
            {
                if (waitingForInput)
                {
                    waitingForInput = false;
                    promptsIndex++;
                    StartCoroutine("ReadPrompts", promptsIndex);
                }
                else
                {
                    SkipPrompt();
                    Debug.Log("Skipped");
                }
            }        
        }       
    }

    IEnumerator ReadPrompts(int index)
    {
        if (index < prompts.Length)
        {
            Debug.Log("Index " + index);
            StartCoroutine("DisplayMessageAnimation", prompts[index].text);
            yield return null;
        }
        else if (index == prompts.Length)
        {
            PlayerDisable.Instance.EnablePlayer();
            messageDisplayCanvas.SetActive(false);
        }
    }

    void SkipPrompt()
    {
        StopAllCoroutines();
        textMesh.SetText(prompts[promptsIndex].text);
        waitingForInput = true;
        Debug.Log("Waiting for Input SKIP");
    }

    IEnumerator DisplayMessageAnimation(string message)
    {
        string toDisplay = "";
        foreach (char character in message)
        {
            toDisplay += character;
            textMesh.SetText(toDisplay);
            yield return new WaitForSeconds(typingEffectTime);
        }
        inputReadyImage.SetActive(true);
        waitingForInput = true;
        Debug.Log("Waiting for Input DMA");
    }

}
