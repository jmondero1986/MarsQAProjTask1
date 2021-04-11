using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace MarsQA_1.Feature
{
    [Binding]
    public class ProfileSteps
    {

        [Given(@"I input text in the description box")]
        public void GivenIInputTextInTheDescriptionBox()
        {

            //Write Icon button and enables it
            IWebElement writeIconElement = Driver.driver.FindElement(By.CssSelector("h3[class='ui dividing header'] i[class='outline write icon']"));
            writeIconElement.Click();


            //Adding Description information/data in the description box
            IWebElement descriptionTxtbox = Driver.driver.FindElement(By.TagName("textarea"));
            descriptionTxtbox.Clear();
            descriptionTxtbox.SendKeys("Seller can add description here!Testing ongoing....");

        }

        [Given(@"I click the save button")]
        public void GivenIClickTheSaveButton()
        {
            //Enable the Save button
            IWebElement saveButton = Driver.driver.FindElement(By.XPath("//button[@type='button']"));
            saveButton.Click();

        }

        [Then(@"I will be able to see the description information")]
        public void ThenIWillBeAbleToSeeTheDescriptionInformation()
        {
            //Assertion for the Description information are the same as what we inputted 
            //Actual Description information (input) = Expected Description information (output)
            var actualDescription = Driver.driver.FindElement(By.XPath("//textarea[@placeholder='Please tell us about any hobbies, additional expertise, or anything else you’d like to add.']")).Text;
            var expectedDescription = "Seller can add description here!Testing ongoing....";
                                
            Assert.AreEqual(expectedDescription, actualDescription);
            Thread.Sleep(1000);

        }

        [Given(@"I am logged in at profile page")]
        public void GivenIAmLoggedInAtProfilePage()
        {
            //Verify HomePage/ProfilePage by looking for the Sign out button
            var signOutButtonElement = Driver.driver.FindElement(By.XPath("//button[normalize-space()='Sign Out']"));
            Assert.IsNotNull(signOutButtonElement);
            Thread.Sleep(1000);
        }

        [When(@"I click language tabs")]
        public void WhenIClickLanguageTabs()
        {
            //Identify the Language Tab
            IWebElement LanguageTab = Driver.driver.FindElement(By.XPath("//a[normalize-space()='Languages']"));
            LanguageTab.Click();
            Thread.Sleep(1000);
        }
        
        [Then(@"I should see languages label")]
        public void ThenIShouldSeeLanguagesLabel()
        {
            //Identifying/looking for the Language Text if existing
            var actualText = Driver.driver.FindElement(By.XPath("//h3[normalize-space()='Languages']")).Text;
            var expectedText = "Languages";

            Assert.AreEqual(expectedText, actualText);
            Thread.Sleep(1000);

        }

        [Then(@"a list of languages seller can speak")]
        public void ThenAListOfLanguagesSellerCanSpeak()
        {
            //Identifying/looking for the "How many languages do you speak?" if existing
            var actualText = Driver.driver.FindElement(By.XPath("//div[normalize-space()='How many languages do you speak?']")).Text;
            var expectedText = "How many languages do you speak?";

            Assert.AreEqual(expectedText, actualText);
            Thread.Sleep(1000);
        }
        
        [Then(@"an instruction of maximum of selections")]
        public void ThenAnInstructionOfMaximumOfSelections()
        {
            //Identifying/looking for "You can do up to a maximum of four selections" if existing
            var actualText = Driver.driver.FindElement(By.XPath("//div[normalize-space()='You can do up to a maximum of four selections']")).Text;
            var expectedText = "You can do up to a maximum of four selections";

            Assert.AreEqual(expectedText, actualText);
            Thread.Sleep(1000);
        }
        
        [Then(@"I should see the languages list")]
        public void ThenIShouldSeeLanguagesList()
        {
            //Identifying if the Language List is existing
            var elementLanguageList = Driver.driver.FindElement(By.ClassName("form-wrapper"));

            Assert.IsNotNull(elementLanguageList);
            Thread.Sleep(1000);
        }

        [Given(@"I am at the language page")]
        public void GivenIAmAtTheLanguagePage()
        {

            //Verify HomePage/ProfilePage by looking for the Sign out button
            var signOutButtonElement = Driver.driver.FindElement(By.XPath("//button[normalize-space()='Sign Out']"));
            Assert.IsNotNull(signOutButtonElement);
            Thread.Sleep(1000);
        }

        [When(@"I add language")]
        public void WhenIAddLanguage()
        {
            //Reading the data from my C: file
            ExcelLibHelper.PopulateInCollection(@"C:\MARS QA\MARSQAProj\onboarding.specflow\MarsQA-1\SpecflowTests\Data\Data.xlsx", "Language");
            
            //Identify the Add new button
            IWebElement AddNewButton = Driver.driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment active tooltip-target']//div[contains(@class,'ui teal button')][normalize-space()='Add New']"));
            AddNewButton.Click();
            Thread.Sleep(1000);

            //Reading the Language Data from excel File
            IWebElement elementAddLanguageTxtBox = Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
            var expectedLanguage = ExcelLibHelper.ReadData(6, "Language");
            elementAddLanguageTxtBox.SendKeys(expectedLanguage);
            Thread.Sleep(1000);

            //Identify/Choosing from the drop down language level
            IWebElement elementChooseLanguageLevelDropdown = Driver.driver.FindElement(By.Name("level"));
            SelectElement  dropdownList= new SelectElement(elementChooseLanguageLevelDropdown);
            dropdownList.SelectByText("Fluent");
            Thread.Sleep(1000);

            //Identify Add button
            IWebElement elementAddButton = Driver.driver.FindElement(By.XPath("//input[@value='Add']"));
            elementAddButton.Click();
            Thread.Sleep(1000);
            
        }

        [Then(@"I see the added language in the grid")]
        public void ThenISeeTheAddedLanguageInTheGrid()
        {

           //Identify and reading file from the excel file
            string expectedLanguage = ExcelLibHelper.ReadData(6, "Language");
            IWebElement languageElement = Driver.driver.FindElement(By.XPath($"//td[normalize-space()='{expectedLanguage}']"));

            var actualLanguage = languageElement.Text;


            //Verifying that actual language should be same as the expected language you see on the grid
            Assert.AreEqual(actualLanguage, expectedLanguage);
            Thread.Sleep(1000);
            

        }
        [Then(@"I update the language")]
        public void ThenIUpdateTheLanguage()
        {
            //Identify the update element
            IWebElement updateElement = Driver.driver.FindElement(By.XPath("//td[@class='right aligned']//i[@class='outline write icon']"));
            updateElement.Click();

            //Identify the language textbox
            //And clearing the fields once you update to new language
            IWebElement elementlanguageTxtbox = Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
            elementlanguageTxtbox.Click();
            elementlanguageTxtbox.Clear();


            //Reading the file from excel file
            string expectedLanguage = ExcelLibHelper.ReadData(3, "Language");
            elementlanguageTxtbox.SendKeys(expectedLanguage);

            //Identify/Choosing from the drop down language level
            IWebElement chooseLanguageLevelDropdown = Driver.driver.FindElement(By.Name("level"));
            SelectElement dropdownList = new SelectElement(chooseLanguageLevelDropdown);
            dropdownList.SelectByText("Conversational");


            //Verify Update Button
            IWebElement updateButton = Driver.driver.FindElement(By.XPath("//input[@value='Update']"));
            updateButton.Click();
            Thread.Sleep(1000);

          
        }

        [Then(@"I will see the updated language")]
        public void ThenIWillSeeTheUpdatedLanguage()
        {
            //Reading the data from the excel file
            string expectedLanguage = ExcelLibHelper.ReadData(3, "Language");
            IWebElement languageElement = Driver.driver.FindElement(By.XPath($"//td[normalize-space()='{expectedLanguage}']"));

            var actualUpdatedLanguage = languageElement.Text;


            //Verifying that expected language is same as the actual updated language
            Assert.AreEqual(actualUpdatedLanguage, expectedLanguage);
            Thread.Sleep(1000);

        }

        [When(@"I delete the added language")]
        public void WhenIDeleteTheAddedLanguage()
        {
            //Identify the delete or remove icon
            Driver.driver.FindElement(By.CssSelector("body > div:nth-child(1) > div:nth-child(1) > section:nth-child(3) > div:nth-child(1) >" +
                " div:nth-child(1) > div:nth-child(1) > div:nth-child(3) > form:nth-child(2) > div:nth-child(2) > div:nth-child(1) > " +
                "div:nth-child(2) > div:nth-child(1) > table:nth-child(1) > tbody:nth-child(2) > tr:nth-child(1) > td:nth-child(3) > span:nth-child(2)")).Click();
            Thread.Sleep(1000);

        }

        [Then(@"I should not see the added language")]
        public void ThenIShouldNotSeeTheAddedLanguage()
        {
            //Reading the data from the excel file
            var expectedLanguage = ExcelLibHelper.ReadData(6, "Language");
            var myPath = By.XPath($"//td[normalize-space()='{expectedLanguage}']");

            //Verifying that the deleted language won't show in the grid
          
            var isElementExist = true;
            try
            {
                Driver.driver.FindElement(myPath);
            }
            catch (NoSuchElementException)
            {
                isElementExist = false;
            }

            Assert.IsFalse(isElementExist);
           
            Thread.Sleep(1000);

        }

       
    }
}
