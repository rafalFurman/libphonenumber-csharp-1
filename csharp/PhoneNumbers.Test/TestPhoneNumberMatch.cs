/*
 * Copyright (C) 2009 Google Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if NETFX_CORE
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework; 
#else 
using Microsoft.VisualStudio.TestTools.UnitTesting; 
#endif

namespace PhoneNumbers.Test
{
    [TestClass]
    public class TestPhoneNumberMatch
    {
        [TestMethod]
        public void TestValueTypeSemantics()
        {
            PhoneNumber number = new PhoneNumber();
            PhoneNumberMatch match1 = new PhoneNumberMatch(10, "1 800 234 45 67", number);
            PhoneNumberMatch match2 = new PhoneNumberMatch(10, "1 800 234 45 67", number);

            Assert.AreEqual(match1, match2);
            Assert.AreEqual(match1.GetHashCode(), match2.GetHashCode());
            Assert.AreEqual(match1.Start, match2.Start);
            Assert.AreEqual(match1.Length, match2.Length);
            Assert.AreEqual(match1.Number, match2.Number);
            Assert.AreEqual(match1.RawString, match2.RawString);
            Assert.AreEqual("1 800 234 45 67", match1.RawString);
        }

        /**
        * Tests the value type semantics for matches with a null number.
        */
        [TestMethod]
        public void TestIllegalArguments()
        {
            try
            {
                new PhoneNumberMatch(-110, "1 800 234 45 67", new PhoneNumber());
                Assert.Fail();
            }
            catch (ArgumentException) { /* success */ }

            try
            {
                new PhoneNumberMatch(10, "1 800 234 45 67", null);
                Assert.Fail();
            }
            catch (ArgumentNullException) { /* success */ }

            try
            {
                new PhoneNumberMatch(10, null, new PhoneNumber());
                Assert.Fail();
            }
            catch (ArgumentNullException) { /* success */ }

            try
            {
                new PhoneNumberMatch(10, null, null);
                Assert.Fail();
            }
            catch (ArgumentNullException) { /* success */ }
        }
    }
}
