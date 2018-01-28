﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feldwerte : MonoBehaviour {
  public  bool ismine=false;
  public  bool isflagged = false;
    public bool isopen = false;
  public  int nachbarn = 0;
   
  public Texture2D bildf;
  public  Texture2D bildnf;
  public  Texture2D bildm;
  public  Texture2D bild0;
  public  Texture2D bild1;
  public  Texture2D bild2;
  public  Texture2D bild3;
  public  Texture2D bild4;
  public  Texture2D bild5;
  public  Texture2D bild6;
  public  Texture2D bild7;
  public  Texture2D bild8;
   public int x, y,ymax,xmas;
    public GameObject parrent;
    public GameObject self;
    public GameObject peter;
    public Vector3 soll;



    
	// Use this for initialization
	void Start () {
		
	}
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))//rechts
        {
            if (parrent.GetComponent<WeltGenerierung>().gamerun&& !parrent.GetComponent<WeltGenerierung>().gamewon)
            {
                
                if (!isopen)
                {
                    isflagged = !isflagged;
                    if (isflagged)
                    {
                        GetComponent<MeshRenderer>().material.mainTexture = bildf;
                    }
                    else
                    {
                        GetComponent<MeshRenderer>().material.mainTexture = bildnf;
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(0))//links
        {
            if (parrent.GetComponent<WeltGenerierung>().gamerun&& !parrent.GetComponent<WeltGenerierung>().gamewon)
            {

                if (ismine && !isflagged)
                {
                    isopen = true;
                    GetComponent<MeshRenderer>().material.mainTexture = bildm;
                    GameObject[,] exit = parrent.GetComponent<WeltGenerierung>().spielfeld;
                    parrent.GetComponent<WeltGenerierung>().isminekolide = true;
                    parrent.GetComponent<WeltGenerierung>().gamerun = false;
                    soll = new Vector3((x - xmas / 2) * 15, (y - ymax / 2) * 15, 0);
                    parrent.GetComponent<WeltGenerierung>().soll = soll;
                    //self.GetComponent<Transform>().localScale = new Vector3(100, 100, 1);
                }
                else if (!ismine && !isflagged)
                {
                    isopen = true;
                    soll = new Vector3(peter.GetComponent<Transform>().position.x, (y - ymax / 2) * 15, 0);
                    parrent.GetComponent<WeltGenerierung>().soll = soll;
                    switch (nachbarn)
                    {
                        case 0:
                            GetComponent<MeshRenderer>().material.mainTexture = bild0;
                            parrent.GetComponent<WeltGenerierung>().NachbarnAufdecken(x, y);
                            break;
                        case 1:
                            GetComponent<MeshRenderer>().material.mainTexture = bild1;
                            break;
                        case 2:
                            GetComponent<MeshRenderer>().material.mainTexture = bild2;
                            break;
                        case 3:
                            GetComponent<MeshRenderer>().material.mainTexture = bild3;
                            break;
                        case 4:
                            GetComponent<MeshRenderer>().material.mainTexture = bild4;
                            break;
                        case 5:
                            GetComponent<MeshRenderer>().material.mainTexture = bild5;
                            break;
                        case 6:
                            GetComponent<MeshRenderer>().material.mainTexture = bild6;
                            break;
                        case 7:
                            GetComponent<MeshRenderer>().material.mainTexture = bild7;
                            break;
                        case 8:
                            GetComponent<MeshRenderer>().material.mainTexture = bild8;
                            break;
                    }
                }
            }
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
