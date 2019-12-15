using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateActivation : MonoBehaviour
{

    public bool IsActivated { get; set; }
    [SerializeField] private bool activeObjects = true;
    public GameObject[] ToActivate;

<<<<<<< HEAD
    [SerializeField] private Sprite pressedSprite;
    private Sprite unpressedSprite;

    // This should be set only if 2 pressure plates change the same blocks
    public GameObject linkedPressurePlate;
=======

    [SerializeField] private Sprite pressedSprite;
    private Sprite unpressedSprite;

>>>>>>> forkyVersion

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        unpressedSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
=======

        unpressedSprite = gameObject.GetComponent<SpriteRenderer>().sprite;

>>>>>>> forkyVersion
        IsActivated = false;
        Activate();
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if (IsActivated && activeObjects)
        {
            Deactivate();
            activeObjects = false;
        }
        else if (!IsActivated && !activeObjects)
        {
            if (linkedPressurePlate != null)
            {
                if (linkedPressurePlate.GetComponent<PressurePlateActivation>().IsActivated == true)
                    return;
            }
            Activate();
            activeObjects = true;
=======
        if (IsActivated && !activeObjects)
        {
            Activate();
            activeObjects = true;

            gameObject.GetComponent<SpriteRenderer>().sprite = pressedSprite;
            

        }
        else if (!IsActivated && activeObjects)
        {
            Deactivate();
            activeObjects = false;

            gameObject.GetComponent<SpriteRenderer>().sprite = unpressedSprite;

>>>>>>> forkyVersion
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Animal") || collision.gameObject.CompareTag("Robot"))
        {
            Debug.Log("Pressure Plate Activated");
            IsActivated = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = pressedSprite;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Animal") || collision.gameObject.CompareTag("Robot"))
        {
            Debug.Log("Pressure Plate Deactivated");
            IsActivated = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = unpressedSprite;
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
