using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypto
{
    public class DES
    {
        private byte[] permutBeg = new byte[]{
            58, 50, 42, 34, 26, 18, 10, 2,
            60, 52, 44, 36, 28, 20, 12, 4,
            62, 54, 46, 38, 30, 22, 14, 6,
            64, 56, 48, 40, 32, 24, 16, 8,
            57, 49, 41, 33, 25, 17, 9, 1,
            59, 51, 43, 35, 27, 19, 11, 3,
            61, 53, 45, 37, 29, 21, 13, 5,
            63, 55, 47, 39, 31, 23, 15, 7};

        private byte[] permutRevBeg = new byte[]{
            40, 8, 48, 16, 56, 24, 64, 32,
            39, 7, 47, 15, 55, 23, 63, 31,
            38, 6, 46, 14, 54, 22, 62, 30,
            37, 5, 45, 13, 53, 21, 61, 29,
            36, 4, 44, 12, 52, 20, 60, 28,
            35, 3, 43, 11, 51, 19, 59, 27,
            34, 2, 42, 10, 50, 18, 58, 26,
            33, 1, 41, 9, 49, 17, 57, 25};

        private byte[] permutKeyPC1 = new byte[]{
            57, 49, 41, 33, 25, 17, 9,
            1, 58, 50, 42, 34, 26, 18,
            10, 2, 59, 51, 43, 35, 27,
            19, 11, 3, 60, 52, 44, 36,
            63, 55, 47, 39, 31, 23, 15,
            7, 62, 54, 46, 38, 30, 22,
            14, 6, 61, 53, 45, 37, 29,
            21, 13, 5, 28, 20, 12, 4};

        private byte[] permutKeyPC2 = new byte[]{
            14, 17, 11, 24, 1, 5,
            3, 28, 15, 6, 21, 10,
            23, 19, 12, 4, 26, 8,
            16, 7, 27, 20, 13, 2,
            41, 52, 31, 37, 47, 55,
            30, 40, 51, 45, 33, 48,
            44, 49, 39, 56, 34, 53,
            46, 42, 50, 36, 29, 32};

        private byte[] permutExt = new byte[]{
            32, 1, 2, 3, 4, 5,
            4, 5, 6, 7, 8, 9,
            8, 9, 10, 11, 12, 13,
            12, 13, 14, 15, 16, 17,
            16, 17, 18, 19, 20, 21,
            20, 21, 22, 23, 24, 25,
            24, 25, 26, 27, 28, 29,
            28, 29, 30, 31, 32, 1};

        private byte[] permutPBlock = new byte[]{
            16, 7, 20, 21,
            29, 12, 28, 17,
            1, 15, 23, 26,
            5, 18, 31, 10,
            2, 8, 24, 14,
            32, 27, 3, 9,
            19, 13, 30, 6,
            22, 11, 4, 25};

        private byte[] shiftKeyBites = new byte[]
                {1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1};


        private byte[][] SBox = new byte[][]{
            new byte[]{
                    14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7,
                    0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8,
                    4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0,
                    15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13},
            new byte[]{
                    15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10,
                    3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5,
                    0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15,
                    13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9},
            new byte[]{
                    10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8,
                    13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1,
                    13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7,
                    1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12},
            new byte[]{
                    7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15,
                    13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9,
                    10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4,
                    3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14},
            new byte[]{
                    2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9,
                    14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6,
                    4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14,
                    11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3},
            new byte[]{
                    12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11,
                    10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8,
                    9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6,
                    4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13},
            new byte[]{
                    4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1,
                    13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6,
                    1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2,
                    6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12},
            new byte[]{
                    13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7,
                    1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2,
                    7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8,
                    2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11}};

        int numberOfBitsAdded;



        public string GenerateKey()
        {
            Random random = new Random();
            byte[] keyBytes = new byte[8];
            random.NextBytes(keyBytes);
            return BytesToString(keyBytes);
        }

        //Type Converters
        public byte[] StringToBytes(string text)
        {
            var characters = text.ToCharArray();
            return characters.Select(c => (byte)c).ToArray();
        }

        public BitArray BytesToBits(byte[] array)
		{
            BitArray bits = new BitArray(array);
            BitArray final = new BitArray(1);
            for (int i = 0; i < array.Length; i++)
			{
                bool[] temp = new bool[8];
                for(int j = i * 8; j < i * 8 + 8; j++)
                {
                    temp[j % 8] = bits[j];
                }
                Array.Reverse(temp);
                if(i == 0)
                {
                    final = new BitArray(temp);
                }
                else
                {
                    final = Concat(final, new BitArray(temp));
                }
			}

            return final;
        }

        public string BytesToString(byte[] array)
        {
            var characters = array.Select(b => (char)b).ToArray();
            return new string(characters);
        }

        public byte[] BitsToBytes(BitArray array)
        {
            byte[] bytes = new byte[array.Length / 8];
            for(int i = 0; i < array.Length / 8; i++)
            {
                bool[] bits = new bool[8];
                for (int j = i * 8; j < i * 8 + 8; j++)
                {
                    bits[j%8] = array[j];
                }
                bytes[i] = BoolArrayToByte(bits);
            }
            return bytes;
        }

        static byte BoolArrayToByte(bool[] source)
        {
            byte result = 0;
            int index = 8 - source.Length;
            foreach (bool b in source)
            {
                if (b) 
                {
                    result |= (byte)(1 << (7 - index));
                }
                index++;
            }
            return result;
        }

        BitArray Concat(BitArray one, BitArray two)
        {
            bool[] concat = new bool[one.Length + two.Length];
            for (int i = 0; i < one.Length; i++)
            {
                concat[i] = one[i];
            }
            for (int i = one.Length; i < one.Length + two.Length; i++)
            {
                concat[i] = two[i - one.Length];
            }
            return new BitArray(concat);
        }

        BitArray Permutation(BitArray bits, byte[] permut)
        {
            bool[] toPermut = new bool[permut.Length];

            for (int i = 0; i < permut.Length; i++)
            {
                toPermut[i] = bits[permut[i] - 1];
            }

            return new BitArray(toPermut);
        }

        BitArray XOR(BitArray one, BitArray two)
        {
            return one.Xor(two);
        }

        BitArray ShiftLeft(BitArray bits, byte number)
        {
            int inumber = (int)number;
            List<bool> shift = new List<bool>();
            BitArray temp = new BitArray(bits.Length);
            for (int i = 0; i < inumber; i++)
            {
                shift.Add(bits[0]);
                for(int j = 0; j < bits.Length; j++)
                {
                    temp[i] = bits[i+1];
                }
            }
            int k = 0;
            for(int i = bits.Length-inumber; i < bits.Length; i++)
            {
                temp[i] = shift[k];
                k++;
            }
            return temp;
        }

        BitArray LeftHalf(BitArray bits)
        {
            bool[] leftSide = new bool[bits.Length/2];
            for(int i = 0; i < leftSide.Length; i++)
            {
                leftSide[i] = bits[i];
            }
            return new BitArray(leftSide);
        }

        BitArray RightHalf(BitArray bits)
        {
            bool[] rightSide = new bool[bits.Length/2];
            for(int i = 0; i < rightSide.Length; i++)
            {
                rightSide[i] = bits[i + rightSide.Length];
            }
            return new BitArray(rightSide);
        }

        BitArray[] GenerateSubKeys(byte[] key)
        {
            BitArray[] subkeys = new BitArray[16];
            BitArray keyBits = BytesToBits(key);

            BitArray permutKey = Permutation(new BitArray(key), permutKeyPC1);
            BitArray temp;
            BitArray rightHalf = RightHalf(permutKey);
            BitArray leftHalf = LeftHalf(permutKey);

            for (int i = 0; i < 16; i++)
            {
                leftHalf = ShiftLeft(leftHalf, shiftKeyBites[i]);
                rightHalf = ShiftLeft(rightHalf, shiftKeyBites[i]);
                temp = Concat(leftHalf, rightHalf);
                subkeys[i] = Permutation(temp, permutKeyPC2);
            }

            return subkeys;
        }

        int getNumber(BitArray bits)
        {
            bool[] column = {bits[1], bits[2], bits[3], bits[4]};
            bool[] row = {bits[0], bits[5]};
            return Convert.ToInt32(BoolArrayToByte(row) * 16 + BoolArrayToByte(column));
        }

        BitArray FeistelFunction(BitArray rightHalf, BitArray key)
        {
            BitArray result = new BitArray(1);
            BitArray permutRight = Permutation(rightHalf, permutExt);
            BitArray xor = XOR(permutRight, key);
            BitArray[] groups = new BitArray[xor.Length/6];

            for (int i = 0; i < xor.Length/6; i++)
            {
                bool[] bitArray = new bool[6];
                for (int j = i * 6; j < i * 6 + 6; j++)
                {
                    bitArray[j%6] = xor[j];
                }
                groups[i] = new BitArray(bitArray);
            }

            byte[] temp = new byte[1];

            for (int i = 0; i < groups.Length; i++)
            {
                temp[0] = SBox[i][getNumber(groups[i])];
                BitArray helper = new BitArray(temp);
                bool[] tempResult = new bool[4];
                int k = 0;
                for (int j = 7; j >= 4; j--, k++)
                {
                    tempResult[k] = helper[j];
                }
                if(i == 0)
                {
                    result = new BitArray(tempResult);
                } 
                else
                {
                    result = Concat(result, new BitArray(tempResult));
                }
            }
            result = Permutation(result, permutPBlock);
            return result;
        }

        BitArray BlockIterations(BitArray rightHalf, BitArray leftHalf, BitArray[] subKeys)
        {
            BitArray left = new BitArray(leftHalf);
            BitArray right = new BitArray(rightHalf);
            
            for (int i = 0; i < 16; i++)
            {
                BitArray previousLeft = new BitArray(left);
                left = new BitArray(right);
                right = XOR(previousLeft, FeistelFunction(right, subKeys[i]));
            }
            BitArray result = Concat(right, left);
            result = Permutation(result, permutRevBeg);
            return result;
        }




        public byte[] Cipher(byte[] message, string key)
        {
            BitArray[] subKeys = GenerateSubKeys(StringToBytes(key));

            BitArray bitMessage = BytesToBits(message);
            if(bitMessage.Length % 64 != 0)
            {
                BitArray newBitMessage = new BitArray(bitMessage.Length + (64 - bitMessage.Length % 64));
                this.numberOfBitsAdded = 64 - bitMessage.Length % 64;
                for(int i = 0; i < bitMessage.Length; i++)
                {
                    newBitMessage[i] = bitMessage[i];
                }
                bitMessage = newBitMessage;
            }

            BitArray[] blocks = new BitArray[bitMessage.Length / 64];
            for(int i = 0; i < bitMessage.Length; i = i + 64)
            {
                BitArray temp = new BitArray(64);
                for(int j = i; j < i + 64; j++)
                {
                    temp[j % 64] = bitMessage[j];
                }
                blocks[i / 64] = temp;
            }

            BitArray final = new BitArray(1);
            int hNum = 0;
            foreach(BitArray block in blocks)
            {
                BitArray permutB = Permutation(block, permutBeg);
                BitArray leftHalf = LeftHalf(permutB);
                BitArray rightHalf = RightHalf(permutB);
                if(hNum == 0)
                {
                    final = BlockIterations(rightHalf, leftHalf, subKeys);
                } 
                else
                {
                    final = Concat(final, BlockIterations(rightHalf, leftHalf, subKeys));
                }
                hNum++;
            }
            byte[] CypheredMessage = BitsToBytes(final);
            return CypheredMessage;
        }

        public byte[] Decipher(byte[] message, string key)
        {
            BitArray[] subKeys = GenerateSubKeys(StringToBytes(key));

            Array.Reverse(subKeys);

            BitArray bitMessage = BytesToBits(message);

            BitArray[] blocks = new BitArray[bitMessage.Length / 64];
            for(int i = 0; i < bitMessage.Length; i = i + 64)
            {
                BitArray temp = new BitArray(64);
                for(int j = i; j < i + 64; j++)
                {
                    temp[j % 64] = bitMessage[j];
                }
                blocks[i / 64] = temp;
            }

            BitArray final = new BitArray(bitMessage.Length);
            int hNum = 0;
            foreach (BitArray block in blocks)
            {
                BitArray permutB = Permutation(block, permutBeg);
                BitArray leftHalf = LeftHalf(permutB);
                BitArray rightHalf = RightHalf(permutB);
                if (hNum == 0)
                {
                    final = BlockIterations(rightHalf, leftHalf, subKeys);
                }
                else
                {
                    final = Concat(final, BlockIterations(rightHalf, leftHalf, subKeys));
                }
                hNum++;
            }

            BitArray orginalBitMessage = new BitArray(final.Length - numberOfBitsAdded);

            for(int i = 0; i < final.Length - numberOfBitsAdded; i++)
            {
                orginalBitMessage[i] = final[i];
            }

            byte[] orginalMessage = BitsToBytes(orginalBitMessage);
            return orginalMessage;
        }
       
    }
}
