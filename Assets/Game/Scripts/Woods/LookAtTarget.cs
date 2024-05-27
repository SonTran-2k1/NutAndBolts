using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        Vector2 direction = target.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle-90));
        transform.rotation = rotation;
    }
}
