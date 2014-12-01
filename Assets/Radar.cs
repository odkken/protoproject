using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{


    public class Blip
    {
        public GameObject Object;
        public Image Image;
    }

    public class Radar : MonoBehaviour
    {

        public Targetable player;

        public Image blipImage;

        private List<Blip> blips;

        // Use this for initialization
        void Start()
        {
            blips = new List<Blip>();
            foreach (var obj in FindObjectsOfType<Targetable>())
            {
                var blip = new Blip { Image = (Image)Instantiate(blipImage), Object = obj.gameObject };
                blip.Image.rectTransform.parent = transform;
                blip.Image.color = obj.GetComponent<Targetable>().TeamType == player.TeamType ? Color.green : Color.red;
                blips.Add(blip);
            }
        }

        // Update is called once per frame
        void Update()
        {
            foreach (var blip in blips)
            {
                blip.Image.rectTransform.localPosition = GetComponent<RectTransform>().rect.center + 30 * (Vector2)(blip.Object.transform.position - player.transform.position);
            }
        }
    }
}
