using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Utilities;

namespace Wildfire_ICS_Tests
{
    [TestClass]
    public class EncryptionTests
    {
        [TestMethod]
        public void TestEncryption()
        {
            string password = RandomPasswordGenerator.GeneratePassword();
            string plainText = StringExt.LoremIpsum(3, 30, 1, 5, 1);
            
            string encrypted = StringCipher.Encrypt(plainText, password);
            string decrypted = StringCipher.Decrypt(encrypted, password);
            Assert.AreEqual(plainText, decrypted);
        }
    }
}
