using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateActivation : MonoBehaviour
{

    public bool IsActivated { get; set; }
    private bool activeObjects = false;
    public GameObject[] ToActivate;


    // Start is called before the first frame update
    void Start()
    {
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
        }
        else if (!IsActivated && activeObjects)
        {
            Deactivate();
            activeObjects = false;
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
