using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkScript : MonoBehaviour
{
    private Transform player_transform = null;
    private KeyValuePair<int, int> position;

    private float max_distance;

    public void SetMaxDistance(float new_distance)
    {
        max_distance = new_distance;
    }

    public void SetPosition(KeyValuePair<int, int> new_position)
    {
        position = new_position;
    }

    public void SetPlayerTransform(Transform new_transform)
    {
        player_transform = new_transform;
    }

    private void AudoDestroyIfNeeded()
    {
        if ((transform.position - player_transform.position).magnitude > max_distance)
        {
            Destroy(gameObject);
            player_transform.gameObject.GetComponent<WallGenerator>().EraseChunk(position);
        }
    }

    void Update()
    {
        if (transform != null)
        {
            AudoDestroyIfNeeded();
        }
    }
}
