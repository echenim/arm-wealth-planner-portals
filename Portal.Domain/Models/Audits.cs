using System;

namespace Portal.Domain.Models
{
    public class Audits
    {
        public int Id { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string CRUD_Action { get; set; }
        public string UserID { get; set; }
        public string BeforeData { get; set; }
        public string AfterData { get; set; }
        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        public string Level { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string Exception { get; set; }
        public string Properties { get; set; }
        public string LogEvent { get; set; }
    }
}