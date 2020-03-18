using UnityEngine;

namespace Vrlife.Core.Mvc
{
    public interface IKinematicAnimatorComponent : IViewComponent
    {
        Transform LookAtTarget { get; set; }

        Transform RightHandTarget { get; set; }
        
        Transform LeftHandTarget { get; set; }
        
        Transform RightFootTarget { get; set; }
        
        Transform LeftFootTarget { get; set; }

        float RightFootIkWeight { get; set; }
        
        float LeftFootIkWeight { get; set; }
        float RightHandIkWeight { get; set; }

        float LeftHandIkWeight { get; set; }

        float HeadLookAtWeight { get; set; }
    }
}