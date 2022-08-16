using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;

    [SerializeField] float pickUpDelay; 
    [SerializeField] Color32 hasPackageColor;
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 255);

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer =  GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log($"Collision with {other}");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Package" && !hasPackage){
            Debug.Log("Package Collected");
            Destroy(other.gameObject, pickUpDelay);
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
        }

        if(other.tag == "Mailbox" && hasPackage){
            Debug.Log("Mailbox Opened");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
