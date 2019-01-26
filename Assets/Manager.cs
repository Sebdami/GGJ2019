using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject PlaceVerticale1, PlaceHorizontale2, PlaceCarre3, PlaceCarre4, PlaceHorizontale5, PlaceVerticale6, PlaceVerticale7, PlaceVerticale8, PlaceCarre9, PieceVerticale1, PieceHorizontale2, PieceCarre3, PieceCarre4, PieceHorizontale5, PieceVerticale6, PieceVerticale7, PieceVerticale8, PieceCarre9;
    Vector3 PieceVerticale1InitialPos, PieceHorizontale2InitialPos, PieceCarre3InitialPos, PieceCarre4InitialPos, PieceHorizontale5InitialPos, PieceVerticale6InitialPos, PieceVerticale7InitialPos, PieceVerticale8InitialPos, PieceCarre9InitialPos;

    void Start()
    {
        PieceVerticale1InitialPos = PieceVerticale1.transform.position;
        PieceHorizontale2InitialPos = PieceHorizontale2.transform.position;
        PieceCarre3InitialPos = PieceCarre3.transform.position;
        PieceCarre4InitialPos = PieceCarre4.transform.position;
        PieceHorizontale5InitialPos = PieceHorizontale5.transform.position;
        PieceVerticale6InitialPos = PieceVerticale6.transform.position;
        PieceVerticale7InitialPos = PieceVerticale7.transform.position;
        PieceVerticale8InitialPos = PieceVerticale8.transform.position;
        PieceCarre9InitialPos = PieceCarre9.transform.position;
    }
    public void DragPieceVerticale1()
    {
        PieceVerticale1.transform.position = Input.mousePosition;
    }
    public void DragPieceHorizontale2()
    {
        PieceHorizontale2.transform.position = Input.mousePosition;
    }
    public void DropPieceVerticale1()
    {
        float Distance = Vector3.Distance(PieceVerticale1.transform.position, PlaceVerticale1.transform.position);
        if (Distance < 50)
        {
            PieceVerticale1.transform.position = PlaceVerticale1.transform.position;
        }
        else
        {
            PieceVerticale1.transform.position = PieceVerticale1InitialPos;
        }
    }
    public void DropPieceHorizontale2()
    {
        PieceHorizontale2.transform.position = Input.mousePosition;
    }
}
