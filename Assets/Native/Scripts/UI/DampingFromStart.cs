using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Molotkoff.Test1App
{
    public class DampingFromStart : MonoBehaviour
    {
        [Range(0.01f, 1f), SerializeField]
        private float dampingSpeed;
        [SerializeField]
        private Image damping;

        private WaitForFixedUpdate wait = new WaitForFixedUpdate();

        public void Start()
        {
            StartCoroutine(Damping());
        }

        private IEnumerator Damping()
        {
            for (var alpha = damping.color.a; alpha >= 0; alpha -= dampingSpeed)
            {
                var color = damping.color;
                color.a = alpha;

                damping.color = color;
                yield return wait;
            }

            var _color = damping.color;
            _color.a = 0;

            Destroy(damping.gameObject);
            yield break;
        }
    }
}