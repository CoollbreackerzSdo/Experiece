


class RemoteControlCar
{
    // TODO: define the constructor for the 'RemoteControlCar' class
    public RemoteControlCar(int sped,int batteryDrain)
    {
        Sped = sped;
        _BatteryDrain = batteryDrain;
    }
    public bool BatteryDrained()
        => !(_BatteryDrive >= _BatteryDrain);

    public int DistanceDriven()
        => _DistanceDrive;

    public static RemoteControlCar Nitro()
        => new(50, 4);
    public static RemoteControlCar Buy(int sped, int batteryDrain)
        => new(sped, batteryDrain);

    public string DistanceDisplay()
        => $"Driven {_DistanceDrive} meters";

    public string BatteryDisplay()
        => _BatteryDrive is 0 ? "Battery empty" : $"Battery at {_BatteryDrive}%";

    public void Drive()
    {
        if (_BatteryDrive < _BatteryDrain) return;
        _BatteryDrive -= _BatteryDrain;
        _DistanceDrive += Sped;
    }
    private int _BatteryDrive { get; set; } = 100;
    private int _DistanceDrive { get; set; } = 0;
    public readonly int Sped;
    private readonly int _BatteryDrain;
}
class RaceTrack
{

    // TODO: define the constructor for the 'RaceTrack' class
    public RaceTrack(int distance)
    {
        _Distance = distance;
    }
    public bool TryFinishTrack(RemoteControlCar car)
    {
        for (int i = 0; i < _Distance; i+=car.Sped)
        {
            if(car.BatteryDrained())
            {
                return false;
            }
            car.Drive();
        }

        return true;
    }
    private readonly int _Distance;
}