using UnityEngine;

namespace Assets.Scripts.CameraScripts
{
    public class CameraFollow : MonoBehaviour
    {
        public Vector3 Offset;
        public float SmoothSpeed = 1;

        private Transform _target;

        public void SetTarget(Transform target)
        {
            _target = target;
            if (target != null)
            {
                transform.position = target.position + Offset;
            }
            LookAtTarget();
        }

        private void FixedUpdate()
        {
            if(_target != null)
            {
                transform.position = Vector3.Lerp(transform.position, _target.position + Offset, SmoothSpeed);
                LookAtTarget();
            }
        }

        private void LookAtTarget()
        {
            if (_target != null)
                transform.LookAt(_target);
        }
    }
}