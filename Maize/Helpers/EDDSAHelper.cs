using Maize;
using Nethereum.Signer;
using PoseidonSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Numerics;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace LoopringSharp
{
    public static partial class EDDSAHelper
    {
        public static string EDDSASign(BigInteger[] inputs, string loopringAddress)
        {
            var signer = new Eddsa(PoseidonHelper.GetPoseidonHash(inputs), loopringAddress);
            return signer.Sign();
        }

       

        public static (string publicKeyX, string publicKeyY, string secretKey, string ethAddress) EDDSASignLocal(string exchangeAddress, int nonce, string l1Pk, string ethAddress, bool skipPublicKeyCalculation = false)
        {
            string msg1 = "Sign this message to access Loopring Exchange: "+exchangeAddress+" with key nonce: "+(nonce);
            var signer1 = new EthereumMessageSigner();
            var rawKey = signer1.EncodeUTF8AndSign(msg1, new EthECKey(l1Pk));
            // Requesting metamask to sign our package so we can tare it apart and get our public and secret keys

            return RipKeyAppart((rawKey,ethAddress), skipPublicKeyCalculation);
        }

        public static (string publicKeyX, string publicKeyY, string secretKey, string ethAddress) RipKeyAppart((string eddsa,string ethAddress) rawKey, bool skipPublicKeyCalculation = false)
        {
            BigInteger order = BigInteger.Parse("21888242871839275222246405745257275088614511777268538073601725287587578984328");
            BigInteger p = BigInteger.Parse("21888242871839275222246405745257275088548364400416034343698204186575808495617");
            BigInteger[] Base8 = new BigInteger[] {
                BigInteger.Parse("16540640123574156134436876038791482806971768689494387082833631921987005038935"),
                BigInteger.Parse("20819045374670962167435360035096875258406992893633759881276124905556507972311") };
            BigInteger suborder = rsh(order, 3);
            byte[] rawKeyBytes = ToHexBytes(rawKey.eddsa.Replace("0x", ""));
            var number = Utils.ParseHexUnsigned(rawKey.eddsa);

            var sha256Managed = new SHA256Managed();
            byte[] seed = sha256Managed.ComputeHash(rawKeyBytes);

            var lebuffResult = leBuff2Int(seed);
            var secertKey = leBuff2Int(seed) % suborder;
            BigInteger[] publicKey = new BigInteger[2];

            // Have this logic to save on computing resources. No reason to calculate them unless needed
            // The only time we actually need these is if the user wants to export their wallet
            if (!skipPublicKeyCalculation)
                publicKey = mulPointEscalar(Base8, secertKey, p);

            return ("0x" + publicKey[0].ToString("x").PadLeft(64,'0'), "0x" + publicKey[1].ToString("x").PadLeft(64, '0'), "0x" + secertKey.ToString("x").PadLeft(64, '0'), rawKey.ethAddress);
        }
        
        public static string EddsaSignUrl(string l2Pk, HttpMethod method, List<(string Key, string Value)> queryParams, string postBody, string apiMethod, string apiUrl)
        {
            var message = Utils.CreateSha256Signature(
                method,
                queryParams,
                postBody,
                apiMethod,
                apiUrl);

            var signer = new Eddsa(message, l2Pk);
            return signer.Sign();
        }

        #region Public Key calculation methods

        static BigInteger[] mulPointEscalar(BigInteger[] tbase, BigInteger secretKey, BigInteger p)
        {
            BigInteger[] res = new[] { BigInteger.Parse("0"), BigInteger.Parse("1") };
            var rem = secretKey;
            var exp = tbase;

            while (rem != 0)
            {
                if ((rem & BigInteger.Parse("1")) == BigInteger.Parse("1"))
                    res = addPoint(res, exp, p);
                exp = addPoint(exp, exp, p);
                rem = rem / 2;
            }
            return res;
        }

        static BigInteger[] addPoint(BigInteger[] a, BigInteger[] b, BigInteger p)
        {
            var res = new BigInteger[2];
            var beta = Pmul(a[0], b[1], p);
            var gamma = Pmul(a[1], b[0], p);

            var breakdown1 = Pmul(BigInteger.Parse("168700"), a[0], p);
            var breakdown2 = Psub(a[1], breakdown1, p);
            var breakdown3 = Padd(b[0], b[1], p);

            var delta = Pmul(breakdown2, breakdown3, p);
            var tau = Pmul(beta, gamma, p);
            var dtau = Pmul(BigInteger.Parse("168696"), tau, p);

            res[0] = Pdiv(Padd(beta, gamma, p), Padd(1, dtau, p), p);
            res[1] = Pdiv(
                Padd(delta, Psub(Pmul(BigInteger.Parse("168700"), beta, p), gamma, p), p),
                Psub(1, dtau, p),
                p);

            return res;
        }

        static BigInteger Pmul(BigInteger a, BigInteger b, BigInteger p)
        {
            return BigInteger.Remainder(BigInteger.Multiply(a, b), p);
        }

        static BigInteger Psub(BigInteger a, BigInteger b, BigInteger p)
        {
            return (a >= b) ? BigInteger.Subtract(a, b) : BigInteger.Add(BigInteger.Subtract(p, b), a);
        }

        static BigInteger Padd(BigInteger a, BigInteger b, BigInteger p)
        {
            var res = BigInteger.Add(a, b);
            return (res >= p ? res - p : res);
        }

        static BigInteger Pdiv(BigInteger a, BigInteger b, BigInteger p)
        {
            return Pmul(a, Pinv(b, p), p);
        }

        static BigInteger Pinv(BigInteger a, BigInteger p)
        {
            BigInteger t = 0;
            BigInteger r = p;
            BigInteger newt = 1;
            BigInteger newr = a % p;
            while (newr > 0)
            {
                BigInteger q = r / newr;
                var oldt = t;
                t = newt;
                newt = oldt - q * newt;
                var oldr = r;
                r = newr;
                newr = oldr - q * newr;
            }
            if (t < 0) t += p;
            return t;
        }

        static BigInteger leBuff2Int(byte[] buff)
        {
            BigInteger res = 0;
            for(int i=0;i<buff.Length;i++)
            {
                var n = new BigInteger(buff[i]);
                res = BigInteger.Add(res, n << (i * 8));
            }

            return res;
        }        

        static BigInteger rsh(BigInteger original, int order)
        {
            BigInteger multiplier = (BigInteger)Math.Pow(2, order);
            return original / multiplier;
        }

        static byte[] ToHexBytes(string hex)
        {
            Dictionary<char, byte> hexmap = new Dictionary<char, byte>()
            {
                { 'a', 0xA },{ 'b', 0xB },{ 'c', 0xC },{ 'd', 0xD },
                { 'e', 0xE },{ 'f', 0xF },{ 'A', 0xA },{ 'B', 0xB },
                { 'C', 0xC },{ 'D', 0xD },{ 'E', 0xE },{ 'F', 0xF },
                { '0', 0x0 },{ '1', 0x1 },{ '2', 0x2 },{ '3', 0x3 },
                { '4', 0x4 },{ '5', 0x5 },{ '6', 0x6 },{ '7', 0x7 },
                { '8', 0x8 },{ '9', 0x9 }
            };

            if (string.IsNullOrWhiteSpace(hex))
                throw new ArgumentException("Hex cannot be null/empty/whitespace");

            if (hex.Length % 2 != 0)
                throw new FormatException("Hex must have an even number of characters");

            bool startsWithHexStart = hex.StartsWith("0x", StringComparison.OrdinalIgnoreCase);

            if (startsWithHexStart && hex.Length == 2)
                throw new ArgumentException("There are no characters in the hex string");


            int startIndex = startsWithHexStart ? 2 : 0;

            byte[] bytesArr = new byte[(hex.Length - startIndex) / 2];

            char left;
            char right;

            try
            {
                int x = 0;
                for (int i = startIndex; i < hex.Length; i += 2, x++)
                {
                    left = hex[i];
                    right = hex[i + 1];
                    bytesArr[x] = (byte)((hexmap[left] << 4) | hexmap[right]);
                }
                return bytesArr;
            }
            catch (KeyNotFoundException)
            {
                throw new FormatException("Hex string has non-hex character");
            }
        }

        #endregion
    }
}
