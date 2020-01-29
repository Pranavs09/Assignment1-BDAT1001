using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AssignmentIES.Models;

namespace AssignmentIES
{
    class StringConversion
    {
        public static void Main(string[] args)
        {
            // String To Binary
            Console.WriteLine("Enter Your Name : ");
            string name = Console.ReadLine();
            string toBinary = StringToBinary(name);
            Console.WriteLine(toBinary);
           
            //Binary To String
            Console.WriteLine("Enter Binary Number of Your Name As Same From The Above Code : ");
            string binary = Console.ReadLine();
            string toString = BinaryToString(binary);
            Console.WriteLine(toString);
            
            // String To Hexadecimal
            Console.WriteLine("Enter Your Name : ");
            string Name = Console.ReadLine();
            string toHexa = StringToHexa(Name);
            Console.WriteLine(toHexa);

            //Hexadecimal TO String
            Console.WriteLine("Enter Your Hexa Decimal Value : ");
            string Hd = Console.ReadLine();
            string ToASCII = HexaToAscii(Hd);
            Console.WriteLine(ToASCII);

            //String To Base64
            Console.WriteLine("Enter Your Name : ");
            string name1 = Console.ReadLine();
            string toBase64 = StringToBase64(name1);
            Console.WriteLine(toBase64);

            //String To Base64
            Console.WriteLine("Enter Your Base64 Type : ");
            string base64 = Console.ReadLine();
            string toAscii1 = Base64ToString(base64);
            Console.WriteLine(toAscii1);

            // Encryption and Deceyption 
            Console.WriteLine("Enter Your Name : ");
            string unicodeString = Console.ReadLine();
            int[] cipher = new[] { 1, 1, 2, 3, 5, 8, 13 };
            string cipherasString = String.Join(",", cipher.Select(x => x.ToString()));

            int encryptionDepth = 20;

            Encrypter encrypter = new Encrypter(unicodeString, cipher, encryptionDepth);

            //Deep Encrytion
            string nameDeepEncryptWithCipher = Encrypter.DeepEncryptWithCipher(unicodeString, cipher, encryptionDepth);
            Console.WriteLine($"Deep Encrypted {encryptionDepth} times using the cipher {nameDeepEncryptWithCipher}");

            string nameDeepDecryptWithCipher = Encrypter.DeepDecryptWithCipher(nameDeepEncryptWithCipher, cipher, encryptionDepth);
            Console.WriteLine($"Deep Decrypted {encryptionDepth} times using the cipher {nameDeepDecryptWithCipher}");
        }

        // Converting String to Binary
        public static string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }

        // Converting Binary to String
        public static string BinaryToString(string data)
        {
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < data.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }

        //Converting Your Name To HexaDecimal
        public static string StringToHexa(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 16).PadLeft(2, '0'));
            }

            return sb.ToString().ToUpper();
        }

        // Converting HexaDecimal To ASCII  

        public static string HexaToAscii(string data)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= data.Length - 2; i += 2)
            {
                sb.Append(Convert.ToString(Convert.ToChar(Int32.Parse(data.Substring(i, 2),
                System.Globalization.NumberStyles.HexNumber))));
            }
            return sb.ToString();
        }

        // String To Base64
        public static string StringToBase64(string data)
        {
            byte[] bytearray = Encoding.ASCII.GetBytes(data);

            string result = Convert.ToBase64String(bytearray);

            return result;
        }

        // Base64 To Ascii
        public static string Base64ToString(string base64String)
        {
            byte[] bytearray = Convert.FromBase64String(base64String);

            using (var ms = new MemoryStream(bytearray))
            {
                using (StreamReader reader = new StreamReader(ms))
                {
                    string text = reader.ReadToEnd();
                    return text;
                }
            }
        }
    }
}

