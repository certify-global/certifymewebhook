using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CERTIFYWebHookAPI.Utility
{
    public class HMACUtil
    {
        public static bool CompareHMAC256(string message, string secret, string received)
        {
            return received.Equals(GetHMAC256Hash(message, secret), StringComparison.InvariantCultureIgnoreCase);
        }
        public static string GetHMAC256Hash(string message, string secret)
        {
            var keyByte = Encoding.UTF8.GetBytes(secret);
            var messageBytes = Encoding.UTF8.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                //01 HMAC SHA256 signed with Payment.js Api Secret
                var hashMessage = hmacsha256.ComputeHash(messageBytes);
                //string converted = Encoding.UTF8.GetString(hashmessage, 0, hashmessage.Length);
                //02 resulting HMAC hash needs to be hex encoded at this point
                var hexEncodedMessage = ByteArrayToHexString(hashMessage);
                //hexencodedstring in lowercase
                return hexEncodedMessage.ToLower();
                //03 encode hex-encoded hash in Base64
                //return Convert.ToBase64String(Encoding.UTF8.GetBytes(hexEncodedMessage));
            }
        }
        public static string ByteArrayToHexString(byte[] ba)
        {
            var hex = new StringBuilder(ba.Length * 2);
            foreach (var b in ba) hex.AppendFormat("{0:X2}", b);
            return hex.ToString();
        }
    }
}