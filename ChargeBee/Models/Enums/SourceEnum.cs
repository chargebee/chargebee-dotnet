using System.ComponentModel;
using System.Runtime.Serialization;

namespace ChargeBee.Models.Enums
{
    public enum SourceEnum
    {

        [EnumMember(Value = "Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [EnumMember(Value = "admin_console")]
         AdminConsole,

        [EnumMember(Value = "api")]
         Api,

        [EnumMember(Value = "scheduled_job")]
         ScheduledJob,

        [EnumMember(Value = "hosted_page")]
         HostedPage,

        [EnumMember(Value = "portal")]
         Portal,

        [EnumMember(Value = "system")]
         System,

        [EnumMember(Value = "none")]
         None,

        [EnumMember(Value = "js_api")]
         JsApi,

        [EnumMember(Value = "migration")]
         Migration,

        [EnumMember(Value = "bulk_operation")]
         BulkOperation,

        [EnumMember(Value = "external_service")]
         ExternalService,

    }
}