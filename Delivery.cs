using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColour = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColour = new Color32(1, 1, 1, 1);
    [SerializeField] float destroyDelay = 0.5f;

    bool hasPackage = false;
    int numberOfPackagesDelivered = 0;

    SpriteRenderer spriteRenderer;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnCollisionEnter2D(Collision2D other) {  // by default, these variables we are forwarding are actually for the things we hit
        Debug.Log("You crashed");
    }

    public void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Package" && !hasPackage){
            Debug.Log("You've picked up a package!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColour;
            Destroy(other.gameObject, destroyDelay); // you have to tell the Destroy() method two things, the item you want to destroy and the time delay (0 default)
        }

        else if (other.tag == "Customer" && hasPackage) {

            Debug.Log("You've gotten to the customer!");
            hasPackage = false;
            numberOfPackagesDelivered++;
            spriteRenderer.color = noPackageColour;
            Debug.Log("Your total number of packages you delivered is: " + numberOfPackagesDelivered);
             Destroy(other.gameObject, destroyDelay);
        }
        
    }

   /* public void OnTriggerExit2D(Collider2D other) {
        Debug.Log("You've left a zone!");
    }
    */
}
