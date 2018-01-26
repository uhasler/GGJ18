using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeltGenerierung : MonoBehaviour {


    public int x = 10, y = 10;
    public int mineMax = 10;
    public GameObject[,] spielfeld;
	// Use this for initialization
	void Start () {
        //Weltgenerierung
        spielfeld = new GameObject[x,y];
        Camera camera = GetComponent<Camera>();
        
        for (int i=0; i < x; i++)
        {
            for(int j = 0; j < y; j++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.AddComponent<Feldwerte>();
                cube.AddComponent<GUIText>();
                //cube.AddComponent<Mat>
                

                cube.transform.position = new Vector3((float)(i * 15)+7.5f-x*7.5f,(float)(j*15)+7.5f-y*7.5f,0);

                spielfeld[i, j] = cube;
            }
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
