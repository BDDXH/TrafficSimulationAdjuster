using Colossal.IO.AssetDatabase;
using Colossal.Logging;
using Game;
using Game.Modding;
using Game.SceneFlow;
using HarmonyLib;
using System.Reflection;
using TrafficSimulationAdjuster.Locale;

namespace TrafficSimulationAdjuster
{
    public class Mod : IMod
    {
        public static TrafficSimulationAdjusterOptions? Options { get; set; }
        
        public static ILog Log = LogManager.GetLogger($"{nameof(TrafficSimulationAdjuster)}.{nameof(Mod)}")
            .SetShowsErrorsInUI(false);

        private Harmony m_Harmony;

        public void OnLoad(UpdateSystem updateSystem)
        {
            Log.Info(nameof(OnLoad));

            // 初始化设置
            Options = new(this);
            AssetDatabase.global.LoadSettings(nameof(TrafficSimulationAdjuster), Options, new TrafficSimulationAdjusterOptions(this));
            Options.RegisterInOptionsUI();
            
            // 注册多语言
            GameManager.instance.localizationManager.AddSource("en-US", new LocaleEN(Options));
            GameManager.instance.localizationManager.AddSource("zh-HANS", new LocaleZHHANS(Options));

            // 启动 Harmony 补丁
            m_Harmony = new Harmony("com.tduck973564.TrafficSimulationAdjuster");
            m_Harmony.PatchAll(Assembly.GetExecutingAssembly());
            Log.Info("Harmony patches applied!");
        }

        public void OnDispose()
        {
            // 卸载补丁
            m_Harmony?.UnpatchAll("com.tduck973564.TrafficSimulationAdjuster");
        }
    }
}