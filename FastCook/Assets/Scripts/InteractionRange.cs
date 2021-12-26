using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionRange : MonoBehaviour
{

    private bool stationInRange;
    private PlayerPickUpRange playerPickUpRangeScript;
    private GameObject interactedObject;
    private void Awake() {
        playerPickUpRangeScript = GetComponent<PlayerPickUpRange>();
    }
    void Start()
    {
        stationInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(stationInRange){
            if(Input.GetKeyDown(KeyCode.F)){
                playerPickUpRangeScript.isHolding = false;
                interactedObject.GetComponent<Station>().interact(playerPickUpRangeScript.heldItem);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Station")){
            if (other.gameObject.GetComponent<Station>().isOccupied == false){
                stationInRange = true;
                interactedObject = other.gameObject;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Station")){
            stationInRange = false;
            interactedObject = null;
        }
    }
}
