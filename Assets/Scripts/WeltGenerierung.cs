using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WeltGenerierung : MonoBehaviour {


    public int x = 10, y = 10;
    public int mineMax = 10;
    public Texture2D bild;
    public bool isminekolide=false;
    bool zuen = false;
    public Texture2D bildflagged;
    public bool gamerun = true;
    public bool gamewon = false;
    public Texture2D bild2;
    public Vector3 soll;
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
    float direkt = 4;//hiflezur bewegung
    public GameObject starterr;
    public GameObject cam;
    public GameObject background;
    public GameObject peter, restarter;
    public Texture2D pet1, pet2, pet3, pet4;
    private int icount = 0;
    public Text minest, sek, win;
    public int zeit=0, anz=0, zeits=0;

    public GameObject[,] spielfeld;
    public Material materi;
    // Use this for initialization
    public void Start()
    {
        //Weltgenerierung
        spielfeld = new GameObject[x, y];
        // Camera camera = GetComponent<Camera>();

        cam.GetComponent<Camera>().orthographicSize = (x+y*0.8f)/2*15;
        background.GetComponent<Transform>().localScale = new Vector3((float)(x+y)/2 * 30f * 16f / 9f, (float)(x+y)/2 * 30 , 1);
        background.GetComponent<Transform>().position = new Vector3(0, 0, 0);
        //Zufallsgenerator
        int[] mines = new int[mineMax];
        int k = 0;
        System.Random random = new System.Random();
        bool different = true;
        while (k < mineMax)//Maria erzeugt ein zufalls array von zahlen die zufaelligsind
        {
            different = true;
            
            int randomNumber = random.Next(0, x * y );

            for (int i = 0; i < k; i++)
            {
                if (randomNumber == mines[i])
                {
                    different = false;
                }
            }

            if (different)
            {
                mines[k] = randomNumber;
                k++;
            }

        }

        //


        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.AddComponent<Feldwerte>();
                cube.AddComponent<GUIText>();
                //cube.GetComponent<Renderer>().material.mainTexture=bild;
                cube.GetComponent<MeshRenderer>().material = materi;
                materi.mainTexture = bild;
                cube.transform.localScale = new Vector3(15, 15, 1);
                cube.GetComponent<Feldwerte>().x = i;
                cube.GetComponent<Feldwerte>().y = j;
                cube.GetComponent<Feldwerte>().ymax = y;

                cube.GetComponent<Feldwerte>().xmas = x;
                cube.GetComponent<Feldwerte>().bild0 = bild0;
                cube.GetComponent<Feldwerte>().bild1 = bild1;
                cube.GetComponent<Feldwerte>().bild2 = bild2;
                cube.GetComponent<Feldwerte>().bild3 = bild3;
                cube.GetComponent<Feldwerte>().bild4 = bild4;
                cube.GetComponent<Feldwerte>().bild5 = bild5;
                cube.GetComponent<Feldwerte>().bild6 = bild6;
                cube.GetComponent<Feldwerte>().bild7 = bild8;
                cube.GetComponent<Feldwerte>().bild8 = bild7;
                cube.GetComponent<Feldwerte>().bildf = bildflagged;
                cube.GetComponent<Feldwerte>().bildnf = bildnf;
                cube.GetComponent<Feldwerte>().bildm = bildm;
                cube.GetComponent<Feldwerte>().parrent = starterr;
                cube.GetComponent<Feldwerte>().self = cube;
                cube.GetComponent<Feldwerte>().peter = peter;


                cube.transform.position = new Vector3((float)(i * 15) + 7.5f - x * 7.5f, (float)(j * 15) + 7.5f - y * 7.5f, 0);
                //cube.
                spielfeld[i, j] = cube;

            }
        }//array spielfeld erschaffen
        k = 0;
        while (k < mines.Length)
        {
            spielfeld[mines[k] % x, mines[k] / x].GetComponent<Feldwerte>().ismine = true;
            k++;
        }//minen einsortieren
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                spielfeld[i, j].GetComponent<Feldwerte>().nachbarn = NachbarnErmitteln(i, j);
            }
        }//


        //peter animation setzen
        peter.GetComponent<MeshRenderer>().material.mainTexture = pet1;
        peter.GetComponent<Transform>().localScale = new Vector3(15, 30, 1);
        peter.GetComponent<Transform>().localPosition = new Vector3(x / 2 * 15 +10, y/2 *15-15,0);
        


    }
    public void NachbarnAufdecken(int xp, int yp)
    {
    int nach=0;
        if (xp - 1 >= 0&& !spielfeld[xp-1, yp].GetComponent<Feldwerte>().isflagged)
        {
            nach = spielfeld[xp - 1, yp].GetComponent<Feldwerte>().nachbarn;
            spielfeld[xp-1, yp ].GetComponent<Feldwerte>().isopen = true;
            if (nach == 0)
            {
                spielfeld[xp - 1, yp].GetComponent<MeshRenderer>().material.mainTexture = bild0;
            }
            else if (nach == 1)
            {
                spielfeld[xp - 1, yp].GetComponent<MeshRenderer>().material.mainTexture = bild1;
            }
            else if (nach == 2)
            {
                spielfeld[xp - 1, yp].GetComponent<MeshRenderer>().material.mainTexture = bild2;
            }
            else if (nach == 3)
            {
                spielfeld[xp - 1, yp].GetComponent<MeshRenderer>().material.mainTexture = bild3;
            }
            else if (nach ==4)
            {
                spielfeld[xp - 1, yp].GetComponent<MeshRenderer>().material.mainTexture = bild4;
            }
            else if (nach == 5)
            {
                spielfeld[xp - 1, yp].GetComponent<MeshRenderer>().material.mainTexture = bild5;
            }
            else if (nach == 6)
            {
                spielfeld[xp - 1, yp].GetComponent<MeshRenderer>().material.mainTexture = bild6;
            }
            else if (nach == 7)
            {
                spielfeld[xp - 1, yp].GetComponent<MeshRenderer>().material.mainTexture = bild7;
            }
            else if (nach == 8)
            {
                spielfeld[xp - 1, yp].GetComponent<MeshRenderer>().material.mainTexture = bild8;
            }
        }
        if (xp + 1 < x&&!spielfeld[xp +1, yp].GetComponent<Feldwerte>().isflagged)
        {
           nach= spielfeld[xp + 1, yp].GetComponent<Feldwerte>().nachbarn;
            spielfeld[xp+ 1, yp ].GetComponent<Feldwerte>().isopen = true;
            if (nach == 0)
            {
                spielfeld[xp + 1, yp].GetComponent<MeshRenderer>().material.mainTexture = bild0;
            }
            else if (nach == 1)
            {
                spielfeld[xp + 1, yp].GetComponent<MeshRenderer>().material.mainTexture = bild1;
            }
            else if (nach == 2)
            {
                spielfeld[xp + 1, yp].GetComponent<MeshRenderer>().material.mainTexture = bild2;
            }
            else if (nach == 3)
            {
                spielfeld[xp + 1, yp].GetComponent<MeshRenderer>().material.mainTexture = bild3;
            }
            else if (nach == 4)
            {
                spielfeld[xp + 1, yp].GetComponent<MeshRenderer>().material.mainTexture = bild4;
            }
            else if (nach == 5)
            {
                spielfeld[xp + 1, yp].GetComponent<MeshRenderer>().material.mainTexture = bild5;
            }
            else if (nach == 6)
            {
                spielfeld[xp + 1, yp].GetComponent<MeshRenderer>().material.mainTexture = bild6;
            }
            else if (nach == 7)
            {
                spielfeld[xp + 1, yp].GetComponent<MeshRenderer>().material.mainTexture = bild7;
            }
            else if (nach == 8)
            {
                spielfeld[xp + 1, yp].GetComponent<MeshRenderer>().material.mainTexture = bild8;
            }
        }
        if (yp - 1 >= 0&&!spielfeld[xp , yp- 1].GetComponent<Feldwerte>().isflagged)
        {
           nach= spielfeld[xp, yp - 1].GetComponent<Feldwerte>().nachbarn;
            spielfeld[xp, yp - 1].GetComponent<Feldwerte>().isopen = true;
            if (nach == 0)
            {
                spielfeld[xp , yp- 1].GetComponent<MeshRenderer>().material.mainTexture = bild0;
            }
            else if (nach == 1)
            {
                spielfeld[xp , yp- 1].GetComponent<MeshRenderer>().material.mainTexture = bild1;
            }
            else if (nach == 2)
            {
                spielfeld[xp, yp - 1].GetComponent<MeshRenderer>().material.mainTexture = bild2;
            }
            else if (nach == 3)
            {
                spielfeld[xp, yp - 1].GetComponent<MeshRenderer>().material.mainTexture = bild3;
            }
            else if (nach == 4)
            {
                spielfeld[xp, yp - 1].GetComponent<MeshRenderer>().material.mainTexture = bild4;
            }
            else if (nach == 5)
            {
                spielfeld[xp, yp - 1].GetComponent<MeshRenderer>().material.mainTexture = bild5;
            }
            else if (nach == 6)
            {
                spielfeld[xp, yp - 1].GetComponent<MeshRenderer>().material.mainTexture = bild6;
            }
            else if (nach == 7)
            {
                spielfeld[xp, yp - 1].GetComponent<MeshRenderer>().material.mainTexture = bild7;
            }
            else if (nach == 8)
            {
                spielfeld[xp, yp - 1].GetComponent<MeshRenderer>().material.mainTexture = bild8;
            }
        }
        if (yp + 1 < y&&!spielfeld[xp , yp+ 1].GetComponent<Feldwerte>().isflagged)
        {
            nach=spielfeld[xp, yp + 1].GetComponent<Feldwerte>().nachbarn;
            spielfeld[xp, yp + 1].GetComponent<Feldwerte>().isopen=true;
            if (nach == 0)
            {
                spielfeld[xp, yp + 1].GetComponent<MeshRenderer>().material.mainTexture = bild0;
            }
            else if (nach == 1)
            {
                spielfeld[xp, yp + 1].GetComponent<MeshRenderer>().material.mainTexture = bild1;
            }
            else if (nach == 2)
            {
                spielfeld[xp, yp + 1].GetComponent<MeshRenderer>().material.mainTexture = bild2;
            }
            else if (nach == 3)
            {
                spielfeld[xp, yp + 1].GetComponent<MeshRenderer>().material.mainTexture = bild3;
            }
            else if (nach == 4)
            {
                spielfeld[xp, yp + 1].GetComponent<MeshRenderer>().material.mainTexture = bild4;
            }
            else if (nach == 5)
            {
                spielfeld[xp, yp + 1].GetComponent<MeshRenderer>().material.mainTexture = bild5;
            }
            else if (nach == 6)
            {
                spielfeld[xp, yp + 1].GetComponent<MeshRenderer>().material.mainTexture = bild6;
            }
            else if (nach == 7)
            {
                spielfeld[xp, yp + 1].GetComponent<MeshRenderer>().material.mainTexture = bild7;
            }
            else if (nach == 8)
            {
                spielfeld[xp, yp + 1].GetComponent<MeshRenderer>().material.mainTexture = bild8;
            }
        }
    }
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
            if (xp + 1 < x)
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
            if (yp + 1 < y)
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
            if (xp + 1 < x&& yp + 1 < y)
            {
                if (spielfeld[xp + 1, yp+1].GetComponent<Feldwerte>().ismine)
                {
                    ret++;
                }
            }
            if (yp - 1 >= 0&& xp + 1 < x)
            {
                if (spielfeld[xp+1, yp - 1].GetComponent<Feldwerte>().ismine)
                {
                    ret++;
                }
            }
            if (yp + 1 < y&& xp - 1 >= 0)
            {
                if (spielfeld[xp-1, yp + 1].GetComponent<Feldwerte>().ismine)
                {
                    ret++;
                }
            }


        


        return ret;
    }

    // Update is called once per frame
    void Update() {
        int end = 0;
        int sin = 0;

        /*if (zeit == 59)
        {
            zeit = 0;
            zeits++;
            sek.text = zeits.ToString();
        }*/

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                if (spielfeld[i, j].GetComponent<Feldwerte>().ismine && spielfeld[i, j].GetComponent<Feldwerte>().isflagged)
                {
                    end++;

                }
                if (spielfeld[i, j].GetComponent<Feldwerte>().isflagged)
                {
                    sin++;
                }
            }
        }
        minest.text = (mineMax - sin).ToString();
        if (end == mineMax && sin == mineMax)//end animation
        {
            peter.GetComponent<Transform>().position += new Vector3(-1, 0, 0);
            gamewon = true;
            win.text = "You Won the Game in " + zeits.ToString() + "s";
        }
        icount = ++icount % 60;
        icount++;
        if (!isminekolide && !gamewon)
        {
            zeit++;
            if (zeit == 59)
            {
                zeit = 0;
                zeits++;
                sek.text = zeits.ToString();
            }
            if (peter.GetComponent<Transform>().position.y < soll.y)
            {
                peter.GetComponent<Transform>().position += new Vector3(0, 1, 0);
            }
            if (peter.GetComponent<Transform>().position.y > soll.y)
            {
                peter.GetComponent<Transform>().position += new Vector3(0, -1, 0);
            }
        }
        if (isminekolide)
        {
            if (peter.GetComponent<Transform>().position.y < soll.y && !zuen)
            {
                peter.GetComponent<Transform>().position += new Vector3(0, 1, 0);
            }
            if (peter.GetComponent<Transform>().position.x < soll.x && !zuen)
            {
                peter.GetComponent<Transform>().position += new Vector3(1, 0, 0);
            }
            if (peter.GetComponent<Transform>().position.y > soll.y && !zuen)
            {
                peter.GetComponent<Transform>().position += new Vector3(0, -1, 0);
            }
            if (peter.GetComponent<Transform>().position.x > soll.x && !zuen)
            {
                peter.GetComponent<Transform>().position += new Vector3(-1, 0, 0);
            }
            if (peter.GetComponent<Transform>().position.x == soll.x && peter.GetComponent<Transform>().position.y == soll.y)
            {
                zuen = true;
                win.text = "You Lost the Game with " + (mineMax - end).ToString() + " Mines left";

            }
            if (zuen)
            {
                peter.GetComponent<Transform>().position += new Vector3(3f, (-y / 6) * direkt, 0);
                peter.GetComponent<Transform>().localScale += new Vector3(0.2f, 0.2f, 0);
                direkt = direkt - 0.1f;
                if (direkt < -20)
                {
                    isminekolide = false;
                    zuen = false;

                    gamerun = true;
                    gamewon = false;
                    icount = 0;

                    zeit = 0; anz = 0; zeits = 0;
                    direkt = 4;
                    win.text = "";
                    for (int i = 0; i < x; i++)
                    {
                        for (int j = 0; j < y; j++)
                        {
                            spielfeld[i, j].GetComponent<Transform>().position += new Vector3(5000, 5000, -500);
                        }
                    }
                            Start();
                    

                }
            }
        } 
        if (icount < 15)
        {
            peter.GetComponent<MeshRenderer>().material.mainTexture = pet1;
        }
        else if (icount < 30)
        {
            peter.GetComponent<MeshRenderer>().material.mainTexture = pet2;
        }
        else if (icount < 45)
        {
            peter.GetComponent<MeshRenderer>().material.mainTexture = pet3;
        }
        else if (icount < 60)
        {
            peter.GetComponent<MeshRenderer>().material.mainTexture = pet4;
        }


    }
}
