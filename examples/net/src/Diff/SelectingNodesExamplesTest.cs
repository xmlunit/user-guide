/*
  This file is licensed to You under the Apache License, Version 2.0
  (the "License"); you may not use this file except in compliance with
  the License.  You may obtain a copy of the License at

  http://www.apache.org/licenses/LICENSE-2.0

  Unless required by applicable law or agreed to in writing, software
  distributed under the License is distributed on an "AS IS" BASIS,
  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
  See the License for the specific language governing permissions and
  limitations under the License.
*/

using System;
using NUnit.Framework;
using Org.XmlUnit.Builder;
using Org.XmlUnit.Diff;

namespace Org.XmlUnit.UserguideExamples {

    [TestFixture]
    public class SelectingNodesExamplesTest {
        private const string CONTROL = "<table>"
            + "  <tbody>"
            + "    <tr>"
            + "      <th>some key</th>"
            + "      <td>some value</td>"
            + "    </tr>"
            + "    <tr>"
            + "      <th>another key</th>"
            + "      <td>another value</td>"
            + "    </tr>"
            + "  </tbody>"
            + "</table>";
        private const String TEST = "<table>"
            + "  <tbody>"
            + "    <tr>"
            + "      <th>another key</th>"
            + "      <td>another value</td>"
            + "    </tr>"
            + "    <tr>"
            + "      <th>some key</th>"
            + "      <td>some value</td>"
            + "    </tr>"
            + "  </tbody>"
            + "</table>";

        [Test]
        public void ConditionalWithXPath() {
            ElementSelector es = ElementSelectors.ConditionalBuilder()
                .WhenElementIsNamed("tr")
                .ThenUse(ElementSelectors.ByXPath("./th", ElementSelectors.ByNameAndText))
                .ElseUse(ElementSelectors.ByName)
                .Build();

            var myDiff = DiffBuilder.Compare(CONTROL).WithTest(TEST)
                .WithNodeMatcher(new DefaultNodeMatcher(es))
                .CheckForSimilar()
                .Build();

            Assert.IsFalse(myDiff.HasDifferences(), myDiff.ToString());
        }

        [Test]
        public void conditionalWithByNameAndTextRec() {
            ElementSelector es =  ElementSelectors.ConditionalBuilder()
                .WhenElementIsNamed("tr").ThenUse(ByNameAndTextRecSelector.CanBeCompared)
                .ElseUse(ElementSelectors.ByName)
                .Build();

            var myDiff = DiffBuilder.Compare(CONTROL).WithTest(TEST)
                .WithNodeMatcher(new DefaultNodeMatcher(es))
                .CheckForSimilar()
                .Build();

            Assert.IsFalse(myDiff.HasDifferences(), myDiff.ToString());
        }
    }
}
