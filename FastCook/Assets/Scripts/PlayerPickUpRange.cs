using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpRange : MonoBehaviour
{
    private List<GameObject> itemInRange;
    private bool isHolding;
    public GameObject spawnPoint;

    private GameObject heldItem;
    
    // Start is called before the first frame update
    void Start()
    {
        itemInRange = new List<GameObject>();
        isHolding = false;
    }

    // Update is called once per frame
    void Update()
    {
        processInput();
    }

    private void processInput(){
        if(itemInRange.Count > 0 || isHolding){
            if (Input.GetKeyDown(KeyCode.E)){
                if (!isHolding){
                    pickUp(itemInRange[0]);
                } else if (isHolding){
                    drop();
                }
            }
        }
    }
    private void drop(){
        heldItem.transform.parent = null;
        isHolding = false;

    }
    private void pickUp(GameObject item){
        item.transform.position = spawnPoint.transform.position;
        item.transform.parent = spawnPoint.transform;
        isHolding = true;
        heldItem = item;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Item")){
            itemInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Item")){
            itemInRange.Remove(other.gameObject);
        }
    }
}
