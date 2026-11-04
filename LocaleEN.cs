namespace TrafficSimulationAdjuster.Locale
{
    using System.Collections.Generic;
    using Colossal;
    using O = TrafficSimulationAdjusterOptions;

    public class LocaleEN : IDictionarySource
    {
        private readonly TrafficSimulationAdjusterOptions m_Setting;
        public LocaleEN(TrafficSimulationAdjusterOptions options) { m_Setting = options; }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Traffic Simulation Adjuster" },
                { m_Setting.GetOptionLabelLocaleID(nameof(O.TrafficReductionCoefficient)), "Traffic reduction value" },
                { m_Setting.GetOptionDescLocaleID(nameof(O.TrafficReductionCoefficient)), "Higher value means more vehicles. Lower value means less vehicles. Vanilla default is 4. Requires reloading the save to take effect." },
            };
        }
        public void Unload() { }
    }
}