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

package org.xmlunit.userguide_examples.diff;

import org.junit.Assert;
import org.junit.Test;
import org.xmlunit.builder.DiffBuilder;
import org.xmlunit.diff.Diff;

public class BigDecimalElementDifferenceEvaluatorTest {

    @Test
    public void testUserguideExample() throws Exception {
        final String control = "<a><amount>1</amount></a>";
        final String test = "<a><amount>1.0000</amount></a>";

        Diff myDiff = DiffBuilder.compare(control).withTest(test)
            .withDifferenceEvaluator(new BigDecimalElementDifferenceEvaluator("amount"))
            .checkForSimilar()
            .build();

        Assert.assertFalse(myDiff.toString(), myDiff.hasDifferences());
    }
}
