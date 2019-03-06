using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holes : MonoBehaviour
{
    public GameObject hol;
    private GameObject []abc;
    new Vector3 []a = new Vector3[6];
    int j = 0;bool gameover = false;

    void Start()
    {
        StartCoroutine(GenerateHoles());
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 temp = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 3.95f);
            for (int i = 1; i <= 6; i++)
            {
                if(temp==a[i])
                {
                    Destroy(abc[i]);
                }
            }
        }
    }

    IEnumerator GenerateHoles()
    {
        if (j < 6)
        {
            abc[j] = Instantiate(hol, new Vector3(Random.Range(-12, 12), Random.Range(-4, 5), 3.95f), this.transform.rotation);
            j++;
            for (int i = 1; i <= 6; i++)
            {
                if (a[i] == null)
                {
                    a[i] = abc[i].transform.position;
                    gameover = false;
                    break;
                }
                else
                    gameover = true;

            }

            if (gameover == true)
                Gameover();

            yield return new WaitForSeconds(Random.Range(0.5f, 2.0f));

            abc[j] = Instantiate(hol, new Vector3(Random.Range(-12, 12), Random.Range(-4, 5), 3.95f), this.transform.rotation);
            j++;
            for (int i = 1; i <= 6; i++)
            {
                if (a[i] == null)
                {
                    a[i] = abc[i].transform.position;
                    gameover = false;
                    break;
                }
                else
                    gameover = true;

            }

            if (gameover == true)
                Gameover();

            yield return new WaitForSeconds(Random.Range(2.2f, 4.4f));
            StartCoroutine(GenerateHoles());
        }
    }

    public void Gameover()
    {

    }
}
