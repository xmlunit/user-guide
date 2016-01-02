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
using System.Xml;
using Org.XmlUnit.Diff;

namespace Org.XmlUnit.UserguideExamples {

    public class IgnoreAttributeDifferenceEvaluator {
        private string attributeName;

        public IgnoreAttributeDifferenceEvaluator(string attributeName) {
            this.attributeName = attributeName;
        }

        public ComparisonResult Evaluate(Comparison comparison, ComparisonResult outcome) {
            if (outcome == ComparisonResult.EQUAL) return outcome; // only evaluate differences.
            XmlNode controlNode = comparison.ControlDetails.Target;
            XmlAttribute attr = controlNode as XmlAttribute;
            if (attr != null) {
                if (attr.Name == attributeName) {
                    return ComparisonResult.SIMILAR; // will evaluate this difference as similar
                }
            }
            return outcome;
        }
    }
}
