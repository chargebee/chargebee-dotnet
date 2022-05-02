using System.ComponentModel;
using System.Runtime.Serialization;

namespace ChargeBee.Models.Enums
{
    public enum ChannelEnum
    {

        [EnumMember(Value = "Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [EnumMember(Value = "web")]
         Web,

        [EnumMember(Value = "app_store")]
         AppStore,

        [EnumMember(Value = "play_store")]
         PlayStore,

    }
}