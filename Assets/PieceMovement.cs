using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMovement : MonoBehaviour
{
    public GameObject[,] Grille;
    public GameObject[,] Grille_possibilitées;

    public GameObject b_knight;
    public GameObject b_bishop;
    public GameObject b_rook;
    public GameObject b_queen;
    public GameObject b_pawn;
    public GameObject b_king;

    public GameObject w_knight;
    public GameObject w_bishop;
    public GameObject w_rook;
    public GameObject w_queen;
    public GameObject w_pawn;
    public GameObject w_king;

    public GameObject cylindre_position_possible;

    public Transform Parent;
    public Transform ecart_vertical;
    public Transform ecart_horizontal;
    public Transform gauche_bas;
    public Transform gauche_haut;
    public Transform droite_bas;
    public Transform droite_haut;

    public int nb_cases = 8;

    public List<GameObject> BlackPieceList = new List<GameObject>();
    public List<GameObject> WhitePieceList = new List<GameObject>();

    ArrayList arraypositionclicked = new ArrayList();
    public GameObject nothing;


    void Start()
    {

        Initialisation();


        Grille[3, 2] = Instantiate(b_rook, GrillToMap(3,2), Quaternion.identity, Parent); //test
        BlackPieceList.Add(Grille[3, 2]);


    }

    public void Initialisation()
    {
        Grille = new GameObject[nb_cases, nb_cases];
        Grille_possibilitées = new GameObject[nb_cases, nb_cases];
        /*
        for (int i = 0; i < nb_cases; i++)
        {
            for (int ii = 0; ii < nb_cases; ii++)
            {
                Grille[i, ii] = nothing;
            }
        }
        */

        Grille[1, 0] = Instantiate(b_knight, GrillToMap(1, 0), Quaternion.identity, Parent);
        BlackPieceList.Add(Grille[1, 0]);
        Grille[6, 0] = Instantiate(b_knight, GrillToMap(6, 0), Quaternion.identity, Parent);
        BlackPieceList.Add(Grille[6, 0]);

        Grille[0, 0] = Instantiate(b_rook, GrillToMap(0, 0), Quaternion.identity, Parent);
        BlackPieceList.Add(Grille[0, 0]);
        Grille[7, 0] = Instantiate(b_rook, GrillToMap(7, 0), Quaternion.identity, Parent);
        BlackPieceList.Add(Grille[7, 0]);

        Grille[2, 0] = Instantiate(b_bishop, GrillToMap(2, 0), Quaternion.identity, Parent);
        BlackPieceList.Add(Grille[2, 0]);
        Grille[5, 0] = Instantiate(b_bishop, GrillToMap(5, 0), Quaternion.identity, Parent);
        BlackPieceList.Add(Grille[5, 0]);

        Grille[4, 0] = Instantiate(b_king, GrillToMap(4, 0), Quaternion.identity, Parent);
        BlackPieceList.Add(Grille[4, 0]);
        Grille[3, 0] = Instantiate(b_queen, GrillToMap(3, 0), Quaternion.identity, Parent);
        BlackPieceList.Add(Grille[3, 0]);

        for (int i = 0; i < nb_cases; i++)
        {
            Grille[i, 1] = Instantiate(b_pawn, GrillToMap(i, 1), Quaternion.identity, Parent);
            BlackPieceList.Add(Grille[i, 1]);
        }


        Grille[1, 7] = Instantiate(w_knight, GrillToMap(1, 7), Quaternion.identity, Parent);
        WhitePieceList.Add(Grille[1, 7]);
        Grille[6, 7] = Instantiate(w_knight, GrillToMap(6, 7), Quaternion.identity, Parent);
        WhitePieceList.Add(Grille[6, 7]);

        Grille[0, 7] = Instantiate(w_rook, GrillToMap(0, 7), Quaternion.identity, Parent);
        WhitePieceList.Add(Grille[0, 7]);
        Grille[7, 7] = Instantiate(w_rook, GrillToMap(7, 7), Quaternion.identity, Parent);
        WhitePieceList.Add(Grille[7, 7]);

        Grille[2, 7] = Instantiate(w_bishop, GrillToMap(2, 7), Quaternion.identity, Parent);
        WhitePieceList.Add(Grille[2, 7]);
        Grille[5, 7] = Instantiate(w_bishop, GrillToMap(5, 7), Quaternion.identity, Parent);
        WhitePieceList.Add(Grille[5, 7]);

        Grille[3, 7] = Instantiate(w_king, GrillToMap(3, 7), Quaternion.identity, Parent);
        WhitePieceList.Add(Grille[3, 7]);
        Grille[4, 7] = Instantiate(w_queen, GrillToMap(4, 7), Quaternion.identity, Parent);
        WhitePieceList.Add(Grille[4, 7]);

        for (int i = 0; i < nb_cases; i++)
        {
            Grille[i, 6] = Instantiate(w_pawn, GrillToMap(i, 6), Quaternion.identity, Parent);
            WhitePieceList.Add(Grille[i, 6]);
        }
    }

    public ArrayList OnPieceClicked()
    {
        ArrayList array = new ArrayList();
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit,100.0f) && hit.transform.gameObject!=null && hit.transform.gameObject.name != "position_possible(Clone)")
            {
                print(hit.transform.gameObject.name);
                for (int x = 0; x < nb_cases; x++)
                {
                    for (int y = 0; y < nb_cases; y++)
                    {
                        if (hit.transform.gameObject == Grille[x,y])
                        {
                            //Debug.Log(x + " " + y);
                            array.Add(x);
                            array.Add(y);
                            return array;
                        }
                    }
                }
            }
        }
        return null;
    }


    public void WhoIsClickedBlack(int x, int y)
    {
        if (Grille[x, y].name == "Black Rook(Clone)")
        {
            //print("rook cliked");
            OnRookClickedBlack(x, y);
        }

        if (Grille[x, y].name == "Black Pawn(Clone)")
        {
            //print("rook cliked");
            OnPionClickedBlack(x, y);
        }

        if (Grille[x, y].name == "Black Bishop(Clone)")
        {
            //print("rook cliked");
            OnBishopClickedBlack(x, y);
        }

        if (Grille[x, y].name == "Black King(Clone)")
        {
            //print("rook cliked");
            OnKingClickedBlack(x, y);
        }

        if (Grille[x, y].name == "Black Queen(Clone)")
        {
            //print("rook cliked");
            OnQueenClickedBlack(x, y);
        }

        if (Grille[x, y].name == "Black Knight(Clone)")
        {
            //print("rook cliked");
            OnKnightClickedBlack(x, y);
        }
        
    }

    public void WhoIsClickedWhite(int x, int y)
    {
        if (Grille[x, y].name == "White Rook(Clone)")
        {
            //print("rook cliked");
            OnRookClickedWhite(x, y);
        }

        if (Grille[x, y].name == "White Pawn(Clone)")
        {
            //print("rook cliked");
            OnPionClickedWhite(x, y);
        }

        if (Grille[x, y].name == "White Bishop(Clone)")
        {
            //print("rook cliked");
            OnBishopClickedWhite(x, y);
        }

        if (Grille[x, y].name == "White King(Clone)")
        {
            //print("rook cliked");
            OnKingClickedWhite(x, y);
        }

        if (Grille[x, y].name == "White Queen(Clone)")
        {
            //print("rook cliked");
            OnQueenClickedWhite(x, y);
        }

        if (Grille[x, y].name == "White Knight(Clone)")
        {
            //print("rook cliked");
            OnKnightClickedWhite(x, y);
        }
    }


    public void OnPionClickedBlack(int x, int y)
    {
        bool continue_h = true;
        if (y + 1 < nb_cases && continue_h)
        {
            if (BlackPieceList.Contains(Grille[x , y+1]) || WhitePieceList.Contains(Grille[x, y + 1]))
            {
                continue_h= false;
                //print("1");
            }


            if (y+ 1 < nb_cases && continue_h)
            {
                Grille_possibilitées[x , y+1] = Instantiate(cylindre_position_possible, GrillToMap(x , y+1), Quaternion.identity, Parent);
                //Debug.Log("1 "+x + i + " " + (y + i));          
            }

            if (y==1 && !BlackPieceList.Contains(Grille[x, y + 1]) && !WhitePieceList.Contains(Grille[x, y + 1]))
            {
                Grille_possibilitées[x, y + 2] = Instantiate(cylindre_position_possible, GrillToMap(x, y + 2 ), Quaternion.identity, Parent);
            }

            if (x+1<nb_cases && y+1<nb_cases && WhitePieceList.Contains(Grille[x+1,y+1]))
            {
                Grille_possibilitées[x +1, y + 1] = Instantiate(cylindre_position_possible, GrillToMap(x+1, y+1), Quaternion.identity, Parent);
            }

            if (x-1>=0 && y+1<nb_cases  && WhitePieceList.Contains(Grille[x - 1, y + 1]))
            {
                Grille_possibilitées[x - 1, y + 1] = Instantiate(cylindre_position_possible, GrillToMap(x - 1, y + 1), Quaternion.identity, Parent);
            }


        }
    }

    public void OnPionClickedWhite(int x, int y)
    {
        bool continue_b = true;
        if (y - 1 >=0 && continue_b)
        {
            if (BlackPieceList.Contains(Grille[x, y - 1]) || WhitePieceList.Contains(Grille[x, y - 1]))
            {
                continue_b = false;
                //print("1");
            }


            if (y - 1 >=0 && continue_b)
            {
                Grille_possibilitées[x, y - 1] = Instantiate(cylindre_position_possible, GrillToMap(x, y - 1), Quaternion.identity, Parent);
                //Debug.Log("1 "+x + i + " " + (y + i));          
            }

            if (y == nb_cases-2 && continue_b)
            {
                Grille_possibilitées[x, y - 2] = Instantiate(cylindre_position_possible, GrillToMap(x, y - 2), Quaternion.identity, Parent);
            }

            if (x + 1 < nb_cases && y - 1 >=0 && BlackPieceList.Contains(Grille[x + 1, y- 1]))
            {
                Grille_possibilitées[x + 1, y - 1] = Instantiate(cylindre_position_possible, GrillToMap(x + 1, y - 1), Quaternion.identity, Parent);
            }

            if (x - 1 >= 0 && y - 1 >=0 && BlackPieceList.Contains(Grille[x - 1, y - 1]))
            {
                Grille_possibilitées[x - 1, y - 1] = Instantiate(cylindre_position_possible, GrillToMap(x - 1, y - 1), Quaternion.identity, Parent);
            }


        }
    }


    public void OnRookClickedBlack(int x, int y)
    {
        // print("ok");
        bool continue_d = true;
        bool continue_g = true;
        bool continue_h = true;
        bool continue_b = true;
        //bloobPossiblity2.Contains(Grille[i,j])
        for (int i = 1; i < nb_cases; i++)
        {
            if (x + i < nb_cases )
            {
                if (BlackPieceList.Contains(Grille[x + i, y ]))
                {
                    continue_d = false;
                    //print("1");
                }
            }

            if (y + i < nb_cases )
            {
                //print(Grille[x, y + i]);
                if (BlackPieceList.Contains(Grille[x, y + i]))
                {
                    continue_h = false;
                    //print("2");
                }
            }

            if ( y - i >= 0)
            {
                if (BlackPieceList.Contains(Grille[x , y - i]))
                {
                    continue_b = false;
                    //print("3");
                }
            }

            if ( x - i >= 0)
            {
                if (BlackPieceList.Contains(Grille[x - i, y]))
                {
                    continue_g = false;
                    //print("4");
                }
            }






            if (x + i < nb_cases && continue_d)
            {
                Grille_possibilitées[x + i, y ] = Instantiate(cylindre_position_possible, GrillToMap(x + i, y), Quaternion.identity, Parent);
                //Debug.Log("1 "+x + i + " " + (y + i));          
            }

            if (x - i >=0 && continue_g)
            {
                Grille_possibilitées[x - i, y ] = Instantiate(cylindre_position_possible, GrillToMap(x - i, y), Quaternion.identity, Parent);
                //Debug.Log("2 " + (x - i) + " " + (y - i));
            }

            if  (y - i >= 0 && continue_b)
            {
                Grille_possibilitées[x, y - i] = Instantiate(cylindre_position_possible, GrillToMap(x , y - i), Quaternion.identity, Parent);
                //Debug.Log("3 " + x + i + " " + (y - i));
            }

            if (y+i<nb_cases && continue_h)
            {
                Grille_possibilitées[x , y + i] = Instantiate(cylindre_position_possible, GrillToMap(x , y + i), Quaternion.identity, Parent);
                //Debug.Log("4 " + (x - i) + " " + (y + i));
            }





            if (x + i < nb_cases )
            {
                if (Grille[x + i, y] != null)
                {
                    continue_d = false;
                }
            }

            if (x - i >=0)
            {
                if (Grille[x - i, y] != null)
                {
                    continue_g = false;
                }
            }

            if (y - i >= 0)
            {
                if (Grille[x , y - i] != null)
                {
                    continue_b = false;
                }
            }

            if ( y + i < nb_cases )
            {
                if (Grille[x , y + i] != null)
                {
                    continue_h = false;
                }
            }

        }
    }



    public void OnRookClickedWhite(int x, int y)
    {
        // print("ok");
        bool continue_d = true;
        bool continue_g = true;
        bool continue_h = true;
        bool continue_b = true;
        //bloobPossiblity2.Contains(Grille[i,j])
        for (int i = 1; i < nb_cases; i++)
        {
            if (x + i < nb_cases)
            {
                if (WhitePieceList.Contains(Grille[x + i, y]))
                {
                    continue_d = false;
                    //print("1");
                }
            }

            if (y + i < nb_cases)
            {
                //print(Grille[x, y + i]);
                if (WhitePieceList.Contains(Grille[x, y + i]))
                {
                    continue_h = false;
                    //print("2");
                }
            }

            if (y - i >= 0)
            {
                if (WhitePieceList.Contains(Grille[x, y - i]))
                {
                    continue_b = false;
                    //print("3");
                }
            }

            if (x - i >= 0)
            {
                if (WhitePieceList.Contains(Grille[x - i, y]))
                {
                    continue_g = false;
                    //print("4");
                }
            }






            if (x + i < nb_cases && continue_d)
            {
                Grille_possibilitées[x + i, y] = Instantiate(cylindre_position_possible, GrillToMap(x + i, y), Quaternion.identity, Parent);
                //Debug.Log("1 "+x + i + " " + (y + i));          
            }

            if (x - i >= 0 && continue_g)
            {
                Grille_possibilitées[x - i, y] = Instantiate(cylindre_position_possible, GrillToMap(x - i, y), Quaternion.identity, Parent);
                //Debug.Log("2 " + (x - i) + " " + (y - i));
            }

            if (y - i >= 0 && continue_b)
            {
                Grille_possibilitées[x, y - i] = Instantiate(cylindre_position_possible, GrillToMap(x, y - i), Quaternion.identity, Parent);
                //Debug.Log("3 " + x + i + " " + (y - i));
            }

            if (y + i < nb_cases && continue_h)
            {
                Grille_possibilitées[x, y + i] = Instantiate(cylindre_position_possible, GrillToMap(x, y + i), Quaternion.identity, Parent);
                //Debug.Log("4 " + (x - i) + " " + (y + i));
            }





            if (x + i < nb_cases)
            {
                if (Grille[x + i, y] != null)
                {
                    continue_d = false;
                }
            }

            if (x - i >= 0)
            {
                if (Grille[x - i, y] != null)
                {
                    continue_g = false;
                }
            }

            if (y - i >= 0)
            {
                if (Grille[x, y - i] != null)
                {
                    continue_b = false;
                }
            }

            if (y + i < nb_cases)
            {
                if (Grille[x, y + i] != null)
                {
                    continue_h = false;
                }
            }

        }
    }



    public void OnQueenClickedBlack(int x, int y)
    {
        OnRookClickedBlack(x, y);
        OnBishopClickedBlack(x, y);
    }


    public void OnQueenClickedWhite(int x, int y)
    {
        OnRookClickedWhite(x, y);
        OnBishopClickedWhite(x, y);
    }

    public void OnKingClickedBlack(int x, int y)
    {
        if (x-1 >=0 && y-1 >=0 && !BlackPieceList.Contains(Grille[x - 1, y - 1]) && Grille[x-1,y-1]!= w_king)// attention king est le mauvais king
        {
            Grille_possibilitées[x-1,y-1]= Instantiate(cylindre_position_possible, GrillToMap(x - 1, y -1), Quaternion.identity, Parent);
        }

        if (x + 1 < nb_cases && y - 1 >= 0 && !BlackPieceList.Contains(Grille[x + 1, y - 1]) && Grille[x + 1, y - 1] != w_king)// attention king est le mauvais king
        {
            Grille_possibilitées[x + 1, y - 1] = Instantiate(cylindre_position_possible, GrillToMap(x + 1, y - 1), Quaternion.identity, Parent);
        }

        if (x - 1 >= 0 && y + 1 <nb_cases && !BlackPieceList.Contains(Grille[x - 1, y + 1]) && Grille[x - 1, y + 1] != w_king)// attention king est le mauvais king
        {
            Grille_possibilitées[x - 1, y +1] = Instantiate(cylindre_position_possible, GrillToMap(x- 1, y + 1), Quaternion.identity, Parent);
        }

        if (x + 1 <nb_cases  && y + 1 < nb_cases && !BlackPieceList.Contains(Grille[x+ 1, y + 1]) && Grille[x + 1, y + 1] != w_king)// attention king est le mauvais king
        {
            Grille_possibilitées[x + 1, y + 1] = Instantiate(cylindre_position_possible, GrillToMap(x + 1, y + 1), Quaternion.identity, Parent);
        }

        if (x - 1 >= 0 && !BlackPieceList.Contains(Grille[x - 1, y]) && Grille[x - 1, y] != w_king)// attention king est le mauvais king
        {
            Grille_possibilitées[x - 1, y] = Instantiate(cylindre_position_possible, GrillToMap(x - 1, y), Quaternion.identity, Parent);
        }

        if (x + 1 <nb_cases && !BlackPieceList.Contains(Grille[x + 1, y]) && Grille[x + 1, y] != w_king)// attention king est le mauvais king
        {
            Grille_possibilitées[x+ 1, y] = Instantiate(cylindre_position_possible, GrillToMap(x + 1, y), Quaternion.identity, Parent);
        }

        if (y + 1 <nb_cases && !BlackPieceList.Contains(Grille[x, y + 1]) && Grille[x, y + 1] != w_king)// attention king est le mauvais king
        {
            Grille_possibilitées[x, y + 1] = Instantiate(cylindre_position_possible, GrillToMap(x, y + 1), Quaternion.identity, Parent);
        }
        if (y - 1 >= 0 && !BlackPieceList.Contains(Grille[x, y - 1]) && Grille[x, y - 1] != w_king)// attention king est le mauvais king
        {
            Grille_possibilitées[x, y - 1] = Instantiate(cylindre_position_possible, GrillToMap(x, y - 1), Quaternion.identity, Parent);
        }

    }


    public void OnKingClickedWhite(int x, int y)
    {
        if (x - 1 >= 0 && y - 1 >= 0 && !WhitePieceList.Contains(Grille[x - 1, y - 1]) && Grille[x - 1, y - 1] != b_king)// attention king est le mauvais king
        {
            Grille_possibilitées[x - 1, y - 1] = Instantiate(cylindre_position_possible, GrillToMap(x - 1, y - 1), Quaternion.identity, Parent);
        }

        if (x + 1 < nb_cases && y - 1 >= 0 && !WhitePieceList.Contains(Grille[x + 1, y - 1]) && Grille[x + 1, y - 1] != b_king)// attention king est le mauvais king
        {
            Grille_possibilitées[x + 1, y - 1] = Instantiate(cylindre_position_possible, GrillToMap(x + 1, y - 1), Quaternion.identity, Parent);
        }

        if (x - 1 >= 0 && y + 1 < nb_cases && !WhitePieceList.Contains(Grille[x - 1, y + 1]) && Grille[x - 1, y + 1] != b_king)// attention king est le mauvais king
        {
            Grille_possibilitées[x - 1, y + 1] = Instantiate(cylindre_position_possible, GrillToMap(x - 1, y + 1), Quaternion.identity, Parent);
        }

        if (x + 1 < nb_cases && y + 1 < nb_cases && !WhitePieceList.Contains(Grille[x + 1, y + 1]) && Grille[x + 1, y + 1] != b_king)// attention king est le mauvais king
        {
            Grille_possibilitées[x + 1, y + 1] = Instantiate(cylindre_position_possible, GrillToMap(x + 1, y + 1), Quaternion.identity, Parent);
        }

        if (x - 1 >= 0 && !WhitePieceList.Contains(Grille[x - 1, y]) && Grille[x - 1, y] != b_king)// attention king est le mauvais king
        {
            Grille_possibilitées[x - 1, y] = Instantiate(cylindre_position_possible, GrillToMap(x - 1, y), Quaternion.identity, Parent);
        }

        if (x + 1 < nb_cases && !WhitePieceList.Contains(Grille[x + 1, y]) && Grille[x + 1, y] != b_king)// attention king est le mauvais king
        {
            Grille_possibilitées[x + 1, y] = Instantiate(cylindre_position_possible, GrillToMap(x + 1, y), Quaternion.identity, Parent);
        }

        if (y + 1 <nb_cases && !WhitePieceList.Contains(Grille[x, y + 1]) && Grille[x, y + 1] != b_king)// attention king est le mauvais king
        {
            Grille_possibilitées[x, y + 1] = Instantiate(cylindre_position_possible, GrillToMap(x, y + 1), Quaternion.identity, Parent);
        }
        if (y - 1 >= 0 && !WhitePieceList.Contains(Grille[x, y - 1]) && Grille[x, y - 1] != b_king)// attention king est le mauvais king
        {
            Grille_possibilitées[x, y - 1] = Instantiate(cylindre_position_possible, GrillToMap(x, y - 1), Quaternion.identity, Parent);
        }

    }

    public void OnBishopClickedBlack(int x ,int y)
    {
       // print("ok");

        bool continue_d_h = true;
        bool continue_g_b = true;
        bool continue_d_b = true;
        bool continue_g_h = true;

        //bloobPossiblity2.Contains(Grille[i,j])
        


        for (int i = 1; i < nb_cases; i++)
        {
            if (x + i < nb_cases && y + i < nb_cases)
            {
                if (BlackPieceList.Contains(Grille[x + i, y + i]))
                {
                    continue_d_h = false;
                    //print("1");
                }
            }

            if (x - i < nb_cases && y - i < nb_cases && x - i >= 0 && y - i >= 0)
            {
                //print(Grille[x - i, y - i]);
                if (BlackPieceList.Contains(Grille[x - i, y - i]))
                {
                    continue_g_b = false;
                    //print("2");
                }
            }
            
            if ((x + i < nb_cases && y - i < nb_cases && y - i >= 0))
            {
                if (BlackPieceList.Contains(Grille[x + i, y - i]))
                {
                    continue_d_b = false;
                    //print("3");
                }
            }
            
            if (x - i < nb_cases && y + i < nb_cases && x - i >= 0)
            {
                if (BlackPieceList.Contains(Grille[x - i, y + i]))
                {
                    continue_g_h = false;
                    //print("4");
                }
            }
            





            if (x + i < nb_cases && y + i < nb_cases && continue_d_h)
            {
                Grille_possibilitées[x + i, y + i] = Instantiate(cylindre_position_possible, GrillToMap(x + i, y + i), Quaternion.identity, Parent);
                //Debug.Log("1 "+x + i + " " + (y + i));          
            }

            if (x - i < nb_cases && y - i < nb_cases && x - i>=0 &&  y - i >=0 && continue_g_b)
            {
                Grille_possibilitées[x - i, y - i] = Instantiate(cylindre_position_possible, GrillToMap(x- i, y - i), Quaternion.identity, Parent);
                //Debug.Log("2 " + (x - i) + " " + (y - i));
            }
            
            if (x + i < nb_cases && y-i>=0 && continue_d_b)
            {
                Grille_possibilitées[x + i, y - i] = Instantiate(cylindre_position_possible, GrillToMap(x + i, y - i), Quaternion.identity, Parent);
                //Debug.Log("3 " + x + i + " " + (y - i));
            }

            if (x - i < nb_cases && y + i < nb_cases && x-i>=0 && continue_g_h)
            {
                Grille_possibilitées[x - i, y + i] = Instantiate(cylindre_position_possible, GrillToMap(x - i, y + i), Quaternion.identity, Parent);
                //Debug.Log("4 " + (x - i) + " " + (y + i));
            }

            



            if (x + i < nb_cases && y + i < nb_cases)
            {
                if (Grille[x + i, y + i] != null)
                {
                    continue_d_h = false;
                }
            }

            if (x - i < nb_cases && y - i < nb_cases && x - i >= 0 && y - i >= 0)
            {
                if (Grille[x - i, y - i] != null)
                {
                    continue_g_b = false;
                }
            }
            
            if (x + i < nb_cases && y - i < nb_cases && y -i >= 0)
            {
                if (Grille[x + i, y - i] != null)
                {
                    continue_d_b = false;
                }
            }
            
            if (x - i < nb_cases && y + i < nb_cases && x - i >= 0)
            {
                if (Grille[x - i, y + i] != null)
                {
                    continue_g_h = false;
                }
            }
            
        }
    }

    public void OnBishopClickedWhite(int x, int y)
    {
        // print("ok");

        bool continue_d_h = true;
        bool continue_g_b = true;
        bool continue_d_b = true;
        bool continue_g_h = true;

        //bloobPossiblity2.Contains(Grille[i,j])



        for (int i = 1; i < nb_cases; i++)
        {
            if (x + i < nb_cases && y + i < nb_cases)
            {
                if (WhitePieceList.Contains(Grille[x + i, y + i]))
                {
                    continue_d_h = false;
                    //print("1");
                }
            }

            if (x - i < nb_cases && y - i < nb_cases && x - i >= 0 && y - i >= 0)
            {
                //print(Grille[x - i, y - i]);
                if (WhitePieceList.Contains(Grille[x - i, y - i]))
                {
                    continue_g_b = false;
                    //print("2");
                }
            }

            if ((x + i < nb_cases && y - i < nb_cases && y - i >= 0))
            {
                if (WhitePieceList.Contains(Grille[x + i, y - i]))
                {
                    continue_d_b = false;
                    //print("3");
                }
            }

            if (x - i < nb_cases && y + i < nb_cases && x - i >= 0)
            {
                if (WhitePieceList.Contains(Grille[x - i, y + i]))
                {
                    continue_g_h = false;
                    //print("4");
                }
            }






            if (x + i < nb_cases && y + i < nb_cases && continue_d_h)
            {
                Grille_possibilitées[x + i, y + i] = Instantiate(cylindre_position_possible, GrillToMap(x + i, y + i), Quaternion.identity, Parent);
                //Debug.Log("1 "+x + i + " " + (y + i));          
            }

            if (x - i < nb_cases && y - i < nb_cases && x - i >= 0 && y - i >= 0 && continue_g_b)
            {
                Grille_possibilitées[x - i, y - i] = Instantiate(cylindre_position_possible, GrillToMap(x - i, y - i), Quaternion.identity, Parent);
                //Debug.Log("2 " + (x - i) + " " + (y - i));
            }

            if (x + i < nb_cases && y - i >= 0 && continue_d_b)
            {
                Grille_possibilitées[x + i, y - i] = Instantiate(cylindre_position_possible, GrillToMap(x + i, y - i), Quaternion.identity, Parent);
                //Debug.Log("3 " + x + i + " " + (y - i));
            }

            if (x - i < nb_cases && y + i < nb_cases && x - i >= 0 && continue_g_h)
            {
                Grille_possibilitées[x - i, y + i] = Instantiate(cylindre_position_possible, GrillToMap(x - i, y + i), Quaternion.identity, Parent);
                //Debug.Log("4 " + (x - i) + " " + (y + i));
            }





            if (x + i < nb_cases && y + i < nb_cases)
            {
                if (Grille[x + i, y + i] != null)
                {
                    continue_d_h = false;
                }
            }

            if (x - i < nb_cases && y - i < nb_cases && x - i >= 0 && y - i >= 0)
            {
                if (Grille[x - i, y - i] != null)
                {
                    continue_g_b = false;
                }
            }

            if (x + i < nb_cases && y - i < nb_cases && y - i >= 0)
            {
                if (Grille[x + i, y - i] != null)
                {
                    continue_d_b = false;
                }
            }

            if (x - i < nb_cases && y + i < nb_cases && x - i >= 0)
            {
                if (Grille[x - i, y + i] != null)
                {
                    continue_g_h = false;
                }
            }

        }
    }

    public void OnKnightClickedBlack(int x, int y)
    {   
        if (x-1>=0 && y-2>=0 && !BlackPieceList.Contains(Grille[x - 1, y - 2]))
        {
            Grille_possibilitées[x - 1, y - 2] = Instantiate(cylindre_position_possible, GrillToMap(x - 1, y - 2), Quaternion.identity, Parent);
        }
        if (x - 2 >= 0 && y - 1 >= 0  && !BlackPieceList.Contains(Grille[x - 2, y - 1]))
        {
            Grille_possibilitées[x - 2, y - 1] = Instantiate(cylindre_position_possible, GrillToMap(x - 2, y - 1), Quaternion.identity, Parent);
        }
        if (x - 2 >= 0 && y +1 < nb_cases && !BlackPieceList.Contains(Grille[x - 2, y + 1]))
        {
            Grille_possibilitées[x - 2, y +1] = Instantiate(cylindre_position_possible, GrillToMap(x - 2, y +1), Quaternion.identity, Parent);
        }

        if (x - 1 >= 0 && y + 2 < nb_cases &&   !BlackPieceList.Contains(Grille[x - 1, y + 2]))
        {
            Grille_possibilitées[x - 1, y + 2] = Instantiate(cylindre_position_possible, GrillToMap(x - 1, y + 2), Quaternion.identity, Parent);
        }

        if (x + 1 < nb_cases && y + 2 < nb_cases && !BlackPieceList.Contains(Grille[x + 1, y +2 ]))
        {
            Grille_possibilitées[x + 1, y + 2] = Instantiate(cylindre_position_possible, GrillToMap(x + 1, y + 2), Quaternion.identity, Parent);
        }

        if (x + 2 < nb_cases && y + 1 < nb_cases && !BlackPieceList.Contains(Grille[x +2, y + 1]))
        {
            Grille_possibilitées[x + 2, y +1] = Instantiate(cylindre_position_possible, GrillToMap(x + 2, y + 1), Quaternion.identity, Parent);
        }

        if (x + 2 < nb_cases && y -1 >= 0 && !BlackPieceList.Contains(Grille[x +2, y - 1]))
        {
            Grille_possibilitées[x + 2, y -1] = Instantiate(cylindre_position_possible, GrillToMap(x + 2, y -1), Quaternion.identity, Parent);
        }

        if (x + 1 <nb_cases && y - 2 >= 0 && !BlackPieceList.Contains(Grille[x+1, y-2]))
        {
            Grille_possibilitées[x + 1, y - 2] = Instantiate(cylindre_position_possible, GrillToMap(x + 1, y - 2), Quaternion.identity, Parent);
        }


    }

    public void OnKnightClickedWhite(int x, int y)
    {
        if (x - 1 >= 0 && y - 2 >= 0 && !WhitePieceList.Contains(Grille[x - 1, y - 2]))
        {
            Grille_possibilitées[x - 1, y - 2] = Instantiate(cylindre_position_possible, GrillToMap(x - 1, y - 2), Quaternion.identity, Parent);
        }
        if (x - 2 >= 0 && y - 1 >= 0 && !WhitePieceList.Contains(Grille[x - 2, y - 1]))
        {
            Grille_possibilitées[x - 2, y - 1] = Instantiate(cylindre_position_possible, GrillToMap(x - 2, y - 1), Quaternion.identity, Parent);
        }
        if (x - 2 >= 0 && y + 1 < nb_cases && !WhitePieceList.Contains(Grille[x - 2, y + 1]))
        {
            Grille_possibilitées[x - 2, y + 1] = Instantiate(cylindre_position_possible, GrillToMap(x - 2, y + 1), Quaternion.identity, Parent);
        }

        if (x - 1 >= 0 && y + 2 < nb_cases && !WhitePieceList.Contains(Grille[x - 1, y + 2]))
        {
            Grille_possibilitées[x - 1, y + 2] = Instantiate(cylindre_position_possible, GrillToMap(x - 1, y + 2), Quaternion.identity, Parent);
        }

        if (x + 1 < nb_cases && y + 2 < nb_cases && !WhitePieceList.Contains(Grille[x + 1, y + 2]))
        {
            Grille_possibilitées[x + 1, y + 2] = Instantiate(cylindre_position_possible, GrillToMap(x + 1, y + 2), Quaternion.identity, Parent);
        }

        if (x + 2 < nb_cases && y + 1 < nb_cases && !WhitePieceList.Contains(Grille[x + 2, y + 1]))
        {
            Grille_possibilitées[x + 2, y + 1] = Instantiate(cylindre_position_possible, GrillToMap(x + 2, y + 1), Quaternion.identity, Parent);
        }

        if (x + 2 < nb_cases && y - 1 >= 0 && !WhitePieceList.Contains(Grille[x + 2, y - 1]))
        {
            Grille_possibilitées[x + 2, y - 1] = Instantiate(cylindre_position_possible, GrillToMap(x + 2, y - 1), Quaternion.identity, Parent);
        }

        if (x + 1 < nb_cases && y - 2 >= 0 && !WhitePieceList.Contains(Grille[x + 1, y - 2]))
        {
            Grille_possibilitées[x + 1, y - 2] = Instantiate(cylindre_position_possible, GrillToMap(x + 1, y - 2), Quaternion.identity, Parent);
        }


    }



    public Vector3 GrillToMap(int i, int j)
    {
        float posx = gauche_bas.position.x;
        for (int ii = 0; ii < j; ii++)
        {
            posx += ecart_horizontal.position.x;
        }

        float posy = gauche_bas.position.z;
        for (int ii = 0; ii < i; ii++)
        {
            posy -= ecart_vertical.position.z;
        }
        return new Vector3(posy, 0.2f, posx);
    }


    public void MovePiece(int piecex, int piecey)
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f) && hit.transform.gameObject.name == "position_possible(Clone)")
            {
                Debug.Log("christ "+hit.transform.gameObject.name);
                for (int x = 0; x < nb_cases; x++)
                {
                    for (int y = 0; y < nb_cases; y++)
                    {
                        if (hit.transform.gameObject == Grille_possibilitées[x, y])
                        {
                            if (Grille[x, y]!= null)
                                Destroy( Grille[x, y]);// Grille[x, y].transform.position= new Vector3(0,0,0);
                            Vector3 tempo = GrillToMap(x, y);
                            Grille[piecex, piecey].transform.position = tempo;
                            GameObject tempo2 = Grille[piecex, piecey];
                            Grille[x, y] =tempo2;
                            //Destroy(Grille[piecex, piecey]);
                            Grille[piecex, piecey] = null;
                            Destroycloneposition();
                        }
                    }
                }
                //return hit.transform.gameObject;
            }
        }
    }

    public bool ClickedOnClonePosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f) && hit.transform.gameObject.name == "position_possible(Clone)")
            {
                return true;
            }
        }
        return false;
    }

    public void Print(GameObject[,] list)
    {
        for (int i = nb_cases-1; i >=0; i--)
        {
            Debug.Log(list[0, i].name + " " + list[1, i].name + " " + list[2, i].name + " " + list[3, i].name + " " + list[4, i].name + " " + list[5, i].name + " " + list[6, i].name + " " + list[7, i].name);
        }
        Debug.Log("_________________________________________________");
    }

    public void Destroycloneposition()
    {
        for (int x = 0; x < nb_cases; x++)
        {
            for (int y = 0; y < nb_cases; y++)
            {
                if (Grille_possibilitées[x, y]!=null)
                {
                    Grille_possibilitées[x, y].transform.position = new Vector3(10, 10, 10);
                    Destroy(Grille_possibilitées[x, y]);
                    Grille_possibilitées[x, y] = null;

                }
               
            }
        }
    } //cylindre 


    



    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {

            if (ClickedOnClonePosition())
            {
                MovePiece((int)arraypositionclicked[0], (int)arraypositionclicked[1]);

            }

            if (OnPieceClicked() != null)
            {
                Destroycloneposition();
                arraypositionclicked = OnPieceClicked();
                WhoIsClickedBlack((int)arraypositionclicked[0], (int)arraypositionclicked[1]);
                WhoIsClickedWhite((int)arraypositionclicked[0], (int)arraypositionclicked[1]);
            }


        }

    }
}
