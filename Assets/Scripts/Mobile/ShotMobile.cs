using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMobile : MonoBehaviour
{
    public float speed = 2;
    public float lifetime = 2;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
