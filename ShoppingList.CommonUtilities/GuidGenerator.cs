using System;
using System.Security.Cryptography;

namespace ShoppingList.CommonUtilities
{
    public class GuidGenerator : IGuidGenerator
    {
        private readonly RandomNumberGenerator _randomNumberGenerator;

        public GuidGenerator()
        {
            _randomNumberGenerator = new RNGCryptoServiceProvider();
        }

        public Guid Generate()
        {
            long timestamp = DateTime.UtcNow.Ticks / 10000L;
            byte[] guidBytes = new byte[16];
            byte[] randomBytes = new byte[10];
            byte[] timestampBytes = BitConverter.GetBytes(timestamp);
            _randomNumberGenerator.GetBytes(randomBytes);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(timestampBytes);
            }

            Buffer.BlockCopy(randomBytes, 0, guidBytes, 0, 10);
            Buffer.BlockCopy(timestampBytes, 2, guidBytes, 10, 6);

            return new Guid(guidBytes);
        }
    }
}
