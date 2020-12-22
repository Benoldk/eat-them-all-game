using Assets.Scripts.NPC;
using UnityEngine;

namespace Assets.Scripts.AI
{
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
            if (Physics.Raycast(ray, out RaycastHit hit, RayLength))
            {
                floorY = hit.point.y;
            }

            if (curCrowdSize == 0)
            {
                SpawnCrowd();
            }
        }

        void Update()
        {
            //if (!IsVisibleFrom(Camera.main, SpawnColliderArea.bounds))
            //{
                
            //}
        }

        void SpawnCrowd()
        {
            for (int i = 0; i < CrowdSize; i++)
            {
                Vector3 position = new Vector3(Random.Range(SpawnColliderArea.bounds.min.x, SpawnColliderArea.bounds.max.x),
                                                floorY,
                                                Random.Range(SpawnColliderArea.bounds.min.z, SpawnColliderArea.bounds.max.z));

                var clone = Instantiate(Spawn, position, Quaternion.identity);
                clone.GetComponent<NPCCharacter>().ReduceCrowdSizeEvent = ReduceCrowdSize;
                ++curCrowdSize;
            }
        }

        void ReduceCrowdSize()
        {
            --curCrowdSize;
        }

        //private bool IsVisibleFrom(Camera camera, Bounds bounds)
        //{
        //    Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        //    return GeometryUtility.TestPlanesAABB(planes, bounds);
        //}
    }
}