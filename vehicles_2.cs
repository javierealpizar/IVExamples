using System;
using System.Threading;

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
    }
    
    public interface IDriver
    {
        void DriveFromHomeToStore();
        void DriveFromStoreToHome();
        void DriveFromHomeToWork();
        void DriveFromWorkToHome();
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
    
    public class Car : ICar, IDriver
    {
        public bool IsCarOn { get; private set; }
        
        public GearPosition GearPosition { get; private set; }
        
        public SteeringWheelPosition WheelPosition { get; private set; }
        
        public Pressure GasPedalPresure { get; private set; }
        
        public Pressure BreakPedalPresure { get; private set; }
        
        public void DriveFromHomeToStore()
        {
            StartCar();
            
            //back up
            SetGear(GearPosition.Reverse);
            PushGasPedal(Pressure.Light);
            TurnSteeringWheel(SteeringWheelPosition.FortyFiveDegreesRight);
            Thread.Sleep(5000);
            PushGasPedal(Pressure.None);
            PushBreakPedal(Pressure.Hard);
            
            //drive down road to store
            SetGear(GearPosition.Drive);
            TurnSteeringWheel(SteeringWheelPosition.Centered);
            PushBreakPedal(Pressure.None);
            PushGasPedal(Pressure.Medium);
            Thread.Sleep(30000);
            
            //turn left into parking lot
            PushGasPedal(Pressure.None);
            PushBreakPedal(Pressure.Light);
            TurnSteeringWheel(SteeringWheelPosition.FortyFiveDegreesLeft);
            Thread.Sleep(5000);
            TurnSteeringWheel(SteeringWheelPosition.Centered);
            
            //drive down parking lot
            PushBreakPedal(Pressure.None);
            PushGasPedal(Pressure.Light);
            Thread.Sleep(10000);
            
            //park
            PushGasPedal(Pressure.None);
            PushBreakPedal(Pressure.Light);
            TurnSteeringWheel(SteeringWheelPosition.FortyFiveDegreesLeft);
            Thread.Sleep(000);
            PushBreakPedal(Pressure.Hard);
            
            SetGear(GearPosition.Park);
            TurrnOffCar();
        }
        
        public void DriveFromHomeToWork()
        {
            throw new NotImplementedException();
        }
        
        public void DriveFromStoreToHome()
        {
            throw new NotImplementedException();
        }
        
        public void DriveFromWorkToHome()
        {
            throw new NotImplementedException();
        }
        
        public bool PushBreakPedal(Pressure pressure)
        {
            BreakPedalPresure = pressure;
            return true;
        }
        
        public bool PushGasPedal(Pressure pressure)
        {
            GasPedalPresure = pressure;
            return true;
        }
        
        public bool SetGear(GearPosition position)
        {
            GearPosition = position;
            return true;
        }
        
        public bool StartCar()
        {
            IsCarOn = true;
            return true;
        }
        
        public bool TurnSteeringWheel(SteeringWheelPosition position)
        {
            WheelPosition = position;
            return true;
        }
        
        public bool TurrnOffCar()
        {
            IsCarOn = false;
            return true;
        }
    }
}
