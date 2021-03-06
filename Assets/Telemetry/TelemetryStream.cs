using System;
using System.Threading;
using System.Threading.Tasks;

namespace Telemetry
{
    /// <summary>
    /// Spacesuit Data
    /// </summary>
    public class TelemetryData
    {
    //    /// <summary>
    //    /// Duration of the current EVA. EVA Time is displayed in the format "hh:mm:ss"
    //    /// </summary>
    //    public readonly TimeSpan EVATime;

    //    /// <summary>
    //    /// Percentage left in the primary oxygen supply.
    //    /// </summary>
    //    public readonly double PrimaryOxygen;

    //    /// <summary>
    //    /// Percentage left in the secondary oxygen supply.
    //    /// </summary>
    //    public readonly double SecondaryOxygen;

    //    /// <summary>
    //    /// Heart rate of the astronaut measured in beats per minute. Expected range is from 80 to 100 bpm.
    //    /// </summary>
    //    public readonly int BPM;

    //    /// <summary>
    //    /// External Environment pressure. Expected range is from 2 to 4 psia.
    //    /// </summary>
    //    public readonly double SubPressure;

    //    /// <summary>
    //    /// The pressure inside the spacesuit needs to stay within certain limits. If the suit pressure
    //    /// gets too high, or if the pressure exceeds nominal limits, the movement of the astronaut
    //    /// will be heavily reduced.Expected range is from 2 to 4 psid.
    //    /// </summary>
    //    public readonly double SuitPressure;

    //    /// <summary>
    //    /// External Environmental temperature measured in degrees Fahrenheit. Temperatures
    //    /// are expected to be standard low earth orbit Day/Night-cycles without anomalies.
    //    /// </summary>
    //    public readonly double Temperature;

    //    /// <summary>
    //    /// Speed of the cooling fan. Expected range is from 10,000 to 40,000 RPM.
    //    /// </summary>
    //    public readonly int FanTachometer;

    //    /// <summary>
    //    /// Pressure inside the Primary Oxygen Pack. Expected range is from 750 to 950 psia.
    //    /// </summary>
    //    public readonly double OxygenPressure;

    //    /// <summary>
    //    /// Flowrate of the Primary Oxygen Pack. Expected range is from 0.5 to 1 psi/min.
    //    /// </summary>
    //    public readonly double OxygenRate;

    //    /// <summary>
    //    /// Total capacity of the spacesuit’s battery. Expected range is from 0 to 30 amp-hr.
    //    /// </summary>
    //    public readonly int BatteryCapacity;

    //    /// <summary>
    //    /// Gas pressure from H2O system. Expected range is from 14 to 16 psia.
    //    /// </summary>
    //    public readonly double H2OGasPressure;

    //    /// <summary>
    //    /// Liquid pressure from H2O system. Expected range is from 14 to 16 psia.
    //    /// </summary>
    //    public readonly double H20LiquidPressure;

    //    /// <summary>
    //    /// Pressure inside the Secondary Oxygen Pack. Expected range is from 750 to 950 psia.
    //    /// </summary>
    //    public readonly double SopPressure;

    //    /// <summary>
    //    /// Flowrate of the Secondary Oxygen Pack. Expected range is from 0.5 to 1 psi/min.
    //    /// </summary>
    //    public readonly double SopRate;

    //    /// <summary>
    //    /// The remaining time until the battery of the spacesuit is completely discharged. Battery
    //    /// life is usually displayed in the format "hh:mm:ss" Expected range is from 0 to 10 hours.
    //    /// </summary>
    //    public readonly TimeSpan TimeLeftBattery;

    //    /// <summary>
    //    /// The remaining time until the available oxygen is depleted. Time life oxygen is usually
    //    /// displayed in the format “hh:mm:ss” Expected range is from 0 to 10 hours.
    //    /// </summary>
    //    public readonly TimeSpan TimeLifeOxygen;

    //    /// <summary>
    //    /// The remaining time until the water resources of the spacesuit are depleted. Time life
    //    /// water is usually displayed in the format “hh:mm:ss” Expected range is from 0 to 10 hours.
    //    /// </summary>
    //    public readonly TimeSpan TimeLifeWater;

    //    internal TelemetryData(TelemetryAPI.TelemetryDataRaw data)
    //    {
    //        EVATime = TimeSpan.Parse(data.timer); // check format
    //        PrimaryOxygen = double.Parse(data.ox_primary);
    //        SecondaryOxygen = double.Parse(data.ox_secondary);
    //        BPM = data.heart_bpm;
    //        SubPressure = double.Parse(data.p_sub);
    //        SuitPressure = double.Parse(data.p_suit);
    //        Temperature = double.Parse(data.t_sub);
    //        FanTachometer = int.Parse(data.v_fan);
    //        OxygenPressure = double.Parse(data.p_o2);
    //        OxygenRate = double.Parse(data.rate_o2);
    //        BatteryCapacity = data.cap_battery;
    //        H2OGasPressure = double.Parse(data.p_h2o_g);
    //        H20LiquidPressure = double.Parse(data.p_h2o_l);
    //        SopPressure = double.Parse(data.p_sop);
    //        SopRate = double.Parse(data.rate_sop);
    //        TimeLeftBattery = TimeSpan.Parse(data.t_battery); // check formatting
    //        TimeLifeOxygen = TimeSpan.Parse(data.t_oxygen);
    //        TimeLifeWater = TimeSpan.Parse(data.t_water);
    //    }
    //}

    ///// <summary>
    ///// Class used to manage spacesuit telemetry data
    ///// </summary>
    //class TelemetryStream : IDisposable
    //{
    //    /// <summary>
    //    ///  singleton instance
    //    /// </summary>
    //    private static readonly Lazy<TelemetryStream> lazyStream = new Lazy<TelemetryStream>(() => new TelemetryStream());

    //    /// <summary>
    //    /// stream object from which data can be accessed
    //    /// </summary>
    //    public static TelemetryStream stream { get { return lazyStream.Value; } }

    //    //
    //    // implementation of class
    //    //

    //    /// <summary>
    //    /// Data structure storing suit telemetry. Updated every second.
    //    /// This structure can be null when not initialized or when request results in error.
    //    /// </summary>
    //    public TelemetryData Data { get; private set; }

    //    /// <summary>
    //    /// cancellation token used to dispose of polling loop
    //    /// </summary>
    //    private CancellationTokenSource cancellationToken;

    //    /// <summary>
    //    /// Default constructor. Starts to poll server for state updates every second to update data structure.
    //    /// </summary>
    //    private TelemetryStream()
    //    {
    //        cancellationToken = new CancellationTokenSource();
    //        var token = cancellationToken.Token;
    //        Data = null;
    //        Task.Run(async () =>
    //        {
    //            // run infite loop polling server every second
    //            while (true)
    //            {
    //                try
    //                {
    //                    var api = new TelemetryAPI("http://localhost:3000"); //TODO: use configuration variable

    //                    var rawData = await api.GetTelemetryData();

    //                    // convert to custom object type
    //                    var newData = new TelemetryData(rawData);
    //                    Data = newData;

    //                    // TODO: notify subscribers

    //                    await Task.Delay(1000); // delay 1 second between requests
    //                }
    //                catch (Exception e)
    //                {
    //                    Console.Error.WriteLine(e.Message);
    //                    Console.Error.WriteLine(e.StackTrace);
    //                    Console.Error.WriteLine(e.Source);
    //                    Data = null;
    //                    await Task.Delay(1000);
    //                    continue;
    //                }
    //            }
    //        }, token);
    //    }

    //    public void Dispose()
    //    {
    //        if (!cancellationToken.IsCancellationRequested)
    //        {
    //            cancellationToken.Cancel();
    //        }
    //    }

    //    public void Subscribe<T>(Func<TelemetryData, T> accessor, Func<T, bool> doNotify)
    //    {

    //    }

    //    public void Subscribe<T>(Func<TelemetryData, T> accessor)
    //    {

    //    }

    //    public void Subscribe(Action<TelemetryData> data)
    //    {

    //    }
    }
}
