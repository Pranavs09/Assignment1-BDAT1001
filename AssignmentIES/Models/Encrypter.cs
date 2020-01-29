using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace AssignmentIES.Models
{
    class Encrypter
    {
        public Encrypter(string originalText, int[] encryptionCipher = null, int encryptionDepth = 1)
        {
            OriginalText = originalText;

            if (encryptionCipher != null)
            {
                if (EncryptionCipher != encryptionCipher)
                {
                    EncryptionCipher = encryptionCipher;
                }
            }

            if (EncryptionDepth != encryptionDepth)
            {
                EncryptionDepth = encryptionDepth;
            }

            ConvertText(OriginalText, EncryptionCipher, EncryptionDepth);
        }

        public void ConvertText(string originalText, int[] encryptionCipher = null, int encryptionDepth = 1)
        {
            CipherEncrypted = DeepEncryptWithCipher(OriginalText, EncryptionCipher, EncryptionDepth);

            Base64 = StringToBase64(OriginalText);
            Binary = StringToBinary(OriginalText);
            Hexadecimal = StringToHex(OriginalText);
        }

        public string OriginalText { get; internal set; }
        public int[] EncryptionCipher { get; } = new[] { 1, 1, 2, 3, 5, 8 }; 
        public int EncryptionDepth { get; } = 1;
        public string CipherEncrypted { get; internal set; }
        public string Base64 { get; internal set; }
        public string Binary { get; internal set; }
        public string Hexadecimal { get; internal set; }

        public static string DeepEncryptWithCipher(string originalText, int[] encryptionCipher, int encryptionDepth)
        {
            string result = originalText;

            for (int depth = 0; depth < encryptionDepth; depth++)
            {
                result = EncryptWithCipher(result, encryptionCipher);
            }

            return result;
        }
        public static string EncryptWithCipher(string text, int[] encryptionCipher)
        {
            if (encryptionCipher == null || encryptionCipher.Length == 0)
            {
                return text;
            }
            byte[] bytearray = Encoding.Unicode.GetBytes(text);

            byte[] bytearrayresult = bytearray;

            int encryptionCipherIndex = 0;

            for (int i = 0; i < bytearray.Length; i++)
            {
                encryptionCipherIndex = i;

                if (encryptionCipherIndex >= encryptionCipher.Length)
                {
                    encryptionCipherIndex = 0;
                }

                if (bytearray[i] != 0)
                {
                    bytearrayresult[i] = (byte)(bytearray[i] + encryptionCipher[encryptionCipherIndex]);
                }
            }

            string newresult = Encoding.Unicode.GetString(bytearrayresult);

            return newresult;
        }

       
        public static string DeepDecryptWithCipher(string originalText, int[] encryptionCipher, int encryptionDepth)
        {
            string result = originalText;

            string[] encryptedValues = new string[encryptionDepth + 1];
            encryptedValues[0] = result;

            for (int depth = 0; depth < encryptionDepth; depth++)
            {
                result = DecryptWithCipher(result, encryptionCipher);

                encryptedValues[depth + 1] = result;
            }

            return result;
        }
        public static string DecryptWithCipher(string text, int[] encryptionCipher)
        {
            byte[] bytearray = Encoding.Unicode.GetBytes(text);
            byte[] bytearrayresult = bytearray;

            int encryptionCipherIndex = 0;

            for (int i = 0; i < bytearray.Length; i++)
            {
                encryptionCipherIndex = i;

                if (encryptionCipherIndex >= encryptionCipher.Length)
                {
                    encryptionCipherIndex = 0;
                }

                if (bytearray[i] != 0)
                {
                    bytearrayresult[i] = (byte)(bytearray[i] - encryptionCipher[encryptionCipherIndex]);
                }
            }

            string newresult = Encoding.Unicode.GetString(bytearrayresult);

            return newresult;
        }
        public static string Base64ToString(string data)
        {
            if (String.IsNullOrEmpty(data))
            {
                return String.Empty;
            }

            byte[] bytearray = Convert.FromBase64String(data);

            return Encoding.Unicode.GetString(bytearray);
        }
        public static string StringToBase64(string data)
        {
            byte[] bytearray = Encoding.Unicode.GetBytes(data);

            return Convert.ToBase64String(bytearray);
        }
        public static string StringToHex(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 16).PadLeft(2, '0') + " ");
            }

            return sb.ToString().ToUpper();
        }
        public static string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0') + " ");
            }
            return sb.ToString();
        }

    }
}

