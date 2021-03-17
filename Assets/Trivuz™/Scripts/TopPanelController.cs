using UnityEngine;
using UnityEngine.UI;
using Trivuz;
public class TopPanelController : SwipeDetector
{
    private Animator topPanelAnimator;
    [SerializeField] private Toggle topPanelToggle;

    protected override void Start()
    {
        base.Start();
        topPanelAnimator = GetComponent<Animator>();
    }
    protected override void Update()
    {
        swipe.SwipeDetect();
        if(swipe.IsSwiping(SwipeDirection.UpToDown)) {
            topPanelToggle.isOn = true;
        }
        else if(swipe.IsSwiping(SwipeDirection.DownToUp)) {
            topPanelToggle.isOn = false;
        }
    }
    public void ToggleTopPanel()
    {
        topPanelAnimator.SetBool("Activate", topPanelToggle.isOn);
    }
}
