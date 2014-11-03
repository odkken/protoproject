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
                Player.life.ModifyHealthByPercentOfCurrentHealth(PercentCurrentHps * UpdateInterval);
                Player.life.ModifyHealthByPercentOfMaxHealth(PercentMaxHps * UpdateInterval);
                Player.life.ModifyHealthByScalar(ScalarHps * UpdateInterval);
                yield return new WaitForSeconds(UpdateInterval);
            }
        }
    }
}
