/*
 * Copyright (C) 2012 The Libphonenumber Authors
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
    * Some basic tests to check that the phone number metadata can be correctly loaded.
    *
    * @author Lara Rennie
    */
    [TestClass]
    public class TestMedataManager
    {
        [TestMethod]
        public void TestAlternateFormatsContainsData()
        {
            // We should have some data for Germany.
            var germanyAlternateFormats = MetadataManager.GetAlternateFormatsForCountry(49);
            Assert.IsNotNull(germanyAlternateFormats);
            Assert.IsTrue(germanyAlternateFormats.NumberFormatList.Count > 0);
        }

        [TestMethod]
        public void TestAlternateFormatsFailsGracefully()
        {
            var noAlternateFormats = MetadataManager.GetAlternateFormatsForCountry(999);
             Assert.IsNull(noAlternateFormats);
        }
    }
}
