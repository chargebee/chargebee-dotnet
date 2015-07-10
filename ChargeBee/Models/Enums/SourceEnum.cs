using System.ComponentModel;

namespace ChargeBee.Models.Enums
{
    public enum SourceEnum
    {

        [Description("Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [Description("admin_console")]
         AdminConsole,

        [Description("api")]
         Api,

        [Description("scheduled_job")]
         ScheduledJob,

        [Description("hosted_page")]
         HostedPage,

        [Description("system")]
         System,

        [Description("none")]
         None,

        [Description("js_api")]
         JsApi,

        [Description("portal")]
         Portal,

        [Description("migration")]
         Migration,

    }
}