using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    public float speed = 10;

    private float lifeTime = 100;

    public void Shoot(Vector3 pos, Quaternion rotation)
    {
        Instantiate(this, pos, rotation);
    }

    private void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Fighter>())
        {
            other.GetComponentInParent<Animator>().SetTrigger("Damaged");
            Destroy(gameObject);
        }
    }
}
