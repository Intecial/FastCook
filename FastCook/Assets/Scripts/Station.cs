using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{

    private float time;
    private bool isTiming;

    private GameObject cookedItem;
    void Start()
    {

    }

    void Update()
    {
        if(isTiming){
            Debug.Log(time);
            time -= 1 * Time.deltaTime;
            if(time <= 0){
                cookedItem.GetComponent<Item>().isCooked();
                cookedItem.SetActive(true);
                Debug.Log("Done!!!");
                stopTimer();
            }
        }
    }
    private void startTimer(){
        isTiming = true;
    }

    private void stopTimer(){
        isTiming = false;
    }
    public void interact(GameObject item){
        if (!item.GetComponent<Item>().isRaw){
            return;
        }
        item.SetActive(false);
        item.transform.position = this.transform.position;
        item.transform.parent = null;
        time = 5;
        if(item.gameObject.CompareTag("Item")){
            cookedItem = item;
            startTimer();
        }
    }
}
