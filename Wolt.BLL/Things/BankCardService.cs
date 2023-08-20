using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.Things
{
    public static class BankCardService
    {
        public static string MaskCardNumber(string cardNumber)
        {
            const int VisibleDigitsCardNumber = 6; 
            const string MaskCharacter = "*";

            if (cardNumber.Length >= VisibleDigitsCardNumber)
            {
                string visiblePart = cardNumber.Substring(0, 2) + new string(MaskCharacter[0], cardNumber.Length - VisibleDigitsCardNumber) + cardNumber.Substring(cardNumber.Length - 4);
                return visiblePart;
            }
            return new string(MaskCharacter[0], cardNumber.Length);
        }

        public static string MaskSensitiveInfo(string value, int visibleLength)
        {
            const string MaskCharacter = "*";
            return new string(MaskCharacter[0], visibleLength);
        }
    }
}
