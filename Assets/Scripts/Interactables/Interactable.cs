using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(ColorOnHover))]
public class Interactable : MonoBehaviour
{

    public float radius = 3f;
    public Transform interactionTransform;

    bool isFocus = false;   
    Transform player;       

    bool hasInteracted = false; 



    private void Update()
    {
        if (isFocus && !hasInteracted)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Interact();
                hasInteracted = true;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnFocused(other.gameObject.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnDefocused();
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        hasInteracted = false;
        player = playerTransform;
        ((InteractableManager)player.GetComponent("InteractableManager")).focus = this;
    }

    public void OnDefocused()
    {
        isFocus = false;
        hasInteracted = false;
        ((InteractableManager)player.GetComponent("InteractableManager")).focus = null;
    }

    public virtual void Interact()
    {

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

}
