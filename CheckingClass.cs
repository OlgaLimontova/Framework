using NUnit.Framework;
using System.Collections.Generic;
using System.Configuration;

namespace SiteChecker
{
    public class CheckingClass
    {
        ExcelDataHandler handler;

        public CheckingClass()
        {
            handler = new ExcelDataHandler();
            handler.SetData();
        }
        
        void TestBasePageLogin(Page page)
        {
            page.NavigateHere(ConfigurationManager.AppSettings["StartURL"]);
            page.BaseLogin(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
        }

        void TestAllJournals(Page page, string startSubstring)
        {
            Dictionary<string, List<KeyValuePair<string, List<string>>>> mainData = handler.GetMainData();
            foreach (string journalName in mainData.Keys)
            {
                if (journalName.StartsWith(startSubstring))
                    TestJournal(page, journalName);
            }
        }

        [Timeout(10000)]
        void TestNavigateToJournal(Page page, string journalName)
        {
            page.NavigateToJournal(journalName);
        }

        [Timeout(10000)]
        void TestJournalPageLogin(Page page)
        {
            page.JournalPageLogin(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            if (page.GetLoginName().Text.Trim().Equals(""))
                Assert.IsNotNull(page.GetLoginName().Text.Trim());
            else
                page.GetLoginName().Click();
        }

        void TestJournalPageLogout(Page page)
        {
            page.JournalPageLogout();
        }

        void TestCheckCategoryPoints(Page page, KeyValuePair<string, List<string>> mainCategoryKeyValue)
        {
            foreach (string categoryPoint in mainCategoryKeyValue.Value)
                Assert.IsNotNull(page.GetDropdownToggleCategory(categoryPoint).Text);
        }

        [Timeout(10000)]
        void TestCheckMainCategories(Page page, string journalName)
        {
            foreach (KeyValuePair<string, List<string>> categoryDictionary in handler.GetMainCategories(journalName))
            {
                Assert.IsNotNull(page.GetDropdownToggle(categoryDictionary.Key).Text);
                page.CheckMainCategories(categoryDictionary.Key);
                TestCheckCategoryPoints(page, categoryDictionary);
            }
        }

        [Timeout(10000)]
        void TestSearch(Page page, string stringForSearching)
        {
            page.SearchString(stringForSearching);
        }

        [Timeout(10000)]
        void TestCheckTestCasesCategories(Page page, string journalName)
        {
            page.AdvancedSearchLink.Click(); // New
            foreach (KeyValuePair<string, List<string>> categoryDictionary in handler.GetTestCasesCategories(journalName))
            {
                Assert.IsTrue(page.GetSelectToggle(categoryDictionary.Key).Enabled);
                page.CheckTestCasesCategories(categoryDictionary/*.Key*/);
                page.AdvancedSearchInOtherJournals(journalName); // New
//                TestCheckCategoryPoints(page, categoryDictionary);
            }
            page.AdvancedSearchButton.Click(); // New
            Assert.IsTrue(page.SaveSearchButton.Displayed); // New
        }

        void TestJournal(Page page, string journalName)
        {
//            if (journalName.StartsWith("mc"))
//            {
                TestNavigateToJournal(page, journalName);
                TestJournalPageLogin(page);
                TestCheckMainCategories(page, journalName);
                TestSearch(page, "melanoma");
                TestCheckTestCasesCategories(page, journalName);
                TestJournalPageLogout(page);
//            }
        }

        [TestCaseSource("testCasesData")]
        public void StartTests(Page page, string startString)
        {
            TestAllJournals(page, startString);
        }


/*
        void TestAdvancedSearchByString(Page page, string stringForSearching)
        {
            page.AdvancedSearchByString(stringForSearching);
        }

        void TestAdvancedSearchByTitle(Page page, string titleForSearching)
        {
            page.AdvancedSearchByTitle(titleForSearching);
        }

        void TestAdvanceSearchInOtherJournals(Page page, string journalName, List<string> journalsNames)
        {
            if (journalName.Equals("Anesthesia & Analgesia") || journalName.Equals("A&A Case Reports") ||
                journalName.Equals("Plastic and Reconstructive Surgery") || journalName.Equals("Plastic and Reconstructive Surgery – Global Open"))
            {
                page.AdvancedSearchInOtherJournals(journalsNames);
            }
        }

        void TestAdvancedSearch(Page page, string journalName)
        {
            page.AdvancedSearchLink.Click();
            page.AdvancedSearchByKeywords();
            page.AdvancedSearchWithContentTypes();
            page.AdvancedSearchByPublicationDates("All Dates");
            List<string> journalsNames = new List<string>();
            journalsNames.Add("A&A Case Reports");
            TestAdvanceSearchInOtherJournals(page, journalName, journalsNames);
            page.AdvancedSearchButton.Click();
            Assert.IsTrue(page.SaveSearchButton.Displayed);
        }

        void TestJournal(Page page, string journalName)
        {
            TestNavigateToJournal(page, journalName);
            TestJournalPageLogin(page);
            TestCheckMainCategories(page, journalName);
            TestSearch(page, "melanoma");
            TestAdvancedSearch(page, journalName);
            TestJournalPageLogout(page);
        }

        public void StartTests(Page page)
        {
//            TestBasePageLogin(page);
            TestAllJournals(page);
        }
*/
    }
}