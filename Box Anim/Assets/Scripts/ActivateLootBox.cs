using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLootBox : MonoBehaviour
{
    bool hover=false, OneTimeTrigger=true;
    public GameObject LootBox;
    public Transform Camera;
    void Update()
    {
        if(hover && Input.GetKeyDown(KeyCode.Mouse0) && OneTimeTrigger){
            var lbox = Instantiate(LootBox,transform.position,transform.rotation);
            lbox.transform.GetChild(0).GetComponent<ItemsMotion>().MoveTo = Camera;
            OneTimeTrigger=false;
            Destroy(transform.parent.gameObject);
        }
    }
    private void OnMouseEnter(){hover=true;}
    private void OnMouseExit(){hover=false;}
}
