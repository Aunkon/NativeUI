namespace Trivuz
{
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.Video;
    using UnityEngine.SceneManagement;
    public enum SwipeDirection
    {
        None = 0,
        RightToLeft = 1,
        LeftToRight = 2,
        DownToUp = 4,
        UpToDown = 8,

        RightUpToLeftDown = 9,
        RightDownToLeftUp = 5,
        LeftUpToRightDown = 10,
        LeftDownToRightUP = 6,
    }
    public class SwipeDetector : Trivuz
    {
        public static SwipeDetector swipe;

        private SwipeDirection Direction {
            get; set;
        }
        private Vector3 touchPosition;
        private float swipeResistanceX = 50f, swipeResistanceY = 100f;

        protected override void Start()
        {
            base.Start();
            swipe = this;
        }

        internal void SwipeDetect()
        {
            Direction = SwipeDirection.None;
            if(Input.GetMouseButtonDown(0)) {
                touchPosition = Input.mousePosition;
            }
            if(Input.GetMouseButtonUp(0)) {
                Vector2 deltaSwipe = touchPosition - Input.mousePosition;
                if(Mathf.Abs(deltaSwipe.x) > swipeResistanceX) {
                    //Swipe on the X Axis
                    Direction |= (deltaSwipe.x < 0) ? SwipeDirection.LeftToRight : SwipeDirection.RightToLeft;
                }
                if(Mathf.Abs(deltaSwipe.y) > swipeResistanceY) {
                    //Swipe on the Y Axis
                    Direction |= (deltaSwipe.y < 0) ? SwipeDirection.DownToUp : SwipeDirection.UpToDown;
                }
            }
        }
        public bool IsSwiping(SwipeDirection direction)
        {
            if(direction == Direction) {
                return true;
            }
            else {
                return false;
            }
        }
    }
    public class Trivuz : MonoBehaviour
    {
        [SerializeField] private RawImage rawFrame;
        [SerializeField] private Texture trivuzTexture;
        private VideoPlayer video;

        protected virtual void Start()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
        protected virtual void Update()
        {
        }
        private void OnEnable()
        {
            video = GetComponent<VideoPlayer>();
            if(video != null) {
                video.loopPointReached += VideoEnd;
            }
        }
        private void VideoEnd(VideoPlayer videoPlayer)
        {
            rawFrame.texture = trivuzTexture;
            SceneManager.LoadScene(1);
        }
    }
}
