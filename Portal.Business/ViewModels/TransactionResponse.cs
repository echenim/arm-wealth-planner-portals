using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Business.ViewModels
{
    public class TransactionResponse
    {
        public string ArmTxnRef { get; set; }
        public string ArmPayRef { get; set; }
        public int ArmTranxAmt { get; set; }
        public string ArmTranxStatusCode { get; set; }
        public string ArmTranxStatusMsg { get; set; }
        public string ArmTranxCurr { get; set; }
        public string ArmCustId { get; set; }
        public string ArmPaymentParams { get; set; }
    }

    public class DirectDebitTransactionResponse
    {
        public string ArmDdRef { get; set; }
        public string ArmDdStatusCode { get; set; }
        public string ArmDdStatusMsg { get; set; }
        public decimal ArmDdAmt { get; set; }
        public string ArmCustId { get; set; }
        public string ArmCcType { get; set; }
        public string ArmCcMask { get; set; }
        public decimal ArmDdAmtAppr { get; set; }
    }
}
