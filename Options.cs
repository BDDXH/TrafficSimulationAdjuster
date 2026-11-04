using Colossal.IO.AssetDatabase;
using Game.Modding;
using Game.Settings;

namespace TrafficSimulationAdjuster;

[FileLocation(nameof(TrafficSimulationAdjuster))]
public class TrafficSimulationAdjusterOptions : ModSetting
{
    public TrafficSimulationAdjusterOptions(IMod mod) : base(mod)
    {
        SetDefaults();
    }

    [SettingsUISlider(min = 0, max = 10, step = 1)] 
    public int TrafficReductionCoefficient { get; set; }
    
    public sealed override void SetDefaults()
    {
        // 4 是原版默认值
        TrafficReductionCoefficient = 4;
    }
}