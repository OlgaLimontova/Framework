using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace SiteChecker
{
    public class Page
    {
        List<string> specialJournals; // New

        public Page()
        {
            specialJournals = new List<string>(); // New
            specialJournals.Add("A&A Case Reports"); // New
            specialJournals.Add("Anesthesia & Analgesia"); // New
            specialJournals.Add("Plastic and Reconstructive Surgery – Global Open"); // New
            specialJournals.Add("Plastic and Reconstructive Surgery"); // New
        }

        #region Login elements
        IWebElement LoginInput => WebDriver.Driver.FindElement(By.XPath("//*[contains(@id, 'txt_UserName')]"));
        IWebElement PasswordInput => WebDriver.Driver.FindElement(By.XPath("//*[contains(@id, 'txt_Password')]"));
        IWebElement LoginButton => WebDriver.Driver.FindElement(By.XPath("//*[contains(@id, 'LoginButton')]"));
        public IWebElement GetLoginName() => WebDriver.Driver.FindElement(By.XPath("//*[contains(@id, 'ucUserActionsToolbar_lblAccount')]")); // New
        #endregion

        #region Search elements
        IWebElement SearchBox => WebDriver.Driver.FindElement(By.XPath("//*[contains(@id, 'txtKeywords')]"));

        public IWebElement AdvancedSearchLink => WebDriver.Driver.FindElement(By.XPath("//*[contains(@id, 'lnkAdvanceSearch')]"));

        IWebElement AdvancedSearchInputAllFields => WebDriver.Driver.FindElement(By.XPath("//INPUT[@id='keywords_input_1']"));
        IWebElement AdvancedSearchInputTitle => WebDriver.Driver.FindElement(By.XPath("//INPUT[@id='keywords_input_2']"));
        IWebElement AdvancedSearchInputAuthor => WebDriver.Driver.FindElement(By.XPath("//INPUT[@id='keywords_input_3']"));
        IWebElement AdvancedSearchInputAbstract => WebDriver.Driver.FindElement(By.XPath("//INPUT[@id='keywords_input_4']"));
        IWebElement AdvancedSearchInputFullText => WebDriver.Driver.FindElement(By.XPath("//INPUT[@id='keywords_input_5']"));
        IWebElement AdvancedSearchInputVolume => WebDriver.Driver.FindElement(By.XPath("//INPUT[@id='keywords_input_6']"));
        IWebElement AdvancedSearchInputIssue => WebDriver.Driver.FindElement(By.XPath("//INPUT[@id='keywords_input_7']"));

        IWebElement AdvancedSearchCheckboxArticles => WebDriver.Driver.FindElement(By.XPath("//*[contains(@id, 'filterListArticle')]"));
        IWebElement AdvancedSearchCheckboxImages => WebDriver.Driver.FindElement(By.XPath("//*[contains(@id, 'filterListImage')]"));
        IWebElement AdvancedSearchCheckboxPodcasts => WebDriver.Driver.FindElement(By.XPath("//*[contains(@id, 'filterListPodcast')]"));
        IWebElement AdvancedSearchCheckboxVideos => WebDriver.Driver.FindElement(By.XPath("//*[contains(@id, 'filterListVideo')]"));
        IWebElement AdvancedSearchCheckboxBlogs => WebDriver.Driver.FindElement(By.XPath("//*[contains(@id, 'filterListBlog')]"));
        IWebElement AdvancedSearchCheckboxCME => WebDriver.Driver.FindElement(By.XPath("//*[contains(@id, 'filterListCME')]"));
        IWebElement AdvancedSearchCheckboxSDC => WebDriver.Driver.FindElement(By.XPath("//*[contains(@id, 'filterListSDC')]"));

        IWebElement AdvancedSearchRadiobuttonAllDates => WebDriver.Driver.FindElement(By.XPath("//*[contains(@id, 'searchDatesRadioButtonList_0')]"));
        IWebElement AdvancedSearchRadiobuttonCurrentIssue => WebDriver.Driver.FindElement(By.XPath("//*[contains(@id, 'searchDatesRadioButtonList_1')]"));
        IWebElement AdvancedSearchRadiobuttonLast12Months => WebDriver.Driver.FindElement(By.XPath("//*[contains(@id, 'searchDatesRadioButtonList_2')]"));
        IWebElement AdvancedSearchRadiobuttonLast3Years => WebDriver.Driver.FindElement(By.XPath("//*[contains(@id, 'searchDatesRadioButtonList_3')]"));
        IWebElement AdvancedSearchRadiobuttonLast5Years => WebDriver.Driver.FindElement(By.XPath("//*[contains(@id, 'searchDatesRadioButtonList_4')]"));
        IWebElement AdvancedSearchRadiobuttonLast8Years => WebDriver.Driver.FindElement(By.XPath("//*[contains(@id, 'searchDatesRadioButtonList_5')]"));

        IWebElement AdvancedSearchCheckboxJournal1 => WebDriver.Driver.FindElement(By.XPath("//*[contains(@id, 'filterListPRS')]"));
        IWebElement AdvancedSearchCheckboxJournal2 => WebDriver.Driver.FindElement(By.XPath("//*[contains(@id, 'filterListRevista')]"));

        public IWebElement AdvancedSearchButton => WebDriver.Driver.FindElement(By.XPath("//*[contains(@id, 'searchAgain')]"));
        public IWebElement SaveSearchButton => WebDriver.Driver.FindElement(By.XPath("(//INPUT[@class='primary-button'])[3]"));
        #endregion

        #region Login-Logout links
        IWebElement LoginLink => WebDriver.Driver.FindElement(By.XPath("//*[contains(@id, 'ucUserActionsToolbar_lnkLogin')]"));
        IWebElement LogoutLink => WebDriver.Driver.FindElement(By.XPath("//*[contains(@id, 'ucUserActionsToolbar_lnkLogout')]"));
        #endregion

        #region Categories checking
        public IWebElement GetDropdownToggle(string text)
        {
            try
            {
                return WebDriver.Driver.FindElement(By.XPath($"//*[@class='dropdown-toggle'][contains(text(), \"{text}\")]"));
            }
            catch (Exception)
            {
                return WebDriver.Driver.FindElement(By.XPath($"//*[@class='menu-item-text'][contains(text(), \"{text}\")]"));
            }
        }

        public IWebElement GetDropdownToggleCategory(string text) => WebDriver.Driver.FindElement(By.XPath($"//*[@class='menu-item-text'][contains(text(), \"{text}\")]"));

        public void CheckMainCategories(string categoryName)
        {
            GetDropdownToggle(categoryName).Click();
        }
        #endregion

        #region Search checking
        public void SearchString(string stringForSearching)
        {
            SearchBox.SendKeys(stringForSearching);
            SearchBox.Submit();
        }
        
        public IWebElement GetSelectToggle(string text)
        {
            switch (text)
            {
                case "All fields":
                    return WebDriver.Driver.FindElement(By.XPath($"//SELECT[@id='dplScope_1']"));
                case "Title":
                    return WebDriver.Driver.FindElement(By.XPath($"//SELECT[@id='dplScope_2']"));
                case "Author":
                    return WebDriver.Driver.FindElement(By.XPath($"//SELECT[@id='dplScope_3']"));
                case "Abstract":
                    return WebDriver.Driver.FindElement(By.XPath($"//SELECT[@id='dplScope_4']"));
                case "Full Text":
                    return WebDriver.Driver.FindElement(By.XPath($"//SELECT[@id='dplScope_5']"));
                case "Volume":
                    return WebDriver.Driver.FindElement(By.XPath($"//SELECT[@id='dplScope_6']"));
                case "Issue":
                    return WebDriver.Driver.FindElement(By.XPath($"//SELECT[@id='dplScope_7']"));
                default:
                    return WebDriver.Driver.FindElement(By.XPath($"//SELECT[@id='dplScope_1']"));
            }
        }

        public void CheckTestCasesCategories(KeyValuePair<string, List<string>> categoryDictionary)
        {
            CheckTestCasesKeywords(categoryDictionary);
            CheckTestCasesContentTypes(categoryDictionary);
            CheckTestCasesPublicationDates(categoryDictionary);
        }
        
        void CheckTestCasesKeywords(KeyValuePair<string, List<string>> categoryDictionary)
        {
            switch (categoryDictionary.Key)
            {
                case "All fields":
                    AdvancedSearchByString(categoryDictionary.Value[0], categoryDictionary.Key);
                    break;
                case "Title":
                    AdvancedSearchByTitle(categoryDictionary.Value[0], categoryDictionary.Key);
                    break;
                case "Author":
                    AdvancedSearchByAuthor(categoryDictionary.Value[0], categoryDictionary.Key);
                    break;
                case "Abstract":
                    AdvancedSearchByAbstract(categoryDictionary.Value[0], categoryDictionary.Key);
                    break;
                case "Full Text":
                    AdvancedSearchByFullText(categoryDictionary.Value[0], categoryDictionary.Key);
                    break;
                case "Volume":
                    AdvancedSearchByVolume(categoryDictionary.Value[0], categoryDictionary.Key);
                    break;
                case "Issue":
                    AdvancedSearchByIssue(categoryDictionary.Value[0], categoryDictionary.Key);
                    break;
                default:
                    return;
            }
        }
        
        void CheckTestCasesContentTypes(KeyValuePair<string, List<string>> categoryDictionary)
        {
            switch (categoryDictionary.Key)
            {
                case "Articles":
                    AdvancedSearchWithArticles(categoryDictionary.Value[0]);
                    break;
                case "Images, Tables, Figures":
                    AdvancedSearchWithImages(categoryDictionary.Value[0]);
                    break;
                case "Podcast":
                    AdvancedSearchWithPodcasts(categoryDictionary.Value[0]);
                    break;
                case "Videos":
                    AdvancedSearchWithVideos(categoryDictionary.Value[0]);
                    break;
                case "Blogs":
                    AdvancedSearchWithBlogs(categoryDictionary.Value[0]);
                    break;
                case "CME/CE":
                    AdvancedSearchWithCME(categoryDictionary.Value[0]);
                    break;
                case "Supplemental Digital Content":
                    AdvancedSearchWithSDC(categoryDictionary.Value[0]);
                    break;
                default:
                    return;
            }
        }

        void CheckTestCasesPublicationDates(KeyValuePair<string, List<string>> categoryDictionary)
        {
            switch (categoryDictionary.Key)
            {
                case "All Dates":
                    AdvancedSearchRadiobuttonAllDates.Click();
                    break;
                case "Current Issue":
                    AdvancedSearchRadiobuttonCurrentIssue.Click();
                    break;
                case "Last 12 Months":
                    AdvancedSearchRadiobuttonLast12Months.Click();
                    break;
                case "Last 3 Years":
                    AdvancedSearchRadiobuttonLast3Years.Click();
                    break;
                case "Last 5 Years":
                    AdvancedSearchRadiobuttonLast5Years.Click();
                    break;
                case "Last 8 Years":
                    AdvancedSearchRadiobuttonLast8Years.Click();
                    break;
                default:
                    return;
            }

        }
        #endregion

        #region Navigation
        public void NavigateHere(string url)
        {
            WebDriver.Driver.Navigate().GoToUrl(url);
        }
        
        public void NavigateToJournal(string journalName)
        {
            WebDriver.Driver.Navigate().GoToUrl($"{ConfigurationManager.AppSettings["StartURL"]}{journalName.ToLower()}");
        }
        #endregion

        #region Login-Logout
        public void BaseLogin(string login, string password)
        {
            LoginInput.SendKeys(login);
            PasswordInput.SendKeys(password);
            LoginButton.Click();
        }
        
        public void JournalPageLogin(string login, string password)
        {
            LoginLink.Click();
            BaseLogin(login, password);
        }

        public void JournalPageLogout()
        {
            LogoutLink.Click();
        }
        #endregion

        #region Advanced search by keywords
        void AdvancedSearchByString(string stringForSearching, string key)
        {
            GetSelectToggle(key).Click();
            AdvancedSearchInputAllFields.SendKeys(stringForSearching);
        }

        void AdvancedSearchByTitle(string stringForSearching, string key)
        {
            GetSelectToggle(key).Click();
            AdvancedSearchInputTitle.SendKeys(stringForSearching);
        }

        void AdvancedSearchByAuthor(string stringForSearching, string key)
        {
            GetSelectToggle(key).Click();
            AdvancedSearchInputAuthor.SendKeys(stringForSearching);
        }

        void AdvancedSearchByAbstract(string stringForSearching, string key)
        {
            GetSelectToggle(key).Click();
            AdvancedSearchInputAbstract.SendKeys(stringForSearching);
        }

        void AdvancedSearchByFullText(string stringForSearching, string key)
        {
            GetSelectToggle(key).Click();
            AdvancedSearchInputFullText.SendKeys(stringForSearching);
        }

        void AdvancedSearchByVolume(string stringForSearching, string key)
        {
            GetSelectToggle(key).Click();        
            AdvancedSearchInputVolume.SendKeys(stringForSearching);
        }

        void AdvancedSearchByIssue(string stringForSearching, string key)
        {
            GetSelectToggle(key).Click();
            AdvancedSearchInputIssue.SendKeys(stringForSearching);
        }
        #endregion

        #region Advanced search with content types
        void AdvancedSearchWithArticles(string stringForChecking)
        {
            if (stringForChecking.Equals("+"))
            {
                if (AdvancedSearchCheckboxArticles.Selected == false)
                    AdvancedSearchCheckboxArticles.Click();
            }
            else if (stringForChecking.Equals("-"))
            {
                if (AdvancedSearchCheckboxArticles.Selected == true)
                    AdvancedSearchCheckboxArticles.Click();
            }
        }

        void AdvancedSearchWithImages(string stringForChecking)
        {
            if (stringForChecking.Equals("+"))
            {
                if (AdvancedSearchCheckboxImages.Selected == false)
                    AdvancedSearchCheckboxImages.Click();
            }
            else if (stringForChecking.Equals("-"))
            {
                if (AdvancedSearchCheckboxImages.Selected == true)
                    AdvancedSearchCheckboxImages.Click();
            }
        }

        void AdvancedSearchWithPodcasts(string stringForChecking)
        {
            if (stringForChecking.Equals("+"))
            {
                if (AdvancedSearchCheckboxPodcasts.Selected == false)
                    AdvancedSearchCheckboxPodcasts.Click();
            }
            else if (stringForChecking.Equals("-"))
            {
                if (AdvancedSearchCheckboxPodcasts.Selected == true)
                    AdvancedSearchCheckboxPodcasts.Click();
            }
        }

        void AdvancedSearchWithVideos(string stringForChecking)
        {
            if (stringForChecking.Equals("+"))
            {
                if (AdvancedSearchCheckboxVideos.Selected == false)
                    AdvancedSearchCheckboxVideos.Click();
            }
            else if (stringForChecking.Equals("-"))
            {
                if (AdvancedSearchCheckboxVideos.Selected == true)
                    AdvancedSearchCheckboxVideos.Click();
            }
        }

        void AdvancedSearchWithBlogs(string stringForChecking)
        {
            if (stringForChecking.Equals("+"))
            {
                if (AdvancedSearchCheckboxBlogs.Selected == false)
                    AdvancedSearchCheckboxBlogs.Click();
            }
            else if (stringForChecking.Equals("-"))
            {
                if (AdvancedSearchCheckboxBlogs.Selected == true)
                    AdvancedSearchCheckboxBlogs.Click();
            }
        }

        void AdvancedSearchWithCME(string stringForChecking)
        {
            if (stringForChecking.Equals("+"))
            {
                if (AdvancedSearchCheckboxCME.Selected == false)
                    AdvancedSearchCheckboxCME.Click();
            }
            else if (stringForChecking.Equals("-"))
            {
                if (AdvancedSearchCheckboxCME.Selected == true)
                    AdvancedSearchCheckboxCME.Click();
            }
        }
        
        void AdvancedSearchWithSDC(string stringForChecking)
        {
            if (stringForChecking.Equals("+"))
            {
                if (AdvancedSearchCheckboxSDC.Selected == false)
                    AdvancedSearchCheckboxSDC.Click();
            }
            else if (stringForChecking.Equals("-"))
            {
                if (AdvancedSearchCheckboxSDC.Selected == true)
                    AdvancedSearchCheckboxSDC.Click();
            }
        }
        #endregion

        #region Advanced search in other journals
        public void AdvancedSearchInOtherJournals(string journalName)
        {
            if (specialJournals.Contains(journalName))
            {
                if (AdvancedSearchCheckboxJournal1.Selected == false)
                    AdvancedSearchCheckboxJournal1.Click();
                if (AdvancedSearchCheckboxJournal2.Selected == false)
                    AdvancedSearchCheckboxJournal2.Click();
            }
        }
        #endregion

        
/*
//        #region Advanced search checking


        public void CheckTestCasesCategories(string categoryName)
        {
            GetSelectToggle(categoryName).Click();
        }


        // Logout checking
        public void JournalPageLogout()
        {
            LogoutLink.Click();
        }


        // Base search checking
        public void SearchString(string stringForSearching)
        {
            SearchBox.SendKeys(stringForSearching);
            SearchBox.Submit();
        }


        // Advanced search by keywords checking
        public void AdvancedSearchByString(string stringForSearching)
        {
            //            AdvancedSearchLink.Click();
            AdvancedSearchInputAllFields.SendKeys(stringForSearching);
            //            AdvancedSearchButton.Click();
        }

        public void AdvancedSearchByTitle(string stringForSearching)
        {
            //            AdvancedSearchLink.Click();
            AdvancedSearchInputTitle.SendKeys(stringForSearching);
            //            AdvancedSearchButton.Click();
        }

        public void AdvancedSearchByAuthor(string stringForSearching)
        {
            //            AdvancedSearchLink.Click();
            AdvancedSearchInputAuthor.SendKeys(stringForSearching);
            //            AdvancedSearchButton.Click();
        }

        public void AdvancedSearchByAbstract(string stringForSearching)
        {
            //            AdvancedSearchLink.Click();
            AdvancedSearchInputAbstract.SendKeys(stringForSearching);
            //            AdvancedSearchButton.Click();
        }

        public void AdvancedSearchByFullText(string stringForSearching)
        {
            //            AdvancedSearchLink.Click();
            AdvancedSearchInputFullText.SendKeys(stringForSearching);
            //            AdvancedSearchButton.Click();
        }

        public void AdvancedSearchByVolume(string stringForSearching)
        {
            //            AdvancedSearchLink.Click();
            AdvancedSearchInputVolume.SendKeys(stringForSearching);
            //            AdvancedSearchButton.Click();
        }

        public void AdvancedSearchByIssue(string stringForSearching)
        {
            //            AdvancedSearchLink.Click();
            AdvancedSearchInputIssue.SendKeys(stringForSearching);
            //            AdvancedSearchButton.Click();
        }

        public void AdvancedSearchByKeywords()
        {
            AdvancedSearchByString("article");
            AdvancedSearchByTitle("pain");
            AdvancedSearchByAuthor("walter");
            AdvancedSearchByAbstract("");
            AdvancedSearchByFullText("");
            AdvancedSearchByVolume("");
            AdvancedSearchByIssue("10");
        }


        // Advanced search with content type checking
        public void AdvancedSearchWithArticles()
        {
            if (AdvancedSearchCheckboxArticles.Selected == false)
                AdvancedSearchCheckboxArticles.Click();
        }

        public void AdvancedSearchWithImages()
        {
            if (AdvancedSearchCheckboxImages.Selected == false)
                AdvancedSearchCheckboxImages.Click();
        }

        public void AdvancedSearchWithPodcasts()
        {
            if (AdvancedSearchCheckboxPodcasts.Selected == false)
                AdvancedSearchCheckboxPodcasts.Click();
        }

        public void AdvancedSearchWithVideos()
        {
            if (AdvancedSearchCheckboxVideos.Selected == false)
                AdvancedSearchCheckboxVideos.Click();
        }

        public void AdvancedSearchWithBlogs()
        {
            if (AdvancedSearchCheckboxBlogs.Selected == false)
                AdvancedSearchCheckboxBlogs.Click();
        }

        public void AdvancedSearchWithCME()
        {
            if (AdvancedSearchCheckboxCME.Selected == false)
                AdvancedSearchCheckboxCME.Click();
        }

        public void AdvancedSearchWithSDC()
        {
            if (AdvancedSearchCheckboxSDC.Selected == false)
                AdvancedSearchCheckboxSDC.Click();
        }

        public void AdvancedSearchWithContentTypes()
        {
            AdvancedSearchWithArticles();
            AdvancedSearchWithImages();
            AdvancedSearchWithPodcasts();
            AdvancedSearchWithVideos();
            AdvancedSearchWithBlogs();
            AdvancedSearchWithCME();
            AdvancedSearchWithSDC();
        }


        // Advanced search by publication dates checking
        public void AdvancedSearchByPublicationDates(string publicationDates)
        {
            //            if (publicationDates.Equals("All Dates"))
            AdvancedSearchRadiobuttonAllDates.Click();
            //            else if (publicationDates.Equals("Current Issue"))
            AdvancedSearchRadiobuttonCurrentIssue.Click();
            //            else if (publicationDates.Equals("Last 12 Months"))
            AdvancedSearchRadiobuttonLast12Months.Click();
            //            else if (publicationDates.Equals("Last 3 Years"))
            AdvancedSearchRadiobuttonLast3Years.Click();
            //            else if (publicationDates.Equals("Last 5 Years"))
            AdvancedSearchRadiobuttonLast5Years.Click();
            //            else if (publicationDates.Equals("Last 8 Years"))
            AdvancedSearchRadiobuttonLast8Years.Click();
        }


        // Advanced search in other journals checking
        void AdvancedSearchCheckFirstJournal(List<string> journalsNames)
        {
            if (journalsNames[0].Equals("A&A Case Reports") || journalsNames[0].Equals("Plastic and Reconstructive Surgery – Global Open"))
                if (AdvancedSearchCheckboxJournal1.Selected == false)
                    AdvancedSearchCheckboxJournal1.Click();
            if (journalsNames.Count > 1)
            {
                if (journalsNames[1].Equals("A&A Case Reports") || journalsNames[1].Equals("Plastic and Reconstructive Surgery – Global Open"))
                    if (AdvancedSearchCheckboxJournal2.Selected == false)
                        AdvancedSearchCheckboxJournal2.Click();
            }
        }

        void AdvancedSearchCheckSecondJournal(List<string> journalsNames)
        {
            if (journalsNames.Count > 1)
            {
                if (journalsNames[1].Equals("Anesthesia & Analgesia") || journalsNames[1].Equals("Plastic and Reconstructive Surgery"))
                    if (AdvancedSearchCheckboxJournal2.Selected == false)
                        AdvancedSearchCheckboxJournal2.Click();
            }
            if (journalsNames[0].Equals("Anesthesia & Analgesia") || journalsNames[0].Equals("Plastic and Reconstructive Surgery"))
                if (AdvancedSearchCheckboxJournal1.Selected == false)
                    AdvancedSearchCheckboxJournal1.Click();
        }

        public void AdvancedSearchInOtherJournals(List<string> journalsNames)
        {
            AdvancedSearchCheckFirstJournal(journalsNames);
            AdvancedSearchCheckSecondJournal(journalsNames);
        }
*/
    }
}