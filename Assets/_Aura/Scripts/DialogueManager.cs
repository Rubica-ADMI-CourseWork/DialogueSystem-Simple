using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    Logger logger;
    public bool canLogDebugMessages = true;
    //Keep track of all sentences in our dialogue
    public Queue<string> sentencesInDialogue;

    private void Start()
    {
        logger = FindObjectOfType<Logger>();
        sentencesInDialogue = new Queue<string>();
    }

    public void StartUpDialogue(Dialogue dialogueToLoad)
    {
        //clear any previous sentences from the queue of sentences
        sentencesInDialogue.Clear();

        //add the incoming sentences onto the queue in order
        foreach(var sentence in dialogueToLoad.dialogueSentences)
        {
            sentencesInDialogue.Enqueue(sentence);
        }

        //now that we have sentences in the queue, start up the dialogue
        //and display the next sentence
        DisplayDialogueSentences();
    }

    /// <summary>
    /// This method is plugged into whatever event is in charge of continueing the dialogue
    /// </summary>
    public void DisplayDialogueSentences()
    {
        //quick check if there are any sentences to display
        if(sentencesInDialogue.Count == 0)
        {
            //end the dialogue
            EndDialogue();
        }
        else
        {
            string currentSentence =  sentencesInDialogue.Dequeue(); //load a sentence from the queue and maybe display it
            logger.LogDebugMessages(currentSentence,this,canLogDebugMessages);
        }
    }

    private void EndDialogue()
    {
        logger.LogDebugMessages("No more Messages", this, canLogDebugMessages);
    }
}
