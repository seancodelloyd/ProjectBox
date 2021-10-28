using Volo.Abp.Settings;

namespace Autoboxd.Settings
{
    public class AutoboxdSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(AutoboxdSettings.MySetting1));
        }
    }
}
