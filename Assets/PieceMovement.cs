using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMovement : MonoBehaviour
{
    public GameObject[,] Grille;

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

    public Transform Parent;
    public Transform ecart_vertical;
    public Transform ecart_horizontal;
    public Transform gauche_bas;
    public Transform gauche_haut;
    public Transform droite_bas;
    public Transform droite_haut;

    public int nb_cases = 8;

    void Start()
    {
        Grille = new GameObject[nb_cases, nb_cases];

        Grille[1, 0] = Instantiate(b_knight, GrillToMap(1, 0), Quaternion.identity, Parent);
        Grille[6, 0] = Instantiate(b_knight, GrillToMap(6, 0), Quaternion.identity, Parent);

        Grille[0,0]= Instantiate(b_rook, GrillToMap(0, 0), Quaternion.identity, Parent);
        Grille[7,0] = Instantiate(b_rook, GrillToMap(7, 0), Quaternion.identity, Parent);

        Grille[2, 0] = Instantiate(b_bishop, GrillToMap(2, 0), Quaternion.identity, Parent);
        Grille[5, 0] = Instantiate(b_bishop, GrillToMap(5, 0), Quaternion.identity, Parent);

        Grille[4, 0] = Instantiate(b_king, GrillToMap(4, 0), Quaternion.identity, Parent);
        Grille[3, 0] = Instantiate(b_queen, GrillToMap(3, 0), Quaternion.identity, Parent);

        for (int i = 0; i < nb_cases; i++)
        {
            Grille[i,1]= Instantiate(b_pawn, GrillToMap(i, 1), Quaternion.identity, Parent);
        }


        Grille[1, 7] = Instantiate(w_knight, GrillToMap(1, 7), Quaternion.identity, Parent);
        Grille[6, 7] = Instantiate(w_knight, GrillToMap(6, 7), Quaternion.identity, Parent);

        Grille[0, 7] = Instantiate(w_rook, GrillToMap(0, 7), Quaternion.identity, Parent);
        Grille[7, 7] = Instantiate(w_rook, GrillToMap(7, 7), Quaternion.identity, Parent);

        Grille[2, 7] = Instantiate(w_bishop, GrillToMap(2, 7), Quaternion.identity, Parent);
        Grille[5, 7] = Instantiate(w_bishop, GrillToMap(5, 7), Quaternion.identity, Parent);

        Grille[3, 7] = Instantiate(w_king, GrillToMap(3, 7), Quaternion.identity, Parent);
        Grille[4, 7] = Instantiate(w_queen, GrillToMap(4, 7), Quaternion.identity, Parent);

        for (int i = 0; i < nb_cases; i++)
        {
            Grille[i, 6] = Instantiate(w_pawn, GrillToMap(i, 6), Quaternion.identity, Parent);
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





    void Update()
    {
        
    }
}
