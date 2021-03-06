using System.Net.Http;
using System.Threading.Tasks;
//using System.Text.Json;

namespace Telemetry
{
   // <summary>
    /// Class used to query NASA server for state updates.
    /// Server is assumed to always be running and ready to send state updates.
    /// 
    /// Note: when testing on your own, you will need to run the BackEnd and FrontEnd
    /// and then open the front end web page and click the "start" buttons for both
    /// telemetry and UIA state simulations.
    /// </summary>

    public class TelemetryAPI
    {
    //    /// <summary>
    //    /// C# represenation of JSON result
    //    /// </summary>
    //    public class TelemetryDataRaw
    //    {
    //        public string _id { get; set; }
    //        public decimal time { get; set; }
    //        public string timer { get; set; }
    //        public string started_at { get; set; }
    //        public int heart_bpm { get; set; }
    //        public string p_sub { get; set; }
    //        public string p_suit { get; set; }
    //        public string t_sub { get; set; }
    //        public string v_fan { get; set; }
    //        public string p_o2 { get; set; }
    //        public string rate_o2 { get; set; }
    //        public decimal batteryPercent { get; set; }
    //        public int battery_out { get; set; }
    //        public int cap_battery { get; set; }
    //        public string t_battery { get; set; }
    //        public string p_h2o_g { get; set; }
    //        public string p_h2o_l { get; set; }
    //        public string p_sop { get; set; }
    //        public string rate_sop { get; set; }
    //        public string t_oxygenPrimary { get; set; }
    //        public string t_oxygenSec { get; set; }
    //        public string ox_primary { get; set; }
    //        public string ox_secondary { get; set; }
    //        public string t_oxygen { get; set; }
    //        public decimal cap_water { get; set; }
    //        public string t_water { get; set; }
    //        public int __v { get; set; }
    //    }

    //    /// <summary>
    //    /// C# represenation of JSON result
    //    /// </summary>
    //    public class UIADataRaw
    //    {
    //        public string _id { get; set; }
    //        public string started_at { get; set; }
    //        public string emu1 { get; set; }
    //        public string emu2 { get; set; }
    //        public int o2_supply_pressure1 { get; set; }
    //        public int o2_supply_pressure2 { get; set; }
    //        public string ev1_supply { get; set; }
    //        public string ev2_supply { get; set; }
    //        public string ev1_waste { get; set; }
    //        public string ev2_waste { get; set; }
    //        public string emu1_O2 { get; set; }
    //        public string emu2_O2 { get; set; }
    //        public int oxygen_supp_out1 { get; set; }
    //        public int oxygen_supp_out2 { get; set; }
    //        public string O2_vent { get; set; }
    //        public string depress_pump { get; set; }
    //        public int __v { get; set; }
    //    }

    //    /// <summary>
    //    /// Client used to access server
    //    /// </summary>
    //    private static HttpClient client;

    //    /// <summary>
    //    /// The current url being accessed.
    //    /// When this is changed, the client is updated.
    //    /// </summary>
    //    private static string urlString = null;

    //    public TelemetryAPI(string url)
    //    {
    //        if (client == null)
    //        {
    //            client = new HttpClient();
    //        }

    //        if (url != urlString)
    //        {
    //            urlString = url;
    //            client.BaseAddress = new System.Uri(url);
    //        }
    //    }

    //    /// <summary>
    //    /// Query the server for latest spacesuit telemetry data
    //    /// </summary>
    //    /// <returns>telemetry data</returns>
    //    public async Task<TelemetryDataRaw> GetTelemetryData()
    //    {
    //        var response = await client.GetAsync("api/simulation/state");

    //        response.EnsureSuccessStatusCode();

    //        var str = await response.Content.ReadAsStringAsync();
    //        //return JsonSerializer.Deserialize<TelemetryDataRaw>(str);
    //    }

    //    /// <summary>
    //    /// Query the server for the latest UIA state
    //    /// </summary>
    //    /// <returns>UIA state</returns>
    //    public async Task<UIADataRaw> GetUIAData()
    //    {
    //        var response = await client.GetAsync("api/simulation/uiastate");

    //        response.EnsureSuccessStatusCode();

    //        var str = await response.Content.ReadAsStringAsync();
    //       // return JsonSerializer.Deserialize<UIADataRaw>(str);
    //    }
    }

}