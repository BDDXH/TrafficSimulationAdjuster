namespace TrafficSimulationAdjuster.Locale
{
    using System.Collections.Generic;
    using Colossal;
    using O = TrafficSimulationAdjusterOptions;

    public class LocaleZHHANS : IDictionarySource
    {
        private readonly TrafficSimulationAdjusterOptions m_Setting;
        public LocaleZHHANS(TrafficSimulationAdjusterOptions options) { m_Setting = options; }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "交通模拟调整" },
                { m_Setting.GetOptionLabelLocaleID(nameof(O.TrafficReductionCoefficient)), "交通流量参数" },
                { m_Setting.GetOptionDescLocaleID(nameof(O.TrafficReductionCoefficient)), "值越高，路上车辆越多；值越低，市民越倾向于网购，路上车辆越少。原版默认值为 4。注意：更改此项后需重新加载存档生效。" },
            };
        }
        public void Unload() { }
    }
}