using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosionForce;
    public float explosionRadius;
    private float lifeTime = 6f;

    // Start is called before the first frame update
    void Start()
    {
        //an array of nearby colliders
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        //a list that is going to hold all the nearby rigidbodies
        List<Rigidbody> rigidbodies = new List<Rigidbody>();

        foreach(Collider collider in colliders)
        {
            //check if the gameobject has a rigidbody
            if(collider.attachedRigidbody != null)
            {
                rigidbodies.Add(collider.attachedRigidbody);
            }
        }

        //apply force on these nearby rigidbodies
        foreach(Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius, 1, ForceMode.Impulse);
        }

        //destroy the gameobject (explosion) after lifeTime
        Destroy(gameObject, lifeTime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
