using UnityEngine;

public class CrowdSpawners : MonoBehaviour
{
    public int CrowdSize = 20;
    public Transform RayTransform;
    public float RayLength = 1000f;
    public GameObject Spawn;

    private Collider SpawnColliderArea;
    private int curCrowdSize = 0;
    private float floorY;

    // Start is called before the first frame update
    void Start()
    {
        SpawnColliderArea = GetComponent<BoxCollider>();
        Ray ray = new Ray(RayTransform.position, Vector3.down);
        if(Physics.Raycast(ray, out RaycastHit hit, RayLength))
        {
            floorY = hit.point.y;
        }
    }

    void Update()
    {
        if (!IsVisibleFrom(Camera.main, SpawnColliderArea.bounds))
        {
            if (curCrowdSize == 0)
            {
                SpawnCrowd();
            }
        }
    }

    void SpawnCrowd()
    {
        for(int i = 0; i < CrowdSize; i++)
        {
            Vector3 position = new Vector3(Random.Range(SpawnColliderArea.bounds.min.x, SpawnColliderArea.bounds.max.x),
                                            floorY,
                                            Random.Range(SpawnColliderArea.bounds.min.z, SpawnColliderArea.bounds.max.z));

            Instantiate(Spawn, position, Quaternion.identity);
            Spawn.GetComponent<Entity>().ReduceCrowdSizeEvent = ReduceCrowdSize;
            ++curCrowdSize;
        }
    }

    void ReduceCrowdSize()
    {
        --curCrowdSize;
    }

    private bool IsVisibleFrom(Camera camera, Renderer renderer)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }

    private bool IsVisibleFrom(Camera camera, Bounds bounds)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, bounds);
    }
}