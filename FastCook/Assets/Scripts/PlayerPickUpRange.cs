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
        if(itemInRange.Count > 0){
            if (Input.GetKeyDown(KeyCode.E)){
                if (!isHolding){
                    pickUp(itemInRange[0]);
                }
            }
        }
        if (isHolding){
            if (Input.GetKeyDown(KeyCode.F)){
                drop();
            }
        }
    }
    private void drop(){
        Transform spawnedItem = spawnPoint.transform.GetChild(0);
        spawnedItem.parent = null;
        Destroy(spawnedItem.gameObject);
        Instantiate(spawnedItem.gameObject, spawnPoint.transform.position, Quaternion.identity);
    }
    private void pickUp(GameObject item){
        itemInRange.Remove(item);
        heldItem = item;
        GameObject spawnedItem = Instantiate(item, spawnPoint.transform.position, Quaternion.identity) as GameObject;
        spawnedItem.transform.parent = spawnPoint.transform;
        isHolding = true;
        Destroy(item);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Item")){
            Debug.Log(other.gameObject.tag);
            itemInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Item")){
            itemInRange.Remove(other.gameObject);
        }
    }
}
