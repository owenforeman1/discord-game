using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveProjectile : MonoBehaviour
{
    List<Transform> pieces = new List<Transform>();
    public Transform piecesContainer;

    public GameObject piecePrefab;
    public float xPieceOffset = 2.25f;

    public int piecesAmount = 5;

    public float amp = 1;
    public float frequency = 1;
    public float offsetAmount = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPieces();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePos();
    }

    private void SpawnPieces()
    {
        int i = 0;
        while (i < piecesAmount)
        {
            Transform newPieceTransform = Instantiate(piecePrefab, piecesContainer).transform;
            newPieceTransform.localPosition = new Vector3(i * xPieceOffset, 0f, 0f);
            pieces.Add(newPieceTransform);
            i++;
        }
    }

    private void UpdatePos()
    {
        int i = 0;
        float radians = ((180 / MathF.PI) ) * Time.time;
        foreach (Transform child in pieces)
        {
            
            child.localPosition = new Vector3(child.localPosition.x, CalcYPos(radians, i), 0f);

            i++;
        }
    }

    public float CalcYPos(float radians, int i)
    {
        float offset = i * offsetAmount;
        return amp * Mathf.Sin((radians-offset) / frequency);
    }
}
