using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishMovement : MonoBehaviour
{
    public GameObject fish;
    private Rigidbody fishrb;
    Vector3 startpos;
    public int speed;

    void Start()
    {
        fishrb = fish.GetComponent<Rigidbody>();
        startpos = fish.transform.position;
    }

   
    void Update()
    {
        fishrb.transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "col")
        {
            fishrb.transform.position = startpos;
        }
    }
}
