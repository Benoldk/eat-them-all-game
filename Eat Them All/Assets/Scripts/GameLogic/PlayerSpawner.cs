using UnityEngine;
using System.Linq;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject Player;

    private void Awake()
    {
        Vector3 spawnPosition = GetSpawnPosition();
        Ray positionRay = new Ray(spawnPosition, Vector3.down);
        if(Physics.Raycast(positionRay, out RaycastHit hit, 10000f))
        {
            spawnPosition.y = hit.point.y;
            SpawnPlayer(spawnPosition);
        }
    }

    Vector3 GetSpawnPosition()
    {
        var spawnTransforms = GetComponentsInChildren<Transform>().Where(c => c.transform != transform).ToArray();
        int spawnLocationIndex = Random.Range(0, spawnTransforms.Length);
        return spawnTransforms[spawnLocationIndex].position;
    }

    void SpawnPlayer(Vector3 position)
    {
        float yOffset = Player.gameObject.GetComponent<BoxCollider>().size.y;
        Vector3 pos = position;
        pos.y += yOffset;
        Instantiate(Player, pos, Quaternion.identity);
    }
}