using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableManager : MonoBehaviour
{
    public Interactable focus;
 
  /*  private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Interactable>() != null)
        {
            Interactable interactable = other.gameObject.GetComponent<Interactable>();
            if (interactable != null)
            {
                SetFocus(interactable);
            }
        }
    }*/
    void SetFocus(Interactable newFocus)
    {
        focus = newFocus;
    }
}
