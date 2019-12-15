using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateActivation : MonoBehaviour
{

    public bool IsActivated { get; set; }
    [SerializeField] private bool activeObjects = true;
    public GameObject[] ToActivate;

    [SerializeField] private Sprite pressedSprite;
    private Sprite unpressedSprite;

    // Start is called before the first frame update
    void Start()
    {
        unpressedSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        IsActivated = false;
        Activate();
    }

    // Update is called once per frame
    void Update()
    {

        checkActivatedObjects();

        if (IsActivated && activeObjects)
        {
            Deactivate();
            activeObjects = false;
        }
        else if (!IsActivated && !activeObjects)
        {
            Activate();
            activeObjects = true;
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


    private void checkActivatedObjects()
    {
        activeObjects = ToActivate[0].activeSelf;
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
