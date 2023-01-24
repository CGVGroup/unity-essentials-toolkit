using UnityEngine;

namespace cgvg.EssentialsToolkit
{
    public class SimpleIKWatch : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Transform lookAtTarget;
        [SerializeField] private Transform leftHandTarget, rightHandTarget, leftFootTarget, rightFootTarget;
        [SerializeField] private bool legsIKActive = false;
        [SerializeField] private bool rhIKactive = false;
        [SerializeField] private bool lhIKactive = false;
        [SerializeField] private bool headLookActive = false;
        [SerializeField] private float bodyWeight = 0.1f;
        [SerializeField] private float headWeight = 0.25f;
        [SerializeField] private float eyeWeight = 1.0f;

        public void SetLookAtTarget(Transform lookAtTransform)
        {
            lookAtTarget = lookAtTransform;
            if (lookAtTransform == null)
            {
                headLookActive = false;
            }
            else
            {
                headLookActive = true;
            }
        }

        public Transform LookAtTarget
        {
            get { return lookAtTarget; }
        }

        public void ToggleLimbsIK(bool toggle)
        {
            legsIKActive = toggle;
        }

        public void ToggleRHIK(bool toggle)
        {
            rhIKactive = toggle;
        }

        public void ToggleLHIK(bool toggle)
        {
            lhIKactive = toggle;
        }

        public void ToggleLook(bool toggle)
        {
            headLookActive = toggle;
        }

        public void EnableSimpleEyeFollow()
        {
            headWeight = 0f;
            eyeWeight = 0.6f;
        }

        public void EnableFullHeadFollow()
        {
            headWeight = 0.2f;
            eyeWeight = 1.0f;
        }

        public void SetRightHandIKTarget(GameObject target)
        {
            rightHandTarget = target.transform;
        }

        public void SetLeftHandIKTarget(GameObject target)
        {
            leftHandTarget = target.transform;
            if (target != null)
            {
                lhIKactive = true;
            }
            else
            {
                lhIKactive = false;
            }
        }

        public void MoveLookAtTargetToPosition(Transform target, float moveSpeed)
        {
            IKLookTarget ikLookTarget = lookAtTarget.gameObject.GetComponent<IKLookTarget>();
            if (ikLookTarget == null)
            {
                Debug.LogError("ERROR: Look target must have component of type IKLookTarget to use this method.");
                return;
            }

            ikLookTarget.MoveToTarget(target, moveSpeed);
        }

        public void SetBodyWeight(float weight)
        {
            bodyWeight = weight;
        }

        private void OnAnimatorIK(int layerIndex = 0)
        {
            if (lookAtTarget != null && headLookActive == true)
            {
                animator.SetLookAtPosition(lookAtTarget.position);
                animator.SetLookAtWeight(1.0f, bodyWeight, headWeight, eyeWeight, 0.75f);
            }

            if (rhIKactive == true && rightHandTarget != null)
            {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);
                animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandTarget.rotation);
                animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandTarget.position);
            }

            if (lhIKactive == true && leftHandTarget != null)
            {
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);
                animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandTarget.rotation);
                animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandTarget.position);
            }

            if (legsIKActive)
            {
                animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1.0f);
                animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1.0f);


                animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1.0f);
                animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1.0f);



                animator.SetIKPosition(AvatarIKGoal.LeftFoot, leftFootTarget.position);
                animator.SetIKPosition(AvatarIKGoal.RightFoot, rightFootTarget.position);



                animator.SetIKRotation(AvatarIKGoal.LeftFoot, leftFootTarget.rotation);
                animator.SetIKRotation(AvatarIKGoal.RightFoot, rightFootTarget.rotation);
            }

        }
    }
}
