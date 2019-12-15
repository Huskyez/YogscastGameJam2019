using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateActivation : MonoBehaviour
{

    public bool IsActivated { get; set; }
    private bool activeObjects = false;
    public GameObject[] ToActivate;

<<<<<<< HEAD
    [SerializeField] private Sprite pressedSprite;
    private Sprite unpressedSprite;
=======
>>>>>>> ionutVersion

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        unpressedSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
=======
>>>>>>> ionutVersion
        IsActivated = false;
        Deactivate();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsActivated && !activeObjects)
        {
            Activate();
            activeObjects = true;
<<<<<<< HEAD
            gameObject.GetComponent<SpriteRenderer>().sprite = pressedSprite;
            
=======
>>>>>>> ionutVersion
        }
        else if (!IsActivated && activeObjects)
        {
            Deactivate();
            activeObjects = false;
<<<<<<< HEAD
            gameObject.GetComponent<SpriteRenderer>().sprite = unpressedSprite;
=======
>>>>>>> ionutVersion
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Animal") || collision.gameObject.CompareTag("Robot"))
        {
            Debug.Log("Pressure Plate Activated");
            IsActivated = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Animal") || collision.gameObject.CompareTag("Robot"))
        {
            Debug.Log("Pressure Plate Deactivated");
            IsActivated = false;
        }
    }


    private void Activate()
    {
        foreach (var obj in ToActivate)
        {
            obj.SetActive(true);
        }
    }

    private void Deactivate()
    {
        foreach (var obj in ToActivate)
        {
            obj.SetActive(false);
        }
    }
}
