﻿using System;
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

            DateTime newAssignmentEndDate = newAssignmentEndDateCalendar.SelectedDate;
            TimeSpan newAssignmentDuration = newAssignmentEndDate.Subtract(newAssignmentStartDate);
            int lengthOfNewAssignment = newAssignmentDuration.Days;

            if (newAssignmentEndDate < newAssignmentStartDate)
            {
                resultsLabel.Text = "Error: Your mission projected end date was before your projected start date.";
                previousAssignmentEndDateCalendar.SelectedDate = DateTime.Now.Date;
                newAssignmentStartDateCalendar.SelectedDate = DateTime.Now.AddDays(14).Date;
                newAssignmentEndDateCalendar.SelectedDate = DateTime.Now.AddDays(21).Date;

            }
            if (!(differenceBetweenDates >= 14))
            {
                newAssignmentStartDateCalendar.SelectedDate = DateTime.Now.AddDays(14).Date;
                resultsLabel.Text = "Error: You must allow at least two weeks between " +
                    "the previous assignment and new assignment.";
            }
            else
            {
                int daysFee = (lengthOfNewAssignment * 500);
                if (lengthOfNewAssignment >= 21)
                {
                    daysFee = ((lengthOfNewAssignment * 500) + 1000);
                }
                string result = string.Format("This mission will cost: {0:C}"
                    , daysFee);
                resultsLabel.Text = result;
            }
            string test = "test";
        }
    }
}