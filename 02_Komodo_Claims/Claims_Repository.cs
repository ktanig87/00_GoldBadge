using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Komodo_Claims
{
    public class Claims_Repository
    {
        public readonly Queue<Claim_POCO> _ClaimsList = new Queue<Claim_POCO>();


        //C- Create Claim
        public bool CreateClaim(Claim_POCO claim)
        {
            int startCount = _ClaimsList.Count;
            _ClaimsList.Enqueue(claim);

            bool wasAdded = (_ClaimsList.Count > startCount);
            return wasAdded;
        }

        //R- View all claims in the queue
        public Queue<Claim_POCO> GetAllClaims()
        {
            return _ClaimsList;
        }

        //R- view next item in queue
        public Claim_POCO GetNextClaim()
        {
            return _ClaimsList.Peek();
        }
    }
}
