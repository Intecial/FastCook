using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionRange : MonoBehaviour
{

    private bool stationInRange;

    private GameObject interactedObject;
    // Start is called before the first frame update
    void Start()
    {
        stationInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(stationInRange){
            if(Input.GetKeyDown(KeyCode.F)){
                // Call Interact in Station Script;
                Debug.Log("Interacted!!!");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Station")){
            stationInRange = true;
            interactedObject = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Station")){
            stationInRange = false;
            interactedObject = null;
        }
    }
}
