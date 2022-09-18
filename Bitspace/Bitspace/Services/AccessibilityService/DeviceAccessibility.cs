using System;

namespace Bitspace.Services
{
    public class DeviceAccessibility
    {
        private static Lazy<IAccessibilityService> Implementation = new Lazy<IAccessibilityService>(() => CreateAccessibilityService(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        public static IAccessibilityService Current
        {
            get
            {
                var curr = Implementation.Value;
                if (curr == null)
                {
                    throw new Exception();
                }

                return curr;
            }
        }

        private static IAccessibilityService CreateAccessibilityService()
        {
            return new DeviceAccessibilityImplementation();
        }
    }
}