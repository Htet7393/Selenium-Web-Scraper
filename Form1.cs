/**
 * Author:    Htet Naing
 * Partner:   None
 * Date:      29 NOV 2022
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Htet Naing - This work may not be copied for use in Academic Coursework.
 *
 * I, Htet Naing, certify that I wrote this code from scratch and did 
 * not copy it in part or whole from another source.  Any references used 
 * in the completion of the assignment are cited in my README file and in
 * the appropriate method header.
 *
 * File Contents
 *
 *    This file contains code for Form.cs
 *         
 */



using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using System.Security.Cryptography;
using static System.Collections.Specialized.BitVector32;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using Keys = OpenQA.Selenium.Keys;
using System.IO;
using File = System.IO.File;

namespace PS7_Web_Scraper
{
    public partial class Form1 : Form
    {
        IWebDriver _driver;

        string year = ""; // for various year
        string sem = "";
        string course_num = "";
        string department = "";

        List<courseData> course_data_list;
        List<string> course_list;
        List<enrollmentData> enrolmentat_data_list;


        public Form1()
        {
            InitializeComponent();
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); // 5 seconds wait time
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
            this.display_box.Text += $"{Thread.CurrentThread.ManagedThreadId}: Stargint Web Scraper\n";
            this.display_box.Text += "Web Scraper running!\n";

            if(_driver == null)
            {
                _driver= new ChromeDriver();
                // set implicit wait time for the driver
            }
            this.display_box.Text += "Driver Ready!\n";
            List<semester> list = new List<semester>();
            list.Add(new semester() { ID = "8", Name = "Fall"});
            list.Add(new semester() { ID = "4", Name = "Spring" });
            list.Add(new semester() { ID = "6", Name = "Summer" });
            this.semester_select.DataSource = list;
            this.semester_select.ValueMember = "ID";
            this.semester_select.DisplayMember= "Name";
        }


        private void OnApplicationExit(object sender, EventArgs e)
        {
            // shutdown gracefully 
            try
            {
                _driver.Close();
                _driver.Quit();
            }
            catch (Exception ex)
            {
                // will have to do something about this, may be not
            }
        }

        // Do nothing currently, will probably change it later
        private void display_box_TextChanged(object sender, EventArgs e)
        {

        }

        // Scraping all courses in details
        private void course_button_Click(object sender, EventArgs e)
        {

            if(valid_inputs(year, department))
            {
               this.display_box.Text += "Scraping all courses!\n";
               scrappig(1);
            }
            else
            {
                MessageBox.Show("Year, department, course cannot be null!");
            }
            
        }

        private void single_course_button_Click(object sender, EventArgs e)
        {
            if(year!= "" && department != "" && course_num != "")
            {
               this.display_box.Text += "Scraping a single course!\n";
               scrappig(2);
            }
            else
            {
                MessageBox.Show("Inputs cannot be null!");
            }
            
        }

        private void enroll_button_Click(object sender, EventArgs e)
        {

            if (valid_inputs(year, department))
            {
                this.display_box.Text += "Checking courses' enrollment status!\n";
                scrappig(3);
            }
            else
            {
                MessageBox.Show("Year, department, course cannot be null!");
            }
            
        }

        private void disableButtons()
        {
            this.dept_box.Enabled = false;
            this.enroll_button.Enabled = false;
            this.semester_select.Enabled = false;
            this.year_box.Enabled = false;
            this.course_box.Enabled= false;
            this.course_button.Enabled = false;
            this.single_course_button.Enabled = false;
        }

        private void enableButtons()
        {
            this.dept_box.Enabled = true;
            this.enroll_button.Enabled=true;
            this.semester_select.Enabled = true;
            this.year_box.Enabled = true;
            this.course_box.Enabled = true;
            this.course_button.Enabled = true;
            this.single_course_button.Enabled = true;
        }

        private void semester_select_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = semester_select.Text;
            semester obj = semester_select.SelectedItem as semester;
            if (obj != null) 
            {
                sem = obj.ID;
            }
            this.display_box.Text += text + "\n";
        }

       
        private void year_box_TextChanged(object sender, EventArgs e)
        {
            string input = year_box.Text;
            string f = "";
            string l = "";
            bool isNumber = int.TryParse(input, out int input_year);
            if (isNumber)
            {
                for(int i = 0; i < input.Length; i++)
                {
                    if(i == 2)
                    {
                        f = input.ToArray()[i].ToString();
                    }else if(i == 3)
                    {
                        l = input.ToArray()[i].ToString();
                    }
                }
                year = f + l;
            }
            else
            {
                Console.WriteLine("Not a valid year");
            }      
        }

        private void course_box_TextChanged(object sender, EventArgs e)
        {
            course_num = course_box.Text;
        }

        private void dept_box_TextChanged(object sender, EventArgs e)
        {
            department = dept_box.Text;
        }

        // Check if inputs are not null
        private bool valid_inputs(string _year, string _dept)
        {
            if(_year == "" || _dept == "")
            {
                return false;
            }
            return true;
        }

        /* check if course number is between 1000 and 6999 */
        private bool valid_course(string num)
        {
            bool valid = false;
            bool val = int.TryParse(num, out int number);
            if (val)
            {
                if (number >= 1000 && number < 6999)
                {
                    valid = true;
                }
                return valid;
            }
            else
            {
                return false;
            }          
        }


        // Called when scrape buttons are clicked
        // Scrapes courses
        private void scrappig(int style)
        {
            disableButtons(); // disable the buttons

            course_list = new List<string>(); // A collection of courses offered in the semester
            course_data_list = new List<courseData>(); // Detail information of classes offered
            enrolmentat_data_list = new List<enrollmentData>(); // Information of enrollment in classes

            this.display_box.Text += "Selected semester: " + semester_select.Text + "\n";
            this.display_box.Text += "Selected year: " + year_box.Text + "\n";
            this.display_box.Text += "Selected course: " + course_num + "\n";

            string homeURL = "https://student.apps.utah.edu/uofu/stu/ClassSchedules/main/1" + year + sem + "/class_list.html?subject=" + department;
            this.display_box.Text += $"{Thread.CurrentThread.ManagedThreadId}: Navigating to: " + homeURL + "\n";
            _driver.Navigate().GoToUrl(homeURL);

            IWebElement course_data = _driver.FindElement(By.Id("class-details"));
            IList<IWebElement> course_collection = course_data.FindElements(By.ClassName("class-info"));
            IList<IWebElement> temp_list;
            IList<IWebElement> list_data;
            IWebElement li;
            IWebElement temp;
            IWebElement temp2;

            this.display_box.Text += "Storing Information\n";
            // Getting coures Data from schedule page
            foreach (IWebElement cf in course_collection)
            {
                temp = cf.FindElement(By.TagName("h3"));
                temp2 = temp.FindElement(By.TagName("a"));
                string c_number = string.Concat(temp2.Text.Where(Char.IsDigit));            
                temp_list = temp.FindElements(By.TagName("span"));         
                li = cf.FindElement(By.TagName("ul"));
                list_data = li.FindElements(By.TagName("li"));
                string component = list_data[2].Text;
                if(valid_course(c_number))
                {
                    if (component.Equals("Component: Lecture") || component.Equals("Component: Seminar"))
                    {
                        course_data_list.Add(new courseData { ID = temp2.Text, Section = temp_list[0].Text, ClassNumber = list_data[0].Text, Instructor = list_data[1].Text, Component = list_data[2].Text, Type = list_data[3].Text, Units = list_data[4].Text, WaitList = list_data[5].Text });
                    }
                }
            }

            this.display_box.Text += "Information stored!\n";
            this.display_box.Text += "Looking for Courses Link\n";
            var look = _driver.FindElement(By.Id("uu-skip-target"));
            var div_num = look.FindElements(By.TagName("div"));
            int div_count = div_num.Count() - 1; // always take the last element
            var classes_link = div_num[div_count];
            classes_link.Click();
            this.display_box.Text += "Courses link clicked\n";
   
            this.display_box.Text += "Starting quary!\n";

           


            IWebElement table = _driver.FindElement((By.Id("seatingAvailabilityTable")));
            IList<IWebElement> tbCollection = table.FindElements(By.TagName("tbody"));
            IList<IWebElement> trCollection;
            IList<IWebElement> tdCollection;
            foreach (IWebElement tb in tbCollection)
            {
                trCollection = tb.FindElements(By.TagName("tr"));
                foreach (IWebElement tr in trCollection)
                {
                    tdCollection = tr.FindElements(By.TagName("td"));
                    string course_number = tdCollection[2].Text;
                    if(valid_course(course_number))
                    {

                        // only save one course at a time
                        if (!course_list.Contains(course_number))
                        {
                            course_list.Add(course_number);
                        }

                        string Class = tdCollection[0].Text;
                        string Subject = tdCollection[1].Text;
                        string Section = tdCollection[3].Text;
                        string Title = tdCollection[4].Text;
                        string Enroll_cap = tdCollection[5].Text;
                        string Waitlist = tdCollection[6].Text;
                        string Enrolled = tdCollection[7].Text;
                        string Available = tdCollection[8].Text;

                        enrolmentat_data_list.Add(new enrollmentData { _class = Class, subject = Subject, section = Section, title = Title, enroll_cap = Enroll_cap, waitlist = Waitlist, enrolled = Enrolled, available = Available});
                    }                 
                }
            }// I have all teh courses offered in this semester

            this.display_box.Text += "Getting coures details!" + "\n";

        
            if(style == 1) // scrape all courses in details
            {
                int count = 0;
                foreach (courseData cd in course_data_list)
                {
                    this.display_box.Text += cd.ID + "\n";
                    this.display_box.Text += cd.Section + "\n";
                    this.display_box.Text += cd.ClassNumber + "\n";
                    this.display_box.Text += cd.Instructor + "\n";
                    this.display_box.Text += cd.Type + "\n";
                    this.display_box.Text += cd.Units + "\n";
                    this.display_box.Text += cd.WaitList + "\n";
                    this.display_box.Text += cd.Component + "\n";
                    this.display_box.Text += "               \n";
                    count++;
                    
                }
            }
            else if(style == 2) // scrape a course and course description
            {
                if (course_list.Contains(course_num))
                {
                    string cid = department + " " + course_num;
                    this.display_box.Text += "checking course num!\n";
                    foreach (courseData cd in course_data_list)
                    {                
                        if (cid.Equals(cd.ID))
                        {
                            this.display_box.Text += cd.ID + "\n";
                            this.display_box.Text += cd.Section + "\n";
                            this.display_box.Text += cd.ClassNumber + "\n";
                            this.display_box.Text += cd.Instructor + "\n";
                            this.display_box.Text += cd.Type + "\n";
                            this.display_box.Text += cd.Units + "\n";
                            this.display_box.Text += cd.WaitList + "\n";
                            this.display_box.Text += cd.Component + "\n";
                            this.display_box.Text += "               \n";
                        }
                    }

                    // Finding course description
                    string course = department + course_num;
                    get_course_description(course);
                }
                else
                {
                    this.display_box.Text += $"CS{course_num} is not offered this semester!\n";
                }
            }
            else
            {
                foreach(enrollmentData en in enrolmentat_data_list)
                {
                    this.display_box.Text += "Class number: " + en._class + "\n";
                    this.display_box.Text += "Subject: " + en.subject + "\n";
                    this.display_box.Text += "Course: " + en.course_number + "\n";
                    this.display_box.Text += "Section: " + en.section + "\n";
                    this.display_box.Text += "Title: " + en.title + "\n";
                    this.display_box.Text += "Enrollment cap: " + en.enroll_cap + "\n";
                    this.display_box.Text += "Wait list: " + en.waitlist + "\n";
                    this.display_box.Text += "Currently enrolled: " + en.enrolled + "\n";
                    this.display_box.Text += "Available seat: " + en.available + "\n";
                    this.display_box.Text += "               \n";
                }
            }


      
            enableButtons();// Enable the buttons

        }

        // Method to obtain a selected course's description
        private void get_course_description(string course)
        {
            _driver.Navigate().GoToUrl("https://catalog.utah.edu/#/home");
            var courses_link = _driver.FindElement(By.XPath("//*[@id=\"top\"]/div/div[3]/div/nav/ul/li[2]/a"));
            courses_link.Click(); // click on courses
            var input = _driver.FindElement(By.XPath("//*[@id=\"top\"]/div/div[2]/span/div/div/div/input"));

            input.SendKeys(course);
            input.SendKeys(Keys.Enter);

            var temp = _driver.FindElement(By.XPath("//*[@id=\"kuali-catalog-main\"]/div[2]/div[2]/div[2]/div/p"));

            this.display_box.Text += "------------------Course Description----------------------\n";
            this.display_box.Text += temp.Text + "\n";
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            //string path = "C:\\csv.txt"; 
            /*try {*/
           // using (StreamWriter sw = new StreamWriter(@path, true))
                //{
                   /* foreach(var cd in course_data_list)
                    {
                        sw.WriteLine("Course "+cd.ID +","+"Course "+cd.Section+","+"Course "+cd.ClassNumber+","+"Course "+cd.Instructor+","+"Course "+cd.Type+","+"Course "+cd.Units+",");
                    }*/

                //}
       /* }
            catch(Exception ex)
            {
                throw new Exception();
    }*/

}
        }
}