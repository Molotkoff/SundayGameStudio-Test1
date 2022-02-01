using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Molotkoff.Test1App
{
    public class ToMainApp : MonoBehaviour
    {
        [Range(0.1f, 1f)]
        private float alphaSpeed;
        [SerializeField]
        private Image dampingImage;
        [SerializeField]
        private Button playButton;

        private WaitForFixedUpdate waitCached = new WaitForFixedUpdate();

        public void Start()
        {
            var desc = playButton.transform.LeanScale(new Vector3(3f, 1.5f, 1), 2f);
            desc.loopType = LeanTweenType.pingPong;
        }

        public void Play()
        {
            StartCoroutine(Damping());
        }

        private IEnumerator Damping()
        {
            for (var alpha = dampingImage.color.a; alpha <= 1; alpha += alphaSpeed)
            {
                var color = dampingImage.color;
                color.a = alpha;

                dampingImage.color = color;
                yield return waitCached;
            }

            SceneManager.LoadScene("App Image Window");
            yield break;
        }
    }
}