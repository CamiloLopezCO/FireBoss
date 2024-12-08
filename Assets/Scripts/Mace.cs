using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace : MonoBehaviour
{
    public float speed = 0.8f;
    public float range = 3;
    public float scaleIncrease = 0.1f;  // Amount by which the size increases
    public float scaleInterval = 2f;    // Interval (in seconds) for size growth
    public float maxScale = 5f;         // Maximum allowed mace
    private float startingY;
    private int dir = 1;

    // Start is called before the first frame update
    void Start()
    {
        startingY = transform.position.y;
        InvokeRepeating(nameof(IncreaseSize), scaleInterval, scaleInterval);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime * dir);
        if (transform.position.y < startingY || transform.position.y > startingY + range)
            dir *= -1;
    }

    void IncreaseSize()
    {
        transform.localScale += new Vector3(scaleIncrease, scaleIncrease, scaleIncrease);
    }
}