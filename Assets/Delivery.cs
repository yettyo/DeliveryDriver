using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] float destroyDelayTime = 0.5f;
    bool hasPackage; //Boolean default is false in Unity
    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    


    //void OnCollisionStay2D(Collision2D other) {
    //    Debug.Log("Ouch!");
    //}

    void OnTriggerEnter2D(Collider2D other) {

        // If (the thing we trigger is the package)
        // then print "package picked up" to the console
        if (other.tag == "Package" && !hasPackage) {
            Debug.Log("Package picked up");
            hasPackage = true;
            //After picking up a package, change our car color
            spriteRenderer.color = hasPackageColor;
            //After picking it up, destroy it
            Destroy(other.gameObject, destroyDelayTime);


        }
        
        if (other.tag == "Customer" && hasPackage) {
            Debug.Log("Package delivered");
            hasPackage = false;
            //After dropping a package, change our car color
            spriteRenderer.color = noPackageColor;
            //After dropping it, destroy the customer
            Destroy(other.gameObject, destroyDelayTime);
        } 
    }
}
