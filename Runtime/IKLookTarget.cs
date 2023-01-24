using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cgvg.EssentialsToolkit
{
    public class IKLookTarget : MonoBehaviour
    {
        private Transform currentTarget;

        //private bool isMoving = false;
        private float moveSpeed = 1.0f;

        public void MoveToTarget(Transform target, float moveSpeed)
        {
            this.moveSpeed = moveSpeed;
            currentTarget = target;
            //isMoving = true;
        }

        private void Move()
        {
            /*
        if (!isMoving)
        {
            return;
        }

        if (Vector3.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            isMoving = false;
            return;
        }
        */
            if (currentTarget != null)
            {
                transform.position =
                    Vector3.Lerp(transform.position, currentTarget.position, Time.deltaTime * moveSpeed);
            }

        }

        private void Update()
        {
            Move();
        }
    }
}
