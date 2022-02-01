using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Molotkoff.Test1App
{
    [RequireComponent(typeof(RectTransform))]
    public class FilterImagesWindow : MonoBehaviour, IWindow
    {
        [SerializeField]
        private ImageViewerWindow viewerWindow;
        [SerializeField]
        private ImageContentView contentPrefab;
        [SerializeField]
        private Image observableImage;
        [SerializeField]
        private int contentSnapshotLength;
        [SerializeField, Range(0, 1f)]
        private float contentAddRect;
        [SerializeField]
        private string contentURL;

        [SerializeField]
        private ScrollRect scrollRect;

        private ContentURLFactory urlFactory;

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            Screen.orientation = ScreenOrientation.Portrait;

            Screen.autorotateToPortrait = true;
            Screen.autorotateToLandscapeLeft = false;
            Screen.autorotateToLandscapeRight = false;
            Screen.autorotateToPortraitUpsideDown = false;

            gameObject.SetActive(true);
        }

        private void Awake()
        {
            urlFactory = new ContentURLFactory(contentURL);
        }

        private void Start()
        {
            var lastContent = AddContents();
        }

        private void LateUpdate()
        {
            if (scrollRect.verticalNormalizedPosition <= contentAddRect)
            {
                var lastContent = AddContents();
            }

#if UNITY_ANDROID
            if (Input.GetKeyDown(KeyCode.Menu) || Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
            
            if (!Input.GetKeyDown(KeyCode.Menu) && !Input.GetKeyDown(KeyCode.Escape) && !Input.backButtonLeavesApp)
            {
                Input.backButtonLeavesApp = true;
            }
#endif
        }

        private ImageContentView AddContent(string contentUrl)
        {
            var content = ImageContentView.Create(contentPrefab, contentUrl);
            content.transform.SetParent(scrollRect.content);

            content.OnClick += (evt, content) => 
            {
                observableImage.sprite = content.Image.sprite;
                Hide();
                viewerWindow.Show();
            };

            return content;
        }

        private ImageContentView AddContents()
        {
            ImageContentView lastContent = null;

            for (int i = 0; i < contentSnapshotLength; i++)
            {
                var contentURL = urlFactory.Create();

                if (contentURL == string.Empty)
                    break;

                lastContent = AddContent(contentURL);
            }

            return lastContent;
        }
    }
}