using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [HideInInspector]
    public Vector3 target;

    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(3.0f, 10.0f); // finding a random speed for our enemy
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            // moving towards our target
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

            // rotation the enemy in the direction its moving
            Vector3 moveDirection = target - transform.position;
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    // once we exit the camera the object will destroy itself so it doesn't take up memory in our computer
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
