using PoseidonSharp;
using System.Numerics;

namespace LoopringSharp
{
    public static class PoseidonHelper
    {
        public static BigInteger GetPoseidonHash(BigInteger[] inputs)
        {            
            var poseidonHasher = new Poseidon(inputs.Length + 1, 6, 53, "poseidon", 5, _securityTarget: 128);            
            return poseidonHasher.CalculatePoseidonHash(inputs);
        }
    }
}
