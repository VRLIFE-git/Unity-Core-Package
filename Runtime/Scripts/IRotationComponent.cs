using UnityEngine;
using Vrlife.Core.Mvc;

namespace Vrlife.Core
{
    public interface IRotationComponent : IViewComponent
    {
        bool IsCorrectingRotation { get; }
        
        Transform Target { get; set; }
        
        float Speed { get; set; }
        
        float AngleDiff { get; }
        
        float AngleDeadZone { get; set; }
        
        float AngleDiffPerc { get; }
    }
}