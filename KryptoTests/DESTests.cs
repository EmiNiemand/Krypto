using Microsoft.VisualStudio.TestTools.UnitTesting;
using Krypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Krypto.Tests
{
    [TestClass()]
    public class DESTests
    {
        [TestMethod()]
        public void GenerateKeyTest()
        {
            DES des = new DES();
            string key = "abcdefgh";
            string key1 = "hgfedsar";

            BitArray[] subKeys = des.GenerateSubKeys(des.StringToBytes(key));
            BitArray[] subKeys1 = des.GenerateSubKeys(des.StringToBytes(key1));
            for (int i = 0; i < subKeys1.Length; i++)
            {
                Assert.AreNotEqual(subKeys[i], subKeys1[i]);
            }
        }

        [TestMethod()]
        public void RightLeftTest()
        {
            DES des = new DES();
            BitArray ar = new BitArray(8);
            ar[0] = true;
            ar[3] = true;
            ar[7] = true;
            BitArray ar2 = new BitArray(4);
            ar2[0] = true;
            ar2[3] = true;
            BitArray ar3 = new BitArray(4);
            ar3[3] = true; 
            Assert.AreEqual(des.LeftHalf(ar), ar2);
            Assert.AreEqual(des.RightHalf(ar), ar3);
        }
    }
}