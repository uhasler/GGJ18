using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feldwerte : MonoBehaviour {
  public  bool ismine=false;
  public  bool isflagged = false;
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
   public int x, y;

    
	// Use this for initialization
	void Start () {
		
	}
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))//rechts
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
        if (Input.GetMouseButtonDown(0))//links
        {
            if (ismine&&!isflagged)
            {
                GetComponent<MeshRenderer>().material.mainTexture = bildm;
            }
            else if(!ismine)
            {
                switch (nachbarn)
                {
                    case 0: GetComponent<MeshRenderer>().material.mainTexture = bild0;
                            
                }
            }
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
