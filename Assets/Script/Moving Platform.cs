using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase[] tileset;

    [Header("Tile Range")]
    [SerializeField] private int startX;
    [SerializeField] private int endX;
    [SerializeField] private int fixedY;
    [SerializeField] private int fixedZ;
    private int length;

    private void Start()
    {
        length = Mathf.Abs(endX - startX) + 1;
        tileset = new TileBase[length];
        Debug.Log(length);
        RetrieveAllTile();
        DisableAllTile();
        StartCoroutine(PlatformCycle());
    }

    private void RetrieveAllTile()
    {
        for (int i=0; i < length; i++)
        {
            tileset[i] = tilemap.GetTile(new Vector3Int(startX + i, fixedY, fixedZ));
        }
    }

    private void DisableAllTile()
    {
        for (int i = 0; i < length; i++)
        {
            tilemap.SetTile(new Vector3Int(startX + i, fixedY, fixedZ), null);
        }
    }

    private IEnumerator PlatformCycle()
    {
        bool front = true;
        int i = 0;
        Vector3Int lastTilePos = new Vector3Int(endX, fixedY, fixedZ);
        Vector3Int firstTilePos = new Vector3Int(startX, fixedY, fixedZ);
        
        while (true)
        {
            Vector3Int currectTilePos = new Vector3Int(startX + i, fixedY, fixedZ);
            Debug.Log(i);

            if (front)
            {
                tilemap.SetTile(currectTilePos, tileset[i]);
                if (i == length-1)
                {
                    front = false;
                    yield return new WaitForSeconds(2f);
                }
                else i++;
            }
            else
            {
                tilemap.SetTile(currectTilePos, null);
                if (i == 0)
                {
                    front = true;
                    yield return new WaitForSeconds(2f);
                }
                else i--;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
