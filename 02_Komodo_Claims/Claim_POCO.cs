using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Komodo_Claims
{
    public class Claim_POCO
    {
        public Claim_POCO() { }
        public Claim_POCO(string claimID, string claimType, decimal claimAmount, DateTime claimDate, DateTime incidentDate, string description)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            ClaimAmount = claimAmount;
            DateOfIncident = incidentDate;
            DateOfClaim = claimDate;
            Description = description;
        }
        public string ClaimID { get; set; }
        public string ClaimType { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public string Description { get; set; }
        public bool IsValid
        {
            get
            {
                System.TimeSpan diff = DateOfClaim.Subtract(DateOfIncident);
                int days = diff.Days;
                if (days >= 30)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }
    }
}
