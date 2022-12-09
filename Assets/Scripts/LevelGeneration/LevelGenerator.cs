using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D pic;
    public ColorMapping[] mappings;
    public float offset = 5;

    public void ClearLevel()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        for(int i = children.Length-1; i > 0; i--)
        {
            DestroyImmediate(children[i].gameObject);
        }
    }

    public void GenerateLevel()
    {
        for(int x=0; x < pic.width; x++)
        {
            for(int y=0; y < pic.height; y++)
            {
                SpawnElement(x, y);
            }
        }
    }

    void SpawnElement(int x, int z)
    {
        Color pixelColor = pic.GetPixel(x, z);
        Vector3 position = new Vector3(x, 0, z) * offset;

        foreach( ColorMapping mapping in mappings )
        {
            if( mapping.color == pixelColor )
            {
                Instantiate(mapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }
}
