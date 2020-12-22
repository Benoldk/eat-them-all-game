using UnityEngine;

namespace Assets.Scripts.Camera
{
    class CameraFollow : MonoBehaviour
    {
        public Transform Target;
        public Vector3 Offset;
        public float SmoothSpeed = 1;

        private void Start()
        {
            transform.position = Target.position + Offset;
            LookAtTarget();
        }


        private void FixedUpdate()
        {
            if(Target != null)
            {
                transform.position = Vector3.Lerp(transform.position, Target.position + Offset, SmoothSpeed);
                LookAtTarget();
            }
        }

        private void LookAtTarget()
        {
            if (Target != null)
                transform.LookAt(Target);
        }
    }
}