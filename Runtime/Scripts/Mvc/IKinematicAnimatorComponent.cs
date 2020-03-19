using UnityEngine;

namespace Vrlife.Core.Mvc
{
    public interface IKinematicAnimatorComponent : IViewComponent
    {
        Transform LookAtTarget { get; set; }
        float HeadLookAtWeight { get; set; }

        IkLimb RightHand { get; }

        IkLimb LeftHand { get; }

        IkLimb RightFoot { get; }

        IkLimb LeftFoot { get; }
    }
}