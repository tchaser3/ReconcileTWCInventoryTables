/* Title:           Logon
 * Date:            5-31-16
 * Author:          Terry Holmes
 *
 * Description:     This form is the logon form */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewEventLogDLL;
using NewEmployeeDLL;
using MessagesDLL;
using KeyWordDLL;
using DataValidationDLL;
using LastTransactionDLL;

namespace ReconcileTWCInventoryTables
{
    public partial class Logon : Form
    {
        //setting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();
        EventLogClass TheEventLogClass = new EventLogClass();
        EmployeeClass TheEmployeeClass = new EmployeeClass();
        KeyWordClass TheKeyWordClass = new KeyWordClass();
        DataValidationClass TheDataValidationClass = new DataValidationClass();
        LastTransactionClass TheLastTransactionClass = new LastTransactionClass();
        PleaseWait PleaseWait = new PleaseWait();

        public static VerifyLogonDataSet TheVerifyLogonDataSet = new VerifyLogonDataSet();
        public static FindPartsWarehousesDataSet TheFindPartsDataSet = new FindPartsWarehousesDataSet();

        //setting global variables
        public static string mstrErrorMessage;
        public static int mintEmployeeID;
        public static int mintPartsWarehouseID;
        public static string mstrLastTransactionSummary;
        public static string mstrSelectedButton;
        public static int mintInternalProjectID;
        public static string mstrTWCProjectID;
        public static string mstrPartNumber;
        public static string mintQuantity;
        public static string mstrMSRNumber;
        public static string mstrWarehouse;
        public static DateTime mdatTransactionDate;
        int mintNumberOfMisses;
        
        public Logon()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this will close the program
            TheMessagesClass.CloseTheProgram();
        }
        private bool LoadComboBox()
        {

            //setting local variables
            bool blnFatalError = false;
            int intCounter;
            int intNumberOfRecords;

            //setting up the data
            TheFindPartsDataSet = TheEmployeeClass.FindPartsWarehouses();

            //getting the number of records
            intNumberOfRecords = TheFindPartsDataSet.FindPartsWarehouses.Rows.Count - 1;
            cboWarehouse.Items.Add("SELECT");

            //loop
            for (intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
            {
                cboWarehouse.Items.Add(TheFindPartsDataSet.FindPartsWarehouses[intCounter].FirstName);
            }

            //setting the selected index
            cboWarehouse.SelectedIndex = 0;

            //return to calling method
            return blnFatalError;
        }

        private void btnLogon_Click(object sender, EventArgs e)
        {
            //setting local variables
            bool blnFatalError = false;
            bool blnThereIsAProblem = false;
            string strErrorMessage = "";
            string strValueForValidation;
            string strLastName;
            int intEmployeeID;
            int intRecordsReturned;

            //beginning data validation
            if (cboWarehouse.Text == "SELECT")
            {
                blnThereIsAProblem = true;
                strErrorMessage = strErrorMessage + "The Warehouse Was Not Selected\n";
            }
            strValueForValidation = txtEmployeeID.Text;
            blnFatalError = TheDataValidationClass.VerifyIntegerData(strValueForValidation);
            if (blnFatalError == true)
            {
                blnThereIsAProblem = true;
                strErrorMessage = strErrorMessage + "The Value for Employee ID is not an Integer\n";
            }
           strLastName = txtLogonLastName.Text;
            blnFatalError = TheDataValidationClass.VerifyTextData(strLastName);
            if (blnFatalError == true)
            {
                blnThereIsAProblem = true;
                strErrorMessage = strErrorMessage + "The Last Name Was Not Entered\n";
            }
            if (blnThereIsAProblem == true)
            {
                TheMessagesClass.ErrorMessage(strErrorMessage);
                return;
            }
            //checking employee login
            intEmployeeID = Convert.ToInt32(txtEmployeeID.Text);

            TheVerifyLogonDataSet = TheEmployeeClass.VerifyLogon(intEmployeeID, strLastName);

            intRecordsReturned = TheVerifyLogonDataSet.VerifyLogon.Rows.Count;

            if(intRecordsReturned == 0)
            {
                LogonFailed();
            }
            else
            {
                if(TheVerifyLogonDataSet.VerifyLogon[0].EmployeeGroup != "ADMIN")
                {
                    LogonFailed();
                }
                else
                {
                    ReconcileTWCInventory ReconcileTWCInventory = new ReconcileTWCInventory();
                    ReconcileTWCInventory.Show();
                    Hide();
                }
            }
            
        }
        private void LogonFailed()
        {
            mintNumberOfMisses++;

            if(mintNumberOfMisses == 3)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "There Have Been Three Attempts to Log In, The Program Will Close");

                Close();
            }
            else
            {
                TheMessagesClass.InformationMessage("You Have Failed the Logon In Process");

            }
        }
        private void Logon_Load(object sender, EventArgs e)
        {
            //setting local variables
            bool blnFatalError = false;

            PleaseWait.Show();

            mintNumberOfMisses = 0;

            //beginning functions
            blnFatalError = LoadComboBox();

            PleaseWait.Hide();

            if (blnFatalError == true)
            {
                //message to user
                TheMessagesClass.ErrorMessage(mstrErrorMessage);

                //event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "TWC Inventory Logon " + mstrErrorMessage);

                btnLogon.Enabled = false;
            }
        }
    }
}
