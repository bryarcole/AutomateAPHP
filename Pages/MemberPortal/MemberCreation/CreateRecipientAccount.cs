using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Tests1.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace NUnit.Tests1.Pages.MemberPortal.MemberCreation
{
    class CreateRecipientAccount
    {

        IWebDriver context;
        public CreateRecipientAccount(IWebDriver context)
        {
            this.context = context;
            PageFactory.InitElements(context, this);
        }

        private Generic Generic
        {
            get
            {
                Generic generic = new Generic(context);
                return generic;
            }
        }

        public string url = "https://10.3.29.100:44304/public/CreateRecipientAccount.aspx";

        [FindsBy(How = How.XPath, Using = "//*[@id=\"Head1\"]/title")]
        private IWebElement PageTitle { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'FirstName')]")]
        private IWebElement FirstName { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'MiddleName')]")]
        private IWebElement MiddleName { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'LastName')]")]
        private IWebElement LastName { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'PhoneNumber_wrapper')]")]
        private IWebElement PhoneNumber_wrapper { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'PhoneNumber')]")]
        private IWebElement PhoneNumber { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'RecipientId')]")]
        private IWebElement RecipientId { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'EmailAddress')]")]
        private IWebElement EmailAddress { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'ConfirmEmailAddress')]")]
        private IWebElement ConfirmEmailAddress { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'CorrespondenceType_0')]")]
        private IWebElement CorrespondenceType_0 { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'CorrespondenceType_1')]")]
        private IWebElement CorrespondenceType_1 { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'PINNumber_wrapper')]")]
        private IWebElement PINNumber_wrapper { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'PINNumber')]")]
        private IWebElement PINNumber { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'PINNumber')]")]
        private IWebElement PINNumberRadioButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'DateofBirth_wrapper')]")]
        private IWebElement DateofBirth_wrapper { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'DateofBirth')]")]
        private IWebElement DateofBirth { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'rbtnMail')]")]
        private IWebElement rbtnMail { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'rbtnEmail')]")]
        private IWebElement rbtnEmail { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'rbtnSMS')]")]
        private IWebElement rbtnSMS { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[contains(@for, 'chkTermsAndConditions')]")]
        private IWebElement chkTermsAndConditions { get; set; }

        public IWebElement InputFirstName(string text = null) => Generic.SendKeys(FirstName, text);
        public IWebElement InputMiddleName(string text = null) => Generic.SendKeys(MiddleName, text);
        public IWebElement InputLastName(string text = null) => Generic.SendKeys(LastName, text);
        public IWebElement InputPhoneNumber(string text = null) => Generic.SendKeys(PhoneNumber, PhoneNumber_wrapper, text);
        public IWebElement InputRecipientID(string text = null) => Generic.SendKeys(RecipientId, text);
        public IWebElement InputEmailAddress(string text = null) => Generic.SendKeys(EmailAddress, text);
        public IWebElement InputConfirmEmailAddress(string text = null) => Generic.SendKeys(ConfirmEmailAddress, text);
        public IWebElement ClickCorrespondenceType_0() => Generic.Click(CorrespondenceType_0);
        public IWebElement ClickCorrespondenceType_1() => Generic.Click(CorrespondenceType_1);
        public IWebElement InputPinNumber(string text = null) => Generic.SendKeys(PINNumber, PINNumber_wrapper, text);
        public IWebElement InputDOB(string text = null) => Generic.SendKeys(DateofBirth, DateofBirth_wrapper, text);
        public IWebElement ClickMailRadioButton() => Generic.Click(rbtnMail);
        public IWebElement ClickEmailRadioButton() => Generic.Click(rbtnEmail);
        public IWebElement ClickSMSRadioButton() => Generic.Click(rbtnSMS);
        public IWebElement ClickAgreeTermsAndCOnditions() => Generic.Click(chkTermsAndConditions);
        public IWebElement EmailCorrespondenceDecisionCLick(string yesno = null) => Generic.DecisionClick(CorrespondenceType_0, CorrespondenceType_1, yesno);    
        public bool CheckTitle() => Generic.IsVisible(PageTitle);
        public IWebElement ClickPinNumberRadioButton() => Generic.Click(PINNumberRadioButton);

        public void InputReciepientAccountInfo(
            string firstName = null,
            string middleInitial = null,
            string lastName = null,
            string phoneNumber = null,
            string reciepientID = null, 
            string emailAddress = null,
            string confirmEmailAddresss = null,
            string correspondenceType = null, 
            string inputPinNumber = null,
            string inputDOB = null,
            string requestPinBy = null
            )
        {
            if (CheckTitle())
            {
                InputFirstName(firstName);
                InputMiddleName(middleInitial);
                InputLastName(lastName);
                InputDOB(inputDOB);
                InputRecipientID(reciepientID);
                InputPhoneNumber(phoneNumber);
                InputEmailAddress(emailAddress);
                if(confirmEmailAddresss == null)
                {
                    InputConfirmEmailAddress(emailAddress);
                }
                else
                {
                    InputConfirmEmailAddress(confirmEmailAddresss);
                }
                EmailCorrespondenceDecisionCLick(correspondenceType);
                switch (requestPinBy)
                {
                    case "mail":
                        ClickMailRadioButton();
                        break;
                    case "email":
                        ClickEmailRadioButton();
                        break;
                    case "SMS":
                        ClickSMSRadioButton();
                        break;
                }
                if(inputPinNumber == null){

                }
                else
                {
                    ClickPinNumberRadioButton();
                    InputPinNumber(inputPinNumber);
                }
            }
            else
            {
                Console.WriteLine("Error occured on page load");
            }
        }
    }
}
