/*
 * Copyright (C) 2011 The Libphonenumber Authors
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
    /**
     * Unit tests for ShortNumberUtil.java
     *
     * @author Shaopeng Jia
     */
    [TestClass]
    public class ShortNumberUtilTest : TestMetadataTestCase
    {
        private ShortNumberUtil shortUtil;

        [TestInitialize]
        public void SetupFixture()
        {
            base.SetupFixture();
            shortUtil = new ShortNumberUtil(phoneUtil);
        }

        [TestMethod]
        public void testConnectsToEmergencyNumber_US()
        {
            Assert.IsTrue(shortUtil.ConnectsToEmergencyNumber("911", RegionCode.US));
            Assert.IsTrue(shortUtil.ConnectsToEmergencyNumber("119", RegionCode.US));
            Assert.IsFalse(shortUtil.ConnectsToEmergencyNumber("999", RegionCode.US));
        }

        [TestMethod]
        public void testConnectsToEmergencyNumberLongNumber_US()
        {
            Assert.IsTrue(shortUtil.ConnectsToEmergencyNumber("9116666666", RegionCode.US));
            Assert.IsTrue(shortUtil.ConnectsToEmergencyNumber("1196666666", RegionCode.US));
            Assert.IsFalse(shortUtil.ConnectsToEmergencyNumber("9996666666", RegionCode.US));
        }

        [TestMethod]
        public void testConnectsToEmergencyNumberWithFormatting_US()
        {
            Assert.IsTrue(shortUtil.ConnectsToEmergencyNumber("9-1-1", RegionCode.US));
            Assert.IsTrue(shortUtil.ConnectsToEmergencyNumber("1-1-9", RegionCode.US));
            Assert.IsFalse(shortUtil.ConnectsToEmergencyNumber("9-9-9", RegionCode.US));
        }

        [TestMethod]
        public void testConnectsToEmergencyNumberWithPlusSign_US()
        {
            Assert.IsFalse(shortUtil.ConnectsToEmergencyNumber("+911", RegionCode.US));
            Assert.IsFalse(shortUtil.ConnectsToEmergencyNumber("\uFF0B911", RegionCode.US));
            Assert.IsFalse(shortUtil.ConnectsToEmergencyNumber(" +911", RegionCode.US));
            Assert.IsFalse(shortUtil.ConnectsToEmergencyNumber("+119", RegionCode.US));
            Assert.IsFalse(shortUtil.ConnectsToEmergencyNumber("+999", RegionCode.US));
        }

        [TestMethod]
        public void testConnectsToEmergencyNumber_BR()
        {
            Assert.IsTrue(shortUtil.ConnectsToEmergencyNumber("911", RegionCode.BR));
            Assert.IsTrue(shortUtil.ConnectsToEmergencyNumber("190", RegionCode.BR));
            Assert.IsFalse(shortUtil.ConnectsToEmergencyNumber("999", RegionCode.BR));
        }

        [TestMethod]
        public void testConnectsToEmergencyNumberLongNumber_BR()
        {
            // Brazilian emergency numbers don't work when additional digits are appended.
            Assert.IsFalse(shortUtil.ConnectsToEmergencyNumber("9111", RegionCode.BR));
            Assert.IsFalse(shortUtil.ConnectsToEmergencyNumber("1900", RegionCode.BR));
            Assert.IsFalse(shortUtil.ConnectsToEmergencyNumber("9996", RegionCode.BR));
        }

        [TestMethod]
        public void testConnectsToEmergencyNumber_AO()
        {
            // Angola doesn't have any metadata for emergency numbers in the test metadata.
            Assert.IsFalse(shortUtil.ConnectsToEmergencyNumber("911", RegionCode.AO));
            Assert.IsFalse(shortUtil.ConnectsToEmergencyNumber("222123456", RegionCode.AO));
            Assert.IsFalse(shortUtil.ConnectsToEmergencyNumber("923123456", RegionCode.AO));
        }

        [TestMethod]
        public void testConnectsToEmergencyNumber_ZW()
        {
            // Zimbabwe doesn't have any metadata in the test metadata.
            Assert.IsFalse(shortUtil.ConnectsToEmergencyNumber("911", RegionCode.ZW));
            Assert.IsFalse(shortUtil.ConnectsToEmergencyNumber("01312345", RegionCode.ZW));
            Assert.IsFalse(shortUtil.ConnectsToEmergencyNumber("0711234567", RegionCode.ZW));
        }

        [TestMethod]
        public void testIsEmergencyNumber_US()
        {
            Assert.IsTrue(shortUtil.IsEmergencyNumber("911", RegionCode.US));
            Assert.IsTrue(shortUtil.IsEmergencyNumber("119", RegionCode.US));
            Assert.IsFalse(shortUtil.IsEmergencyNumber("999", RegionCode.US));
        }

        [TestMethod]
        public void testIsEmergencyNumberLongNumber_US()
        {
            Assert.IsFalse(shortUtil.IsEmergencyNumber("9116666666", RegionCode.US));
            Assert.IsFalse(shortUtil.IsEmergencyNumber("1196666666", RegionCode.US));
            Assert.IsFalse(shortUtil.IsEmergencyNumber("9996666666", RegionCode.US));
        }

        [TestMethod]
        public void testIsEmergencyNumberWithFormatting_US()
        {
            Assert.IsTrue(shortUtil.IsEmergencyNumber("9-1-1", RegionCode.US));
            Assert.IsTrue(shortUtil.IsEmergencyNumber("*911", RegionCode.US));
            Assert.IsTrue(shortUtil.IsEmergencyNumber("1-1-9", RegionCode.US));
            Assert.IsTrue(shortUtil.IsEmergencyNumber("*119", RegionCode.US));
            Assert.IsFalse(shortUtil.IsEmergencyNumber("9-9-9", RegionCode.US));
            Assert.IsFalse(shortUtil.IsEmergencyNumber("*999", RegionCode.US));
        }

        [TestMethod]
        public void testIsEmergencyNumberWithPlusSign_US()
        {
            Assert.IsFalse(shortUtil.IsEmergencyNumber("+911", RegionCode.US));
            Assert.IsFalse(shortUtil.IsEmergencyNumber("\uFF0B911", RegionCode.US));
            Assert.IsFalse(shortUtil.IsEmergencyNumber(" +911", RegionCode.US));
            Assert.IsFalse(shortUtil.IsEmergencyNumber("+119", RegionCode.US));
            Assert.IsFalse(shortUtil.IsEmergencyNumber("+999", RegionCode.US));
        }

        [TestMethod]
        public void testIsEmergencyNumber_BR()
        {
            Assert.IsTrue(shortUtil.IsEmergencyNumber("911", RegionCode.BR));
            Assert.IsTrue(shortUtil.IsEmergencyNumber("190", RegionCode.BR));
            Assert.IsFalse(shortUtil.IsEmergencyNumber("999", RegionCode.BR));
        }

        [TestMethod]
        public void testIsEmergencyNumberLongNumber_BR()
        {
            Assert.IsFalse(shortUtil.IsEmergencyNumber("9111", RegionCode.BR));
            Assert.IsFalse(shortUtil.IsEmergencyNumber("1900", RegionCode.BR));
            Assert.IsFalse(shortUtil.IsEmergencyNumber("9996", RegionCode.BR));
        }

        [TestMethod]
        public void testIsEmergencyNumber_AO()
        {
            // Angola doesn't have any metadata for emergency numbers in the test metadata.
            Assert.IsFalse(shortUtil.IsEmergencyNumber("911", RegionCode.AO));
            Assert.IsFalse(shortUtil.IsEmergencyNumber("222123456", RegionCode.AO));
            Assert.IsFalse(shortUtil.IsEmergencyNumber("923123456", RegionCode.AO));
        }

        [TestMethod]
        public void testIsEmergencyNumber_ZW()
        {
            // Zimbabwe doesn't have any metadata in the test metadata.
            Assert.IsFalse(shortUtil.IsEmergencyNumber("911", RegionCode.ZW));
            Assert.IsFalse(shortUtil.IsEmergencyNumber("01312345", RegionCode.ZW));
            Assert.IsFalse(shortUtil.IsEmergencyNumber("0711234567", RegionCode.ZW));
        }
    }
}
