using BusinessFramework.WebAPI.Contracts.Notifiers;

namespace Karelia.WebAPI.Contracts
{
    /// <summary>
    ///     Notifiers' keys collection
    /// </summary>
    public static class Notifiers
    {   
        public static NotifierInfo<EmailNotifierSettings> SystemNotifier
        {
            get { return null; }
        }
    }
}