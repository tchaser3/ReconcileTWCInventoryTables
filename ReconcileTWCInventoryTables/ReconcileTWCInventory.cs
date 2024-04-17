/* Title:           Reconcile TWC Inventory
 * Date:            5-31-16
 * Author:          Terry Holmes
 *
 * Description:     This form is for reconciling TWC Inventory */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagesDLL;
using PartNumberDLL;
using InventoryDLL;
using NewEventLogDLL;
using DataValidationDLL;
using CreateIDDLL;

namespace ReconcileTWCInventoryTables
{
    public partial class ReconcileTWCInventory : Form
    {
        //setting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();
        PartNumberClass ThePartNumberClass = new PartNumberClass();
        InventoryClass TheInventoryClass = new InventoryClass();
        EventLogClass TheEventLogClass = new EventLogClass();
        PleaseWait PleaseWait = new PleaseWait();
        DataValidationClass TheDataValidationClass = new DataValidationClass();
        CreateIDClass TheCreateIDClass = new CreateIDClass();

        //setting the data set
        InventoryDataSet TheInventoryDataSet;
        WarehouseInventoryDataSet TheWarehouseInventoryDataSet;
        PartNumbersDataSet ThePartNumberDataSet;
        AdjustInventoryDataSet TheAdjustInventoryDataSet;

        //loading part number structure
        struct PartNumbers
        {
            public int mintPartID;
            public string mstrPartNumber;
            public string mstrDescription;
        }

        //setting variables for structure
        PartNumbers[] ThePartNumbers;
        int mintPartCounter;
        int mintPartUpperLimit;

        struct Inventory
        {
            public int mintPartID;
            public string mstrPartNumber;
            public int mintWarehouseID;
            public int mintQuantity;
        }

        Inventory[] TheTWCInventory;
        int mintTWCCounter;
        int mintTWCUpperLimit;

        Inventory[] TheWarehouseInventory;
        int mintWarehouseCounter;
        int mintWarehouseUpperLimit;

        int mintTWCPartID;
        int mintWarehousePartID;
        
        //setting global variables
        string mstrErrorMessage;
        int mintPartWarehouseID;

        public ReconcileTWCInventory()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //closing the program
            TheMessagesClass.CloseTheProgram();
        }

        private void ReconcileTWCInventory_Load(object sender, EventArgs e)
        {
            //setting local variables
            bool blnFatalError = false;

            //setting the variable
            mintPartWarehouseID = Logon.mintPartsWarehouseID;

            PleaseWait.Show();

            blnFatalError = SetPartStructure();
            if (blnFatalError == false)
                blnFatalError = LoadTWCInventoryStructure();
            if (blnFatalError == false)
                blnFatalError = LoadWarehouseInventoryStructure();
            if (blnFatalError == false)
                blnFatalError = LoadAdjustInventoryDataSet();

            cboWarehouse.Items.Add("SELECT");
            cboWarehouse.Items.Add("TWC INVENTORY");
            cboWarehouse.Items.Add("WAREHOUSE INVENTORY");
            cboWarehouse.Items.Add("BOTH");
            cboWarehouse.SelectedIndex = 0;

            btnUpdate.Enabled = false;
           
            PleaseWait.Hide();

            if(blnFatalError == true)
            {
                TheMessagesClass.ErrorMessage(mstrErrorMessage);
            }
        }
        private bool LoadAdjustInventoryDataSet()
        {
            bool blnFatalError = false;

            try
            {
                //loading the data set
                TheAdjustInventoryDataSet = TheInventoryClass.GetAdjustInventoryInfo();
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Reconcile TWC Inventory Table " + Ex.Message);
            }

            return blnFatalError;
        }
        private bool LoadWarehouseInventoryStructure()
        {
            //setting local variables
            bool blnFatalError = false;
            int intCounter;
            int intNumberOfRecords;
            int intWarehouseIDFromTable;

            //try catch for exceptions
            try
            {
                //loading data set
                TheWarehouseInventoryDataSet = TheInventoryClass.GetWarehouseInventoryInfo();

                //setting up for the loop
                intNumberOfRecords = TheWarehouseInventoryDataSet.WarehouseInventory.Rows.Count - 1;
                TheWarehouseInventory = new Inventory[intNumberOfRecords + 1];
                mintWarehouseCounter = 0;

                //performing loop
                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    //getting the warehouse id
                    intWarehouseIDFromTable = Convert.ToInt32(TheWarehouseInventoryDataSet.WarehouseInventory.Rows[intCounter][4]);

                    if(mintPartWarehouseID == intWarehouseIDFromTable)
                    {
                        TheWarehouseInventory[mintWarehouseCounter].mintPartID = Convert.ToInt32(TheWarehouseInventoryDataSet.WarehouseInventory.Rows[intCounter][0]);
                        TheWarehouseInventory[mintWarehouseCounter].mstrPartNumber = Convert.ToString(TheWarehouseInventoryDataSet.WarehouseInventory.Rows[intCounter][1]).ToUpper();
                        TheWarehouseInventory[mintWarehouseCounter].mintQuantity = Convert.ToInt32(TheWarehouseInventoryDataSet.WarehouseInventory.Rows[intCounter][3]);
                        TheWarehouseInventory[mintWarehouseCounter].mintWarehouseID = intWarehouseIDFromTable;
                        mintWarehouseUpperLimit = mintWarehouseCounter;
                        mintWarehouseCounter++;
                    }
                }

                mintWarehouseCounter = 0;
            }
            catch (Exception Ex)
            {
                //setting the message
                mstrErrorMessage = Ex.Message;

                //creating event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Reconcile TWC Inventory Tables " + Ex.Message);
            }

            //returing value
            return blnFatalError;
        }
        private bool LoadTWCInventoryStructure()
        {
            //setting local variables
            bool blnFatalError = false;
            int intCounter;
            int intNumberOfRecords;
            int intWarehouseIDFromTable;

            //try catch for exceptions
            try
            {
                TheInventoryDataSet = TheInventoryClass.GetInventoryInfo();

                //getting the record count
                intNumberOfRecords = TheInventoryDataSet.Inventory.Rows.Count - 1;
                TheTWCInventory = new Inventory[intNumberOfRecords + 1];
                mintTWCCounter = 0;

                //running loop
                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    intWarehouseIDFromTable = Convert.ToInt32(TheInventoryDataSet.Inventory.Rows[intCounter][2]);

                    //if statement
                    if(intWarehouseIDFromTable == mintPartWarehouseID)
                    {
                        TheTWCInventory[mintTWCCounter].mintPartID = Convert.ToInt32(TheInventoryDataSet.Inventory.Rows[intCounter][0]);
                        TheTWCInventory[mintTWCCounter].mstrPartNumber = Convert.ToString(TheInventoryDataSet.Inventory.Rows[intCounter][1]).ToUpper();
                        TheTWCInventory[mintTWCCounter].mintWarehouseID = intWarehouseIDFromTable;
                        TheTWCInventory[mintTWCCounter].mintQuantity = Convert.ToInt32(TheInventoryDataSet.Inventory.Rows[intCounter][4]);
                        mintTWCUpperLimit = mintTWCCounter;
                        mintTWCCounter++;
                    }
                }

                mintTWCCounter = 0;

            }
            catch (Exception Ex)
            {
                //setting the message
                mstrErrorMessage = Ex.Message;

                //creating event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Reconcile TWC Inventory Tables " + Ex.Message);
            }

            //returing value
            return blnFatalError;
        }
        private bool SetPartStructure()
        {
            //setting local variables
            bool blnFatalError = false;
            int intCounter;
            int intNumberOfRecords;
            string strPartNumberForTest;
            bool blnIsTWCPartNumber;

            //try catch for exceptions
            try
            {
                //loading the data set
                ThePartNumberDataSet = ThePartNumberClass.GetPartNumbersInfo();

                //setting up the variables
                intNumberOfRecords = ThePartNumberDataSet.partnumbers.Rows.Count - 1;
                ThePartNumbers = new PartNumbers[intNumberOfRecords + 1];
                mintPartCounter = 0;

                //beginning loop
                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    //loading variable
                    strPartNumberForTest = Convert.ToString(ThePartNumberDataSet.partnumbers.Rows[intCounter][1]).ToUpper();
                    blnIsTWCPartNumber = ThePartNumberClass.CheckTimeWarnerPart(strPartNumberForTest);

                    //if statement
                    if(blnIsTWCPartNumber == false)
                    {
                        ThePartNumbers[mintPartCounter].mintPartID = Convert.ToInt32(ThePartNumberDataSet.partnumbers.Rows[intCounter][0]);
                        ThePartNumbers[mintPartCounter].mstrPartNumber = strPartNumberForTest;
                        ThePartNumbers[mintPartCounter].mstrDescription = Convert.ToString(ThePartNumberDataSet.partnumbers.Rows[intCounter][2]).ToUpper();
                        mintPartUpperLimit = mintPartCounter;
                        mintPartCounter++;
                    }
                }

                mintPartCounter = 0;

            }
            catch (Exception Ex)
            {
                //setting the message
                mstrErrorMessage = Ex.Message;

                //creating event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Reconcile TWC Inventory Tables " + Ex.Message);
            }

            //returing value
            return blnFatalError;
        }

        private void cboWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboWarehouse.Text != "SELECT")
            {
                if(cboWarehouse.Text == "TWC INVENTORY")
                {
                    txtWarehouseQuantity.ReadOnly = true;
                    txtTWCQuantity.ReadOnly = false;
                }
                else if(cboWarehouse.Text == "WAREHOUSE INVENTORY")
                {
                    txtWarehouseQuantity.ReadOnly = false;
                    txtTWCQuantity.ReadOnly = true;
                }
                else if(cboWarehouse.Text == "BOTH")
                {
                    txtWarehouseQuantity.ReadOnly = false;
                    txtTWCQuantity.ReadOnly = false;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //setting local variables
            int intCounter;
            string strPartNumber;
            bool blnFatalError = false;
            bool blnThereIsAProblem = false;
            string strErrorMessage = "";
            bool blnItemNotFound = true;

            //beginning data validation
            strPartNumber = txtEnterPartNumber.Text;
            btnUpdate.Enabled = false;
            LoadTWCInventoryStructure();
            LoadWarehouseInventoryStructure();
            
            blnFatalError = TheDataValidationClass.VerifyTextData(strPartNumber);
            if(blnFatalError == true)
            {
                blnThereIsAProblem = true;
                strErrorMessage = strErrorMessage + "Part Numberr Was Not Entered\n";
            }
            else
            {
                blnFatalError = ThePartNumberClass.CheckTimeWarnerPart(strPartNumber);
                if(blnFatalError == true)
                {
                    blnThereIsAProblem = true;
                    strErrorMessage = strErrorMessage + "The Part Number Entered was not a TWC Part Number\n";
                }
            }
            if(cboWarehouse.Text == "SELECT")
            {
                blnThereIsAProblem = true;
                strErrorMessage = strErrorMessage + "The Update Type Was not Selected\n";
            }
            if(blnThereIsAProblem == true)
            {
                TheMessagesClass.ErrorMessage(strErrorMessage);
                return;
            }

            //beginning loop
            for(intCounter = 0; intCounter <= mintTWCUpperLimit; intCounter++)
            {
                if(strPartNumber == TheTWCInventory[intCounter].mstrPartNumber)
                {
                    mintTWCPartID = TheTWCInventory[intCounter].mintPartID;
                    txtPartID.Text = Convert.ToString(mintTWCPartID);
                    txtPartNumber.Text = TheTWCInventory[intCounter].mstrPartNumber;
                    txtTWCQuantity.Text = Convert.ToString(TheTWCInventory[intCounter].mintQuantity);
                    txtWarehouseID.Text = Convert.ToString(TheTWCInventory[intCounter].mintWarehouseID);
                    blnItemNotFound = false;
                }
            }

            for(intCounter = 0; intCounter <= mintPartUpperLimit; intCounter++)
            {
                if(strPartNumber == ThePartNumbers[intCounter].mstrPartNumber)
                {
                    txtDescripton.Text = ThePartNumbers[intCounter].mstrDescription;
                }
            }

            for(intCounter =0; intCounter <= mintWarehouseUpperLimit; intCounter++)
            {
                if(strPartNumber == TheWarehouseInventory[intCounter].mstrPartNumber)
                {
                    mintWarehousePartID = TheWarehouseInventory[intCounter].mintPartID;
                    txtWarehouseQuantity.Text = Convert.ToString(TheWarehouseInventory[intCounter].mintQuantity);
                    blnItemNotFound = false;
                }
            }

            if(blnItemNotFound == true)
            {
                TheMessagesClass.InformationMessage("The Part Number Entered Does Not Have Any Inventory");
                return;
            }
            else
            {
                btnUpdate.Enabled = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //setting up local variables
            bool blnFatalError = false;
            bool blnThereIsAProblem = false;
            string strValueForValidation;
            string strErrorMessage = "";
            string strPartNumberForSearch;
            int intTWCQuantity = 0;
            int intWarehouseQuantity = 0;
            int intPartID;
            
            //beginning data validation
            strValueForValidation = txtTWCQuantity.Text;
            blnFatalError = TheDataValidationClass.VerifyIntegerData(strValueForValidation);
            if(blnFatalError == true)
            {
                blnThereIsAProblem = true;
                strErrorMessage = strErrorMessage + "The TWC Inventory Quantity is not an Integer\n";
            }
            else
            {
                intTWCQuantity = Convert.ToInt32(strValueForValidation);
            }
            strValueForValidation = txtWarehouseQuantity.Text;
            blnFatalError = TheDataValidationClass.VerifyIntegerData(strValueForValidation);
            if (blnFatalError == true)
            {
                blnThereIsAProblem = true;
                strErrorMessage = strErrorMessage + "The Warehouse Quantity is not an Integer\n";
            }
            else
            {
                intWarehouseQuantity = Convert.ToInt32(strValueForValidation);
            }
            strValueForValidation = txtExplaination.Text;
            blnFatalError = TheDataValidationClass.VerifyTextData(strValueForValidation);
            if(blnFatalError == true)
            {
                blnThereIsAProblem = true;
                strErrorMessage = strErrorMessage + "The Explaination Has Not Been Entered\n";
            }
            if(blnThereIsAProblem == true)
            {
                TheMessagesClass.ErrorMessage(strErrorMessage);
                return;
            }

            strPartNumberForSearch = txtPartNumber.Text;


            intPartID = ThePartNumberClass.FindPartID(strPartNumberForSearch);


            try
            {
                //updating TWC Inventory
                blnFatalError = TheInventoryClass.AdjustInventoryCount(intPartID, mintPartWarehouseID, intTWCQuantity);
                if(blnFatalError == true)
                {
                    TheMessagesClass.ErrorMessage("There Was A Problem, Please Contact IT.  The Record Was Not Saved");
                }
                else
                {
                    blnFatalError = TheInventoryClass.AdjustWarehouseInventoryCount(intPartID, mintPartWarehouseID, intWarehouseQuantity);

                    if (blnFatalError == true)
                    {
                        TheMessagesClass.ErrorMessage("There Was A Problem, Please Contact IT.  The Record Was Not Saved");
                    }
                }
                if(blnFatalError == false)
                {
                    //creatine new record
                    AdjustInventoryDataSet.adjustinventoryRow NewTableRow = TheAdjustInventoryDataSet.adjustinventory.NewadjustinventoryRow();

                    //creating the new row
                    NewTableRow.TransactionID = TheCreateIDClass.CreateInventoryID();
                    NewTableRow.PartNumber = strPartNumberForSearch;
                    NewTableRow.Quantity = intTWCQuantity;
                    NewTableRow.Reason = txtExplaination.Text;
                    NewTableRow.EmployeeID = Logon.TheVerifyLogonDataSet.VerifyLogon[0].EmployeeID;
                    NewTableRow.Date = DateTime.Now;
                    NewTableRow.WarehouseID = mintPartWarehouseID;

                    //updating the table
                    TheAdjustInventoryDataSet.adjustinventory.Rows.Add(NewTableRow);
                    TheInventoryClass.UpdateAdjustInventoryDB(TheAdjustInventoryDataSet);
                }

                if(blnFatalError == false)
                {
                    TheMessagesClass.InformationMessage("The Record Has Been Saved");
                    txtDescripton.Text = "";
                    txtEnterPartNumber.Text = "";
                    txtExplaination.Text = "";
                    txtPartID.Text = "";
                    txtPartNumber.Text = "";
                    txtTWCQuantity.Text = "";
                    txtWarehouseQuantity.Text = "";
                    txtWarehouseID.Text = "";
                }
            }
            catch(Exception Ex)
            {
                TheMessagesClass.ErrorMessage(Ex.Message);

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Reconcoile TWC Inventory " + Ex.Message);
            }
            
        }
    }
}
