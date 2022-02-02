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
        [SerializeField]
        private Button playButton;

        public void Start()
        {
            var desc = playButton.transform.LeanScale(new Vector3(3f, 1.5f, 1), 2f);
            desc.loopType = LeanTweenType.pingPong;
        }

        public void Play()
        {
            SceneManager.LoadScene("App Image Window");
        }
    }
}