using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;
    private GameManagerScript gamemng;
    private AudioSource firstAudioSrc;
    private AudioSource secondAudioSrc;

    private float waitTime = -1.0f;

    private void Start()
    {
        gamemng = FindObjectOfType<GameManagerScript>();

        firstAudioSrc = gamemng.gameObject.GetComponents<AudioSource>()[0];
        secondAudioSrc = gamemng.GetComponents<AudioSource>()[1];
    }

    private void Update()
    {
        if (waitTime == -1.0f)
        {
            return;    
        }
        waitTime -= Time.deltaTime;

        if (waitTime < 0.0f)
        {
            GameObject.FindGameObjectWithTag("PressurePlate").GetComponent<PressurePlateActivation>().Deactivate();
        }
    }

    public void TriggerDialogue()
    {

        
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {



        if (collision.gameObject.CompareTag("Robot"))
        {
            if(gameObject.name != "FinaleTrigger")
            {
                TriggerDialogue();
            }
            
        }
        
        if(gameObject.name == "FinaleTrigger")
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
                        GameObject.FindGameObjectWithTag("PressurePlate").GetComponent<PressurePlateActivation>().Activate();
                        waitTime = 30.0f;
                    }


                }
            }
        }
    }
}
