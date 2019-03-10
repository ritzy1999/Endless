﻿using UnityEngine;
using System.Collections;

public class FishData : MonoBehaviour
{

    public Material mat;
    public Rigidbody rb;
    public Animator anim;
    public bool isDead = false;
    public Color fishColor;
    public bool isSchoolLeader = false;
    public string school = null;
    public int memoryUtilization;
    public int cpuCount;
    public float avgLoad;
    public float baseScale = 1f;
    bool flash = false;
    public GameObject tank;
    public GameObject tankWalls;
    public Vector3 corner;
    public Vector3 origin;
    public float cornerDistance;

    public int numberOfFollowers;
    public int numberOfLivingFollowers;
    public int numberOfDeadFollowers;

    public float tankWallBack, tankWallLeft, tankWallRight, tankWallFront, tankWallFloor, tankWallTop;

    void Awake()
    {
        /*tank = GameObject.Find("tank");
        tankWalls = tank.transform.Find("tank walls").gameObject;
        tankWallBack = tankWalls.transform.Find("Plane").transform.position.z;
        tankWallLeft = tankWalls.transform.Find("Plane (1)").transform.position.x;
        tankWallRight = tankWalls.transform.Find("Plane (2)").transform.position.x;
        tankWallFront = tankWalls.transform.Find("Plane (3)").transform.position.z;
        tankWallFloor = tankWalls.transform.Find("tank floor").transform.position.y;
        tankWallTop = tankWalls.transform.Find("tank top").transform.position.y;
        origin = tank.transform.Find("center").transform.position;
        corner = tank.transform.Find("corner").transform.position;*/
        cornerDistance = Vector3.Distance(origin, corner);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        mat = GetComponentInChildren<Renderer>().material;
        SetColor(Color.cyan);
    }

    void Update()
    {
        if (flash && !isDead)
        {
            float t = Mathf.PingPong(Time.time, 1f);
            mat.color = Color.Lerp(fishColor, new Color(fishColor.r, fishColor.g, 1), t);
        }
        //float distance = Vector3.Distance (transform.position, origin);
        if ((tankWalls.activeSelf && (transform.position.x > tankWallRight || transform.position.x < tankWallLeft ||
            transform.position.y > tankWallTop || transform.position.y < tankWallFloor ||
            transform.position.z > tankWallBack || transform.position.z < tankWallFront)) || (cornerDistance < Vector3.Distance(transform.position, origin)))
        {
            transform.position = origin;
        }
    }

    public void KillFish()
    {
        //anim.SetBool ("isSwimming", false);
        anim.enabled = false;
        isDead = true;
        rb.useGravity = true;
        SetColor(Color.black);
    }

    public void ReviveFish()
    {
        //anim.SetBool ("isSwimming", true);
        anim.enabled = true;
        isDead = false;
        rb.useGravity = false;
        SetColor(fishColor);
    }

    public void SetColor(Color color)
    {
        mat.color = color;
    }

    public string GetMemoryUtilizationFormated()
    {
        double temp = (memoryUtilization * 0.000001);
        string memUtilString = temp.ToString() + " GB";
        return memUtilString;
    }

    public void Resize(float baseScaleAmount)
    {
        if (baseScale == 1)
        {
            baseScale = baseScaleAmount;
            transform.localScale = new Vector3(baseScale, baseScale, baseScale);
        }
        Resize();
    }

    public void Resize()
    {
        if (cpuCount != 0)
        {
            float scalePercentage = avgLoad / cpuCount;
            if (scalePercentage < 0.5f)
            {
                scalePercentage = 0.45f;
                flash = false;
            }
            else if (scalePercentage > 1)
            {
                scalePercentage = 1.05f;
                flash = true;
            }
            else
            {
                flash = false;
            }
            scalePercentage = scalePercentage * baseScale;
            transform.localScale = new Vector3(scalePercentage, scalePercentage, scalePercentage);
        }
    }

    public void GetNumberOfFish()
    {
        numberOfFollowers = 0;
        numberOfLivingFollowers = 0;
        numberOfDeadFollowers = 0;
        GameObject[] listOfFish = GameObject.FindGameObjectsWithTag("fish");
        foreach (GameObject fish in listOfFish)
        {
            FishData data = fish.GetComponent<FishData>();
            if (data.school.Equals(school) && !data.isSchoolLeader)
            {
                numberOfFollowers++;
                if (data.isDead)
                {
                    numberOfDeadFollowers++;
                }
                else
                {
                    numberOfLivingFollowers++;
                }
            }
        }
    }

}