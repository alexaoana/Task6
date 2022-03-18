using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.Enums.Extensions
{
    public static class OwnerLivingExtension
    {
        public static string Living(this OwnerLivingEnum ownerLiving)
        {
            switch (ownerLiving)
            {
                case OwnerLivingEnum.APARTMENT: return "This owner lives in an apartment";
                case OwnerLivingEnum.HOUSE: return "This owner lives in a house";
                case OwnerLivingEnum.SHARINGROOM: return "This owner shares a room with someone";
            }
            return "Unknown value";
        }
    }
}
