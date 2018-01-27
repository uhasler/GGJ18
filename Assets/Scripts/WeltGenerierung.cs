using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeltGenerierung : MonoBehaviour {


    public int x = 10, y = 10;
    public int mineMax = 10;
    public Texture2D bild;
    public Texture2D bildflagged;
    public Texture2D bild2;
    public Texture2D bild3;
    public Texture2D bild4;
    public Texture2D bild5;
    public Texture2D bild6;
    public Texture2D bild7;
    public Texture2D bild8;
    public Texture2D bild1;
    public Texture2D bild0;
    public Texture2D bildnf;
    public Texture2D bildm;

    public GameObject[,] spielfeld;
    public Material materi;
	// Use this for initialization
	void Start () {
        //Weltgenerierung
        spielfeld = new GameObject[x,y];
       // Camera camera = GetComponent<Camera>();
      
        for (int i=0; i < x; i++)
        {
            for(int j = 0; j < y; j++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.AddComponent<Feldwerte>();
                cube.AddComponent<GUIText>();
                //cube.GetComponent<Renderer>().material.mainTexture=bild;
                cube.GetComponent<MeshRenderer>().material=materi;
                materi.mainTexture = bild;
                cube.transform.localScale = new Vector3(15, 15, 1);
                cube.GetComponent<Feldwerte>().x = i;
                cube.GetComponent<Feldwerte>().y = j;



                cube.transform.position = new Vector3((float)(i * 15)+7.5f-x*7.5f,(float)(j*15)+7.5f-y*7.5f,0);
                //cube.
                spielfeld[i, j] = cube;

            }
        }
        
	}
    
    
     
    /*void NachbarnAufdecken(int xp, int yp)
    {
        if (xp - 1 >= 0)
        {
            spielfeld[xp - 1, yp].GetComponent<Feldwerte>().nachbarn;
        }
        if (xp + 1 <= x)
        {
            spielfeld[xp + 1, yp].GetComponent<Feldwerte>().nachbarn;
        }
        if (yp - 1 >= 0)
        {
            spielfeld[xp, yp - 1].GetComponent<Feldwerte>().nachbarn;
        }
        if (yp + 1 <= y)
        {
            spielfeld[xp, yp + 1].GetComponent<Feldwerte>().nachbarn;
        }
    }*/
    public int NachbarnErmitteln(int xp, int yp)
    {
        int ret = 0;

       
        
            if (xp - 1 >= 0)
            {
                if (spielfeld[xp - 1, yp].GetComponent<Feldwerte>().ismine)
                {
                    ret++;
                }
            }
            if (xp + 1 <= x)
            {
                if (spielfeld[xp + 1, yp].GetComponent<Feldwerte>().ismine)
                {
                    ret++;
                }
            }
            if (yp - 1 >= 0)
            {
                if (spielfeld[xp , yp-1].GetComponent<Feldwerte>().ismine)
                {
                    ret++;
                }
            }
            if (yp + 1 <= y)
            {
                if (spielfeld[xp , yp+1].GetComponent<Feldwerte>().ismine)
                {
                    ret++;
                }
            }
            if (xp - 1 >= 0&& yp - 1 >= 0)
            {
                if (spielfeld[xp - 1, yp-1].GetComponent<Feldwerte>().ismine)
                {
                    ret++;
                }
            }
            if (xp + 1 <= x&& yp + 1 >= y)
            {
                if (spielfeld[xp + 1, yp+1].GetComponent<Feldwerte>().ismine)
                {
                    ret++;
                }
            }
            if (yp - 1 >= 0&& xp + 1 <= x)
            {
                if (spielfeld[xp+1, yp - 1].GetComponent<Feldwerte>().ismine)
                {
                    ret++;
                }
            }
            if (yp + 1 <= y&& xp - 1 >= 0)
            {
                if (spielfeld[xp-1, yp + 1].GetComponent<Feldwerte>().ismine)
                {
                    ret++;
                }
            }


        


        return ret;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
