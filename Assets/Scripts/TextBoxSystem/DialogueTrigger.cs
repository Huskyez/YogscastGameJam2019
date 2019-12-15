using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;
    private GameManagerScript gamemng;
    private AudioSource firstAudioSrc;
    private AudioSource secondAudioSrc;

    private void Start()
    {
        gamemng = FindObjectOfType<GameManagerScript>();

        firstAudioSrc = gamemng.gameObject.GetComponents<AudioSource>()[0];
        secondAudioSrc = gamemng.GetComponents<AudioSource>()[1];
    }
    public void TriggerDialogue()
    {

        
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Robot"))
        {
            if(this.gameObject.name != "FinaleTrigger")
            {
                TriggerDialogue();
            }
            
        }
        
        if(this.gameObject.name == "FinaleTrigger")
        {
              
            if (gamemng.LevelToLoad == "Final")
            {
                print(gamemng.name);
                if (collision.gameObject.CompareTag("Animal"))
                {

                    if (collision.gameObject.GetComponent<ObjectSlot>().heldObjects != null)
                    {
                        TriggerDialogue();
                        //TriggerMusic
                        secondAudioSrc.Play();
                        firstAudioSrc.volume = 0.01f;
                    }


                }
            }
        }
        


    }
}
