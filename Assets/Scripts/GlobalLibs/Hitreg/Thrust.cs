using UnityEngine;
namespace Hydra
{
    namespace Hitreg
    {
        public class Thrust
        {
            private Transform playerTransform;
            private float endDistance;
            private float strikeDuration;
            private float lerpT;
            public Thrust(Transform player, float endDist, float strikeTime)
            {
                playerTransform = player;
                endDistance = endDist;
                strikeDuration = strikeTime;
                lerpT = 0f;
            }
            public RaycastHit[] Hit()
            {
                lerpT += Time.deltaTime;
                Ray ray = new Ray(playerTransform.position, playerTransform.forward);
                return Physics.SphereCastAll(ray, 0.1f, Mathf.Lerp(0f, endDistance, lerpT / strikeDuration));
            }
        }
    }
}
