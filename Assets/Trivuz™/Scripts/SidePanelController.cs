using UnityEngine;
using UnityEngine.UI;
using Trivuz;
public class SidePanelController : SwipeDetector
{
    private Animator sidePanelAnimator;
    [SerializeField] private Toggle sidePanelToggle;

    protected override void Start()
    {
        base.Start();
        sidePanelAnimator = GetComponent<Animator>();
    }
    protected override void Update()
    {
        swipe.SwipeDetect();
        if(swipe.IsSwiping(SwipeDirection.RightToLeft)) {
            sidePanelToggle.isOn = false;
        }
    }
    public void ToggleSidePanel()
    {
        sidePanelAnimator.SetBool("Activate", sidePanelToggle.isOn);
    }
}
