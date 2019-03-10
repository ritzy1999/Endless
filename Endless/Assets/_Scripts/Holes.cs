using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holes : MonoBehaviour
{
    public GameObject hol;
    int j = 0;

    void Start()
    {
        StartCoroutine(GenerateHoles());
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit , 500))
            {
                Debug.Log(hit.transform.name);
                Debug.DrawRay(new Vector3(this.transform.position.x, 0, this.transform.position.z), this.transform.forward, Color.black);
                if (hit.transform.tag == "crack")
                {
                    Destroy(hit.transform.gameObject);
                    j--;
                }
            }

            
            /*temp = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 3.95f);
            for (int i = 1; i <= 6; i++)
            {    
                    abc[i] = abc[j];
                    a[i] = a[j];
                    a[j] = Vector3.zero;
                    abc[j] = null;
                    j--;
            }*/
        }
        if (j > 7)
            Gameover();
        
    }

    IEnumerator GenerateHoles()
    {
            Instantiate(hol, new Vector3(Random.Range(-12, 12), Random.Range(-4, 5), 1.5f), this.transform.rotation);
            j++;
            
            
            yield return new WaitForSeconds(Random.Range(0.5f, 2.0f));

            Instantiate(hol, new Vector3(Random.Range(-12, 12), Random.Range(-4, 5), 1.5f), this.transform.rotation);
            j++;
            
            yield return new WaitForSeconds(Random.Range(2.2f, 4.4f));
            StartCoroutine(GenerateHoles());
    }

    public void Gameover()
    {
        Debug.Log("GAME OVER");
       // Time.timeScale = 0;
    }
}
