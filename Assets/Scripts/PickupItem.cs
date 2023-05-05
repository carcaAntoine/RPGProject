using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] private float pickupRange = 2.6f;

    public PickupBehaviour playerPickupBehaviour;
    [SerializeField] private GameObject pickupText;
    [SerializeField] private LayerMask layerMask;

    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.yellow);
        if(Physics.Raycast(transform.position, transform.forward, out hit, pickupRange, layerMask))
        {
            if(hit.transform.CompareTag("Item"))
            {
                Debug.Log("There is an item in front of us");
                pickupText.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    playerPickupBehaviour.DoPickup(hit.transform.gameObject.GetComponent<Item>());
                }
            }
        }
        else
        {
            pickupText.SetActive(false);

        }
    }
}
