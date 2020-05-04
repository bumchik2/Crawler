using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Web;
using System.Globalization;
using System;
using System.Collections.Specialized;

public class WallGenerator : MonoBehaviour
{
    public GameObject wall_chunk;
    public int range_in_chunks;

    private float chunk_size = 50;

    private HashSet<KeyValuePair<int, int>> chunks = new HashSet<KeyValuePair<int, int>>();

    private void MakeNewChunk(KeyValuePair<int, int> position)
    {
        chunks.Add(position);

        int x = (int)(position.Key * chunk_size);   // x
        int y = (int)(position.Value * chunk_size); // y

        GameObject new_chunk = Instantiate(wall_chunk, new Vector2(x, y), Quaternion.identity);

        ChunkScript chunk_script = new_chunk.GetComponent<ChunkScript>();
        chunk_script.SetMaxDistance(range_in_chunks * chunk_size);
        chunk_script.SetPosition(position);
        chunk_script.SetPlayerTransform(transform);
    }

    public void EraseChunk(KeyValuePair<int, int> position)
    {
        chunks.Remove(position);
    }

    private void GenerateChunksIfNeeded()
    {
        int pos_x = (int)(transform.position.x / chunk_size);
        int pos_y = (int)(transform.position.y / chunk_size);

        for (int i = pos_x - range_in_chunks; i <= pos_x + range_in_chunks; ++i)
        {
            for (int j = pos_y - range_in_chunks; j <= pos_y + range_in_chunks; ++j)
            {
                KeyValuePair<int, int> position = new KeyValuePair<int, int>(i, j);
                if (!chunks.Contains(position))
                {
                    MakeNewChunk(position);
                }
            }
        }
    }

    private void Update()
    {
        GenerateChunksIfNeeded();
    }
}
