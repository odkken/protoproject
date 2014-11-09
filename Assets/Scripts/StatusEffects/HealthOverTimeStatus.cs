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
                Player.Life.ModifyHealthByPercentOfCurrentHealth(PercentCurrentHps * UpdateInterval);
                Player.Life.ModifyHealthByPercentOfMaxHealth(PercentMaxHps * UpdateInterval);
                Player.Life.ModifyHealthByScalar(ScalarHps * UpdateInterval);
                yield return new WaitForSeconds(UpdateInterval);
            }
        }
    }
}
