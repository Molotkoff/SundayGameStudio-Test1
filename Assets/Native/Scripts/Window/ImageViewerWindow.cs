using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Molotkoff.Test1App
{
    public class ImageViewerWindow : MonoBehaviour, IWindow
    {
        [SerializeField]
        private FilterImagesWindow filterWindow;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Menu))
            {
#if UNITY_ANDROID
                Input.backButtonLeavesApp = false;
#endif
                Hide();
                filterWindow.Show();
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);

            Screen.orientation = ScreenOrientation.AutoRotation;

            Screen.autorotateToPortrait = true;
            Screen.autorotateToLandscapeLeft = true;
            Screen.autorotateToLandscapeRight = true;
            Screen.autorotateToPortraitUpsideDown = true;
        }
    }
}
