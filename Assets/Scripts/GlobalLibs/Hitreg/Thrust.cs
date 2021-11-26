using UnityEngine;
namespace Hydra
{
    namespace Hitreg
    {
        public class Thrust // Hitreg class used for stabs and thrusts that have fixed x/y positions
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
                Ray ray = new Ray(playerTransform.position, playerTransform.forward); // The collider will always start at the player and travel forward
                return Physics.SphereCastAll(ray, 0.1f, Mathf.Lerp(0f, endDistance, lerpT / strikeDuration));
            }
        }
    }
}
