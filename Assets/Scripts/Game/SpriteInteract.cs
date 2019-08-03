using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInteract : MonoBehaviour
{
    //public Fungus.Flowchart fungusBlock;
    public SpriteRenderer spriteRenderer;
    bool isWithinBounds = false;

    public string ColliderNameCheck;

    //[SerializeField] GameObject mask;

    // [SerializeField] Material material1;
    // [SerializeField] Material material2;
    

    // Use this for initialization
    void Start()
    {
       
        //collider = GetComponent<SphereCollider>();
        //animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.name.Equals(ColliderNameCheck))
        {
            isWithinBounds = true;

            // mask.GetComponent<Renderer>().material = material2;//.Lerp(material1, material2, lerp);
            spriteRenderer.enabled = true;//.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, a: 1);
        }

    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name.Equals(ColliderNameCheck))
        {
            isWithinBounds = false;
            spriteRenderer.enabled = false; //= new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, a: 0);
        }

    }

    public bool getIsWithinBounds()
    {
        return isWithinBounds;
    }

}
