﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateActivation : MonoBehaviour
{

    public bool IsActivated { get; set; }
    [SerializeField] private bool activeObjects = true;
    public GameObject[] ToActivate;

    [SerializeField] private Sprite pressedSprite;
    private Sprite unpressedSprite;

    private GameObject onPressurePlate;

    // This should be set only if 2 pressure plates change the same blocks
    public GameObject linkedPressurePlate;

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
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Animal") || collision.gameObject.CompareTag("Robot"))
        {
            Debug.Log("Pressure Plate Activated");
            IsActivated = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = pressedSprite;
            
            if (onPressurePlate == null)
                onPressurePlate = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Animal") || collision.gameObject.CompareTag("Robot"))
        {
            if (onPressurePlate == collision.gameObject)
            {
                Debug.Log("Pressure Plate Deactivated");
                IsActivated = false;
                gameObject.GetComponent<SpriteRenderer>().sprite = unpressedSprite;
                onPressurePlate = null;
            }
        }
    }

    public void Activate()
    {
        foreach (var obj in ToActivate)
        {
            obj.SetActive(true);
        }
    }

    public void Deactivate()
    {
        foreach (var obj in ToActivate)
        {
            obj.SetActive(false);
        }
    }
}
