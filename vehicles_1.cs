using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewProblems.Vehicles
{
    public interface ICar
    {
        bool IsCarOn { get; }
        GearPosition GearPosition { get; }
        SteeringWheelPosition WheelPosition { get; }
        Pressure GasPedalPresure { get; }
        Pressure BreakPedalPresure { get; }
        
        bool StartCar();
        bool TurrnOffCar();
        bool PushGasPedal(Pressure pressure);
        bool PushBreakPedal(Pressure pressure);
        bool TurnSteeringWheel(SteeringWheelPosition position);
        bool SetGear(GearPosition position);
        
        bool DriveFromHomeToStore();
        bool DriveFromStoreToHome();
        bool DriveFromHomeToWork();
        bool DriveFromWorkToHome();
    }

    public enum Pressure
    {
        None,
        Light,
        Medium,
        Hard
    }
    
    public enum SteeringWheelPosition
    {
        Centered,
        FortyFiveDegreesLeft,
        NinetyDegreesLeft,
        FortyFiveDegreesRight,
        NinetyDegreesRight
    }
    
    public enum GearPosition
    {
        Park,
        Neutral,
        Drive,
        Reverse
    }
}
