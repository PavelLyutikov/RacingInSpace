using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isPressed = false;
    public PlayerMovement playerMovement;

    void Update()
    {
        if (isPressed)
        {
            playerMovement.rb.AddForce(playerMovement.strefeSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}
