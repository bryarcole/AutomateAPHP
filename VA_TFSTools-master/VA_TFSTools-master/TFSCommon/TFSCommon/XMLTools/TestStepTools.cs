using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Xml;
using TFSCommon.Data;

namespace TFSCommon.XMLTools
{
    public class TestStepTools
    {
        public string CreateTestStepXML(ICollection<TestStep> testSteps)
        {
            string res = "<steps id=\"0\" last=\"" + (testSteps.Count + 1) + "\">";
            int currStep = 2;
            foreach (var step in testSteps)
            {
                string stepStart = "<step id=\"" + currStep + "\" type=\"ValidateStep\">";
                string stepEnd = "</step>";
                string parameterizedStart = "<parameterizedString isformatted=\"true\">";
                string parameterizedEnd = "</parameterizedString>";
                string description = "<description/>";
                string testAction = step.Action;
                string testExpected = step.Expected;

                string encodedAction = HtmlEncoder.Default.Encode(testAction);
                string encodedExpected = HtmlEncoder.Default.Encode(testExpected);

                currStep++;

                res += stepStart + parameterizedStart + encodedAction + parameterizedEnd + parameterizedStart + encodedExpected + parameterizedEnd + description + stepEnd;
            }
            string stepsEnd = "</steps>";
            res += stepsEnd;
            res = res.Replace("\n", Environment.NewLine);

            //res = HtmlEncoder.Default.Encode(res);
            //System.Diagnostics.Debug.WriteLine(res);
            return res;
        }

        public List<TestStep> ExtractTestSteps(int testCaseId, string encodedTestStep)
        {
            List<TestStep> res = new List<TestStep>();

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(encodedTestStep);

            XmlNodeList testStepList = xml.GetElementsByTagName("step");

            foreach (XmlNode currStep in testStepList)
            {
                TestStep currTestStep = new TestStep();
                currTestStep.StepNumber = (Convert.ToInt32(currStep.Attributes["id"].Value) - 1);
                currTestStep.TestCaseId = testCaseId;
                currTestStep.Action = currStep.SelectNodes("parameterizedString")[0].InnerText;
                currTestStep.Expected = currStep.SelectNodes("parameterizedString")[1].InnerText;

                res.Add(currTestStep);
            }

            return res;
        }
    }
}
