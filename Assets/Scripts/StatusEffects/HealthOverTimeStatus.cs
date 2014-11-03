using System.Collections;
using UnityEngine;

namespace Assets.Scripts.StatusEffects
{
    public class HealthOverTimeStatus : StatusEffect
    {

        public float PercentCurrentHps;
        public float PercentMaxHps;
        public float ScalarHps;

        public override IEnumerator UpdateStatus()
        {
            while (!Expired)
            {
                player.life.ModifyHealthByPercentOfCurrentHealth(PercentCurrentHps * UpdateInterval);
                player.life.ModifyHealthByPercentOfMaxHealth(PercentMaxHps * UpdateInterval);
                player.life.ModifyHealthByScalar(ScalarHps * UpdateInterval);
                yield return new WaitForSeconds(UpdateInterval);
            }
        }
    }
}
