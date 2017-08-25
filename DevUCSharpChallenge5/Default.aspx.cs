using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DevUCSharpChallenge5
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //set default end date of previous assignment to the current date.
                previousAssignmentEndDateCalendar.SelectedDate = DateTime.Now.Date;
                //default start date of new assignment = 14 days from now
                newAssignmentStartDateCalendar.SelectedDate = DateTime.Now.AddDays(14).Date;
                //default end date of new assignment = 21 days from now
                newAssignmentEndDateCalendar.SelectedDate = DateTime.Now.AddDays(21).Date;
            }
        }

        protected void assignSpyButton_Click(object sender, EventArgs e)
        {
            DateTime newAssignmentStartDate = newAssignmentStartDateCalendar.SelectedDate;
            DateTime previousAssignmentEndDate = previousAssignmentEndDateCalendar.SelectedDate;
            TimeSpan timeBetweenAssignments = newAssignmentStartDate.Subtract(previousAssignmentEndDate);
            int differenceBetweenDates = timeBetweenAssignments.Days;
            
            if (differenceBetweenDates >= 14)
            {
                resultsLabel.Text = "business logic";
            }
            else
            {
                resultsLabel.Text = "Error: Must allow at least two weeks between previous assignment and new assignment";
            }
            //

            //int spyFee = (//days * 500 bouns of 1000 if over 21 days )
        }
    }
}