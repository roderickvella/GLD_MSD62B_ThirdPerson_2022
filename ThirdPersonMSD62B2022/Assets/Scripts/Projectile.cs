using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float initialForce;
    public float lifeTime;
    private float lifeTimer = 0f;
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //add initial force to the rigidbody (attached to this grenade)
        GetComponent<Rigidbody>().AddRelativeForce(0, 0, initialForce);
    }

    // Update is called once per frame
    void Update()
    {
        //update the timer
        lifeTimer += Time.deltaTime;

        //when timer is reached, destroy projectile (grenade) and spawn the explosion
        if(lifeTimer >= lifeTime)
        {
            Explode();
        }

    }

    private void Explode()
    {
        //instantiate the explosion prefab
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject); //destroy this.gameObject (the grenade)
    }


}
