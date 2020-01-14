using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerCollider();
    }

    // Update is called once per frame

    void AddNonTriggerCollider()
    {
        Collider component = gameObject.AddComponent<BoxCollider>();
        component.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        Instantiate(deathFX, transform.position, Quaternion.identity);
        print(gameObject.name);
        DestroyObject(gameObject);
    }
}
